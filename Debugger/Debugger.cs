using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using ScriptStack;
using ScriptStack.Collections;
using ScriptStack.Compiler;
using ScriptStack.Runtime;

using AutocompleteMenuNS;

namespace IDE
{
    internal partial class Debugger : Form, Host 
    {
        #region Private Structs

        private struct ScriptState
        {
            public String m_strFilename;
            public Script m_script;
            public bool m_bNew;
            public bool m_bNeedsSaving;
            public Interpreter m_scriptContext;
            public DebugState m_debugState;
        }

        #endregion

        #region Private Static Variables

        private static TimeSpan s_tsInterval = new TimeSpan(0, 0, 0, 0, 10);

        #endregion

        #region Private Variables

        private Manager m_scriptManager;
        private List<String> m_listOutput;
        private ScriptHistoryManager m_scriptHistoryManager;

        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;

        #endregion

        #region Private Methods

        private bool IsScriptActive()
        {
            if (m_tbcScripts.TabCount == 0) return false;
            ScriptState scriptState = GetCurrentScriptState();
            return scriptState.m_debugState != DebugState.Editor;
        }

        private bool IsScriptSuspended()
        {
            if (m_tbcScripts.TabCount == 0) return false;
            ScriptState scriptState = GetCurrentScriptState();
            return scriptState.m_debugState == DebugState.Suspended;
        }

        private bool IsScriptEditing()
        {
            if (m_tbcScripts.TabCount == 0) return false;
            ScriptState scriptState = GetCurrentScriptState();
            return scriptState.m_debugState == DebugState.Editor;
        }

        private bool ContainsScriptTab(String strScriptName)
        {
            foreach (TabPage tabPage in m_tbcScripts.TabPages)
                if (tabPage.Text.ToUpper() == strScriptName.ToUpper())
                    return true;
            return false;
        }

        private String AllocateNewScriptName()
        {
            int iIndex = 0;
            while (true)
            {
                String strScriptName = "untitled" + (iIndex++) + ".script";
                if (!ContainsScriptTab(strScriptName))
                    return strScriptName;
            }
        }

        /// <summary>
        /// \todo Autocomplete
        /// </summary>
        /// <param name="strScriptName"></param>
        /// <param name="strFilename"></param>
        /// <returns></returns>
        private TextBox CreateScript(String strScriptName, String strFilename)
        {

            TextBox txtScript = new TextBox();

            List<string> list = new List<string>();
            foreach (KeyValuePair<string, Routine> r in m_scriptManager.Routines)
            {
                list.Add(r.Key);
            }
            autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            autocompleteMenu1.MinFragmentLength = 1;
            autocompleteMenu1.MaximumSize = new Size(200,500);
            autocompleteMenu1.SetAutocompleteMenu(txtScript, autocompleteMenu1);
            autocompleteMenu1.Items = list.ToArray();


            txtScript.Multiline = true;
            txtScript.AcceptsReturn = true;
            txtScript.AcceptsTab = true;
            txtScript.Dock = DockStyle.Fill;
            txtScript.BorderStyle = BorderStyle.None;
            txtScript.WordWrap = false;
            txtScript.ScrollBars = ScrollBars.Both;
            txtScript.Font = new Font(FontFamily.GenericMonospace, 10);
            txtScript.TextChanged += OnScriptSourceChanged;
            txtScript.KeyUp += OnScriptKeyUp;

            TabPage tabPage = new TabPage(strScriptName);
            tabPage.Controls.Add(txtScript);

            m_tbcScripts.TabPages.Add(tabPage);
            txtScript.Select();

            ScriptState scriptState = new ScriptState();
            scriptState.m_strFilename = strFilename;
            scriptState.m_bNew = true;
            scriptState.m_bNeedsSaving = false;
            scriptState.m_debugState = DebugState.Editor;
            txtScript.Tag = scriptState;
            m_tbcScripts.SelectedTab = tabPage;

            m_scriptHistoryManager.InitialiseHistory(strScriptName, "");

            UpdateInterface();

            // create standard template
            txtScript.Text = "/*\r\nTitle: New script\r\nCreated: " + DateTime.Now.ToString() + "\r\n*/\r\n\r\nfunction main() {\r\n\r\n\tPrint(\"Hello ScriptStack!\");\r\n\r\n}";
            txtScript.Select(0,0);

            return txtScript;
        }

        private void SaveScript(String strFilename)
        {
            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = (ScriptState)txtScript.Tag;

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(strFilename, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(txtScript.Text);
                streamWriter.Flush();
                fileStream.Close();

                scriptState.m_strFilename = strFilename;
                scriptState.m_bNew = false;
                scriptState.m_bNeedsSaving = false;
                txtScript.Tag = scriptState;

                String strScriptNameNew = new FileInfo(strFilename).Name;
                String strScriptNameOld = m_tbcScripts.SelectedTab.Text;
                m_tbcScripts.SelectedTab.Text = strScriptNameNew;

                m_scriptHistoryManager.RenameScript(
                    strScriptNameOld, strScriptNameNew);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this,
                    "Error while saving script. Reason: " + exception,
                    "Open Conscript Source",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Dispose();
            }
        }

        private void UpdateInterfaceMenu(bool bOpenScripts, DebugState debugState)
        {
            bool bDebugging = debugState == DebugState.Debugging;
            bool bActive = bDebugging
                || debugState == DebugState.Running;
            bool bEditor = debugState == DebugState.Editor;
            bool bStepping = debugState == DebugState.Suspended;
            String strScriptName = null;
            if (m_tbcScripts.SelectedTab != null)
                strScriptName = m_tbcScripts.SelectedTab.Text;

            m_mniFile.Enabled = !bActive;
            m_mniFileNew.Enabled = !bActive;
            m_mniFileOpen.Enabled = !bActive;
            m_mniFileClose.Enabled = bOpenScripts && !bActive;
            m_mniFileSave.Enabled = bOpenScripts && !bActive;
            m_mniFileSaveAs.Enabled = bOpenScripts && !bActive;

            m_mniEdit.Enabled = bOpenScripts && bEditor;
            m_mniBuild.Enabled = bOpenScripts;
            m_mniEditUndo.Enabled = bOpenScripts && !bActive
                && m_scriptHistoryManager.CanUndo(strScriptName);
            m_mniEditRedo.Enabled = bOpenScripts && !bActive
                && m_scriptHistoryManager.CanRedo(strScriptName);
            m_mniEditCut.Enabled = bOpenScripts && !bActive;
            m_mniEditCopy.Enabled = bOpenScripts && !bActive;
            m_mniEditPaste.Enabled = bOpenScripts && !bActive; // && Clipboard.ContainsText();

            m_mniBuild.Enabled = !bActive;
            m_mniBuildScript.Enabled = bOpenScripts && bEditor;
            m_mniBuildRebuild.Enabled = bOpenScripts && bEditor;
            m_mniBuildSettings.Enabled = !bActive;
            m_mniBuildHostEnvironment.Enabled = !bActive;

            m_mniDebug.Enabled = bOpenScripts;
            m_mniDebugStart.Enabled = !bActive;
            m_mniDebugStart.Text = bStepping ? "Continue" : "Start Debugging";
            m_mniDebugRun.Enabled = bEditor;
            m_mniDebugBreak.Enabled = bDebugging;
            m_mniDebugStop.Enabled = bActive || bStepping;
            m_mniDebugStepInto.Enabled = bEditor || bStepping;
            m_mniDebugStepOver.Enabled = bEditor || bStepping;
            m_mniDebugStepOut.Enabled = bEditor || bStepping;
            m_mniDebugToggleBreakpoint.Enabled = bOpenScripts;
            m_mniDebugDeleteAllBreakpoints.Enabled = bOpenScripts;
        }

        private void UpdateInterfaceByteCode()
        {
            m_lsbByteCode.Items.Clear();

            if (m_tbcScripts.TabCount == 0)
                return;

            ScriptState scriptState = GetCurrentScriptState();
            Script script = scriptState.m_script;
            if (script == null) 
                return;

            foreach (Instruction scriptInstruction in script.Executable.Runnable)
                m_lsbByteCode.Items.Add(scriptInstruction.ToString());

            m_lsbByteCode.ClearBreakpoints();
        }

        private void UpdateInterfaceVM()
        {
            if (m_tbcScripts.TabCount == 0)
                return;

            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = (ScriptState)txtScript.Tag;
            Script script = scriptState.m_script;
            if (script == null)
                return;

            TabPage tabPage = m_tbcVirtualMachine.SelectedTab;
            tabPage.SuspendLayout();

            // byte code
            m_lsbByteCode.Invalidate();

            // runtime information
            m_lsbCallStack.Items.Clear();
            m_lsbParameterStack.Items.Clear();

            if (scriptState.m_scriptContext != null)
            {
                
                Script scriptContext = scriptState.m_scriptContext.Script;
                //Interpreter scriptContext = scriptState.m_scriptContext;

                // global scope
                //m_vdtGlobal.BeginUpdate();
                m_vdtGlobal.VariableDictionary = scriptContext.Manager.SharedMemory;
                m_vdtGlobal.ExpandAll();
                //m_vdtGlobal.EndUpdate();

                // script scope
                //m_vdtScript.BeginUpdate();
                m_vdtScript.VariableDictionary = scriptContext.ScriptMemory;
                m_vdtScript.ExpandAll();
                //m_vdtScript.EndUpdate();

                // local scope
                //m_vdtLocal.BeginUpdate();
                m_vdtLocal.VariableDictionary = scriptState.m_scriptContext.LocalMemory;
                m_vdtLocal.ExpandAll();
                //m_vdtLocal.EndUpdate();

                // function stack
                foreach (Function scriptFunction in scriptState.m_scriptContext.FunctionStack)
                    m_lsbCallStack.Items.Add(scriptFunction == null ? "(unknown)" : scriptFunction.ToString());
                //m_lsbCallStack.Invalidate();

                // parameter stack
                foreach (object objectParameter in scriptState.m_scriptContext.ParameterStack)
                {
                    Type typeObject = objectParameter.GetType();
                    if (typeObject == typeof(String))
                        m_lsbParameterStack.Items.Add("\"" + objectParameter + "\"");
                    else
                        m_lsbParameterStack.Items.Add(objectParameter.ToString());
                }
                m_lsbParameterStack.Invalidate();

            }
            else
            {
                m_vdtGlobal.VariableDictionary = null;
                m_vdtScript.VariableDictionary = null;
                m_vdtLocal.VariableDictionary = null;
            }

            // locks
            m_lsbLocks.Items.Clear();
            ReadOnlyDictionary<object, Interpreter> dictLocks = m_scriptManager.ActiveLocks;
            foreach (object objectLock in dictLocks.Keys)
            {
                Interpreter scriptContext = (Interpreter)dictLocks[objectLock];
                StringBuilder stringBuilder = new StringBuilder();
                if (objectLock == null)
                    stringBuilder.Append("NULL");
                else if (objectLock.GetType() == typeof(String))
                {
                    stringBuilder.Append("\"");
                    stringBuilder.Append(objectLock.ToString());
                    stringBuilder.Append("\"");
                }
                else
                    stringBuilder.Append(objectLock.ToString());
                stringBuilder.Append(" <- Context(");
                stringBuilder.Append(scriptContext.Script.Name);
                stringBuilder.Append(")");
                m_lsbLocks.Items.Add(stringBuilder.ToString());
            }

            if (scriptState.m_debugState == DebugState.Editor)
            {
                m_lsbByteCode.NextInstruction = -1;
                m_lsbByteCode.SelectedIndex = -1;
            }

            tabPage.ResumeLayout();
        }

        private void UpdateInterface()
        {
            bool bOpenScripts = m_tbcScripts.TabPages.Count > 0;
            DebugState debugState = m_tbcScripts.TabCount == 0
                ? DebugState.Editor : GetCurrentScriptState().m_debugState;

            UpdateInterfaceMenu(bOpenScripts, debugState);
            UpdateInterfaceVM();

            m_tbcScripts.Enabled = debugState == DebugState.Editor;
        }

        private TextBox GetCurrentScript()
        {
            if (m_tbcScripts.TabPages.Count == 0) return null;
            TabPage tabPage = m_tbcScripts.SelectedTab;
            TextBox txtScript = (TextBox)tabPage.Controls[0];
            return txtScript;
        }

        private ScriptState GetCurrentScriptState()
        {
            TabPage tabPage = m_tbcScripts.SelectedTab;
            TextBox txtScript = (TextBox)tabPage.Controls[0];
            ScriptState scriptState = (ScriptState)txtScript.Tag;
            return scriptState;
        }

        private void ClearOutput()
        {
            m_listOutput.Clear();
            m_txtOutput.Text = "";
            m_txtOutput.Refresh();
        }

        private void WriteOutput(String strData)
        {
            m_listOutput.Add(strData);
            while (m_listOutput.Count > 1024)
                m_listOutput.RemoveAt(0);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (String strLine in m_listOutput)
            {
                stringBuilder.AppendLine(strLine);
            }

            m_txtOutput.SuspendLayout();
            m_txtOutput.Text = stringBuilder.ToString();
            m_txtOutput.SelectionStart = m_txtOutput.Text.Length;
            m_txtOutput.ScrollToCaret();
            m_txtOutput.ResumeLayout(false);
        }

        private void WriteStatusMessage(String strMessage)
        {
            m_tslMessage.Text = strMessage;
            m_stsStatus.Refresh();
        }

        private Script BuildScript(bool bForceRebuild)
        {
            if (m_tbcScripts.TabCount == 0) return null;

            ClearOutput();

            String strScriptName = m_tbcScripts.SelectedTab.Text;
            TextBox txtScript = GetCurrentScript();

            ScriptState scriptState = (ScriptState)txtScript.Tag;
            if (scriptState.m_debugState != DebugState.Editor) return null;

            if (!bForceRebuild && scriptState.m_script != null)
            {
                //WriteOutput("Script executable '" + strScriptName + "' is up to date.");
                return scriptState.m_script;
            }

            try
            {
                
                
                //WriteStatusMessage("Building script...");

                if (bForceRebuild)
                    WriteOutput("Rebuilding script '" + strScriptName + "'...");
                else
                    WriteOutput("Building script '" + strScriptName + "'...");

                //WriteOutput("Debug Mode             : " + (m_scriptManager.Debug ? "Yes" : "No"));
                //WriteOutput("Optimize Code          : " + (m_scriptManager.Optimize ? "Yes" : "No"));
                

                Script script = new Script(m_scriptManager, strScriptName);

                /*
                WriteOutput(
                    "----------------------------------------------------------------------------");
                WriteOutput("Functions Generated : " + script.Executable.Functions.Count);
                WriteOutput("Build Succeeded.");
                */

                scriptState.m_script = script;
                scriptState.m_scriptContext = null;
                txtScript.Tag = scriptState;

                UpdateInterfaceByteCode();

                //WriteStatusMessage("Ready");
                return script;
            }
            catch (Exception exception)
            {
                WriteOutput(exception.ToString());
                //WriteStatusMessage("Ready");
                return null;
            }
        }

        private Interpreter CreateScriptContext(Script script)
        {
            // cannot run script if no functions defined
            if (script.Functions.Count == 0)
            {
                MessageBox.Show(this, "No functions defined", "Run Script",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // automatically select main funcion if it has no parameters
            if (script.Executable.FunctionExists("main") && script.MainFunction.ParameterCount == 0)
                return new Interpreter(script);

            RunScriptForm runScriptForm = new RunScriptForm(script);
            if (runScriptForm.ShowDialog() == DialogResult.Cancel)
                return null;

            Function scriptFunction = runScriptForm.ScriptFunction;
            List<object> listParameters
                = new List<object>(runScriptForm.Parameters.Values);

            return new Interpreter(scriptFunction, listParameters);
        }

        public void RunScript(bool bDebug)
        {
            if (IsScriptActive()) return;

            ClearOutput();

            Script script = BuildScript(false);
            if (script == null)
            {
                UpdateInterface();
                return;
            }
            try
            {
                Interpreter scriptContextCurrent = CreateScriptContext(script);
                if (scriptContextCurrent == null) return;

                TextBox txtScript = GetCurrentScript();
                ScriptState scriptState = GetCurrentScriptState();
                scriptState.m_scriptContext = scriptContextCurrent;
                scriptState.m_debugState = bDebug
                    ? DebugState.Debugging : DebugState.Running;
                txtScript.Tag = scriptState;

                //WriteOutput("Running script " + script.Name + "....");
                m_tmrDebugger.Enabled = true;
                UpdateInterface();
                m_tbcVirtualMachine.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                WriteOutput(exception.ToString());
            }
        }

        public void ContinueScript()
        {
            if (m_tbcScripts.TabCount == 0) return;

            ScriptState scriptState = GetCurrentScriptState();
            if (scriptState.m_debugState != DebugState.Suspended) return;

            scriptState.m_debugState = DebugState.Debugging;
            TextBox txtScript = GetCurrentScript();
            txtScript.Tag = scriptState;
            m_tmrDebugger.Enabled = true;
            UpdateInterface();
            m_tbcVirtualMachine.SelectedIndex = 0;
        }

        private void OnScriptSourceChanged(object objectSender, EventArgs eventArgs)
        {
            // convert tabs to 4 spaces
            TextBox txtScript = (TextBox)objectSender;
            int iScrollPos = txtScript.SelectionStart;
            String strScript = txtScript.Text;
            int iScrollOffset = 0;
            if (iScrollPos > 0 && strScript[iScrollPos - 1] == '\t')
                iScrollOffset = 3;
            txtScript.Text = txtScript.Text.Replace("\t", "    ");
            txtScript.SelectionStart = iScrollPos + iScrollOffset;
            txtScript.ScrollToCaret();

            // invalidate compilation
            ScriptState scriptState = (ScriptState)txtScript.Tag;
            scriptState.m_bNeedsSaving = true;
            scriptState.m_script = null;
            scriptState.m_scriptContext = null;
            txtScript.Tag = scriptState;
            UpdateInterfaceByteCode();

            // clear active locks
            m_scriptManager.ClearActiveLocks();
            UpdateInterfaceVM();

            // track script history
            m_scriptHistoryManager.AddState(m_tbcScripts.SelectedTab.Text, txtScript.Text);

            UpdateInterface();

        }

        private void OnScriptKeyUp(object objectSender, KeyEventArgs keyEventArgs)
        {
            // handle cursor position info
            TextBox txtScript = (TextBox)objectSender;

            List<string> list = new List<string>();
            foreach (KeyValuePair<string, Routine> r in m_scriptManager.Routines)
            {
                list.Add(r.Key);
            }
            autocompleteMenu1.SetAutocompleteMenu(txtScript, autocompleteMenu1);
            autocompleteMenu1.Items = list.ToArray();

            // line number
            m_tslLineNumber.Text = "Line: " + txtScript.GetLineFromCharIndex(txtScript.SelectionStart);

            // char number
            int iCharPosition = txtScript.SelectionStart - txtScript.GetFirstCharIndexOfCurrentLine();
            m_tslCharNumber.Text = "Char: " + iCharPosition;

        }

        private void m_tmrDebugger_Tick(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0)
            {
                m_tmrDebugger.Enabled = false;
                UpdateInterface();
                return;
            }

            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = (ScriptState)txtScript.Tag;

            Interpreter scriptContextCurrent = scriptState.m_scriptContext;

            if (scriptContextCurrent.Finished)
            {
                m_tmrDebugger.Enabled = false;
                scriptState.m_debugState = DebugState.Editor;
                scriptState.m_scriptContext.Reset();
                txtScript.Tag = scriptState;
                UpdateInterface();
                //WriteOutput("Script terminated.");
                return;
            }

            try
            {
                if (scriptState.m_debugState == DebugState.Debugging)
                {
                    scriptContextCurrent.Interpret(1);
                    UpdateInterfaceVM();
                    m_lsbByteCode.NextInstruction = scriptContextCurrent.NextInstruction;

                    if (m_lsbByteCode.HasBreakPoint(scriptContextCurrent.NextInstruction))
                    {
                        m_tmrDebugger.Enabled = false;
                        scriptState.m_debugState = DebugState.Suspended;
                        txtScript.Tag = scriptState;
                        UpdateInterfaceVM();
                        m_lsbByteCode.SelectedIndex = m_lsbByteCode.NextInstruction;
                        UpdateInterface();
                        WriteOutput("Script interrupted.");
                        return;
                    }
                }
                else
                    scriptContextCurrent.Interpret(s_tsInterval);

            }
            catch (Exception exception)
            {
                m_tmrDebugger.Enabled = false;
                scriptState.m_debugState = DebugState.Editor;
                scriptState.m_scriptContext.Reset();
                txtScript.Tag = scriptState;
                UpdateInterface();
                WriteOutput("Runtime Error: " + exception);
            }
        }

        private void MainForm_Load(object objectSender, EventArgs eventArgs)
        {
            m_lsbByteCode.Font = new Font(FontFamily.GenericMonospace, 10);

            // set up script manager and custom loader
            m_scriptManager = new Manager();
            Scanner scriptLoaderIDE = new ScriptLoaderIDE(m_tbcScripts, m_scriptManager.Scanner, m_scriptManager);
            m_scriptManager.Scanner = scriptLoaderIDE;

            // script history manager
            m_scriptHistoryManager = new ScriptHistoryManager();

            // register default 'Print' hist function
            Routine hostFunctionPrototypePrint = new Routine(null, "Print", (Type)null, "Schreibe in die Debugger Console");
            m_scriptManager.Register(hostFunctionPrototypePrint, this);

            m_listOutput = new List<String>();

            //CreateScript("untitled0.script", "untitled0.script");
            TextBox txtScript = CreateScript("untitled0.script", "untitled0.script");
            
            // create standard template
            //txtScript.Text = "function main() {\r\n\r\n\t// Code goes here..\r\n\r\n}";
            //txtScript.Select(0,100); //25,19


            UpdateInterface();
        }

        private void MainForm_FormClosing(object objectSender,
            FormClosingEventArgs formClosingEventArgs)
        {
            foreach (TabPage tabPage in m_tbcScripts.TabPages)
            {
                TextBox txtScript = (TextBox)tabPage.Controls[0];
                ScriptState scriptState = (ScriptState)txtScript.Tag;
                if (scriptState.m_bNeedsSaving)
                {
                    String strScriptName = new FileInfo(scriptState.m_strFilename).Name;
                    if (MessageBox.Show(this, "Changes to the script '" + strScriptName
                        + "' will be lost. Do you want to proceed?", "Exit Debugger",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        formClosingEventArgs.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void m_tbcScripts_MouseDown(object objectSender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Right) return;
            m_cmsScript.Items[0].Text = "Save " + m_tbcScripts.SelectedTab.Text;
            m_cmsScript.Show(m_tbcScripts, mouseEventArgs.Location);
        }

        private void m_mniFileNew_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;
            String strScriptName = AllocateNewScriptName();
            TextBox txtScript = CreateScript(strScriptName, strScriptName);
            //txtScript.Text = "function main() {\r\n\r\n\t// Code goes here..\r\n\r\n}";
            //txtScript.Select(0,0); //25, 19
        }

        private void m_mniFileOpen_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Script Source";
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            foreach (String strFilename in openFileDialog.FileNames)
            {
                FileStream fileStream = null;
                try
                {
                    String strScriptName = new FileInfo(strFilename).Name;
                    if (ContainsScriptTab(strScriptName)) continue;
                    fileStream = new FileStream(strFilename, FileMode.Open);
                    StreamReader streamReader = new StreamReader(fileStream);
                    StringBuilder stringBuilder = new StringBuilder();
                    while (!streamReader.EndOfStream)
                    {
                        stringBuilder.Append(streamReader.ReadLine());
                        stringBuilder.Append("\r\n");
                    }
                    fileStream.Close();

                    TextBox txtScript = CreateScript(strScriptName, strFilename);
                    txtScript.Text = stringBuilder.ToString();

                    ScriptState scriptState = GetCurrentScriptState();
                    scriptState.m_bNew = false;
                    scriptState.m_bNeedsSaving = false;
                    txtScript.Tag = scriptState;

                    m_scriptHistoryManager.InitialiseHistory(
                        strScriptName, txtScript.Text);

                    UpdateInterface();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this,
                        "Error while loading script. Reason: " + exception,
                        "Open Source",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Dispose();
                }
            }
        }

        private void m_mniFileClose_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;

            int iSelectedTab = m_tbcScripts.SelectedIndex;
            if (iSelectedTab < 0) return;

            ScriptState scriptState = GetCurrentScriptState();
            String strScriptName = new FileInfo(scriptState.m_strFilename).Name;

            // warn user about saving
            if (scriptState.m_bNeedsSaving)
            {
                if (MessageBox.Show(this, "Changes to the script '" + strScriptName
                    + "' will be lost. Do you want to proceed?", "Close file",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            m_tbcScripts.TabPages.RemoveAt(iSelectedTab);

            m_scriptHistoryManager.ClearHistory(strScriptName);

            UpdateInterface();

            if (m_tbcScripts.TabPages.Count == 0) return;
            m_tbcScripts.SelectedIndex
                = Math.Min(m_tbcScripts.TabPages.Count - 1, iSelectedTab);
        }

        private void m_mniFileSave_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;
            if (IsScriptActive()) return;

            ScriptState scriptState = GetCurrentScriptState();
            if (scriptState.m_bNew)
                m_mniFileSaveAs_Click(objectSender, eventArgs);
            else
            {
                SaveScript(scriptState.m_strFilename);
            }
        }

        private void m_mniFileSaveAs_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;
            if (IsScriptActive()) return;

            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = GetCurrentScriptState();
            String strOldFilename = scriptState.m_strFilename;
            FileInfo fileInfo = new FileInfo(strOldFilename);
            String strScriptName = fileInfo.Name;
            String strDirectoryName = fileInfo.DirectoryName;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Source";
            saveFileDialog.Filter = "All Files|*.*";
            saveFileDialog.InitialDirectory = strDirectoryName;
            saveFileDialog.FileName = strScriptName;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            SaveScript(saveFileDialog.FileName);
        }

        private void m_mniEditUndo_Click(object objectSender, EventArgs eventArgs)
        {
            if (!IsScriptEditing()) return;
            String strScriptName = m_tbcScripts.SelectedTab.Text;
            if (!m_scriptHistoryManager.CanUndo(strScriptName)) return;

            TextBox txtScript = GetCurrentScript();

            txtScript.TextChanged -= OnScriptSourceChanged;
            String strSourceBefore = txtScript.Text;
            String strSourceAfter = m_scriptHistoryManager.Undo(strScriptName);
            txtScript.Text = strSourceAfter;
            txtScript.TextChanged += OnScriptSourceChanged;

            // set cursor at change position
            txtScript.SelectionStart
                = m_scriptHistoryManager.GetChangePosition(
                    strSourceBefore, strSourceAfter);

            txtScript.ScrollToCaret();

            UpdateInterface();
        }

        private void m_mniEditRedo_Click(object objectSender, EventArgs eventArgs)
        {
            if (!IsScriptEditing()) return;
            String strScriptName = m_tbcScripts.SelectedTab.Text;
            if (!m_scriptHistoryManager.CanRedo(strScriptName)) return;

            TextBox txtScript = GetCurrentScript();

            txtScript.TextChanged -= OnScriptSourceChanged;
            String strSourceBefore = txtScript.Text;
            String strSourceAfter = m_scriptHistoryManager.Redo(strScriptName);
            txtScript.Text = strSourceAfter;
            txtScript.TextChanged += OnScriptSourceChanged;

            // set cursor at change position
            txtScript.SelectionStart
                = m_scriptHistoryManager.GetChangePosition(
                    strSourceBefore, strSourceAfter);
            txtScript.ScrollToCaret();

            UpdateInterface();
        }

        private void m_mniEditCut_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;

            // copy to clipboard
            TextBox txtScript = GetCurrentScript();
            if (txtScript == null) return;
            if (txtScript.SelectedText == null) return;
            Clipboard.SetText(txtScript.SelectedText);

            // remove from source
            int iScrollPos = txtScript.SelectionStart;
            txtScript.Text = txtScript.Text.Remove(
                txtScript.SelectionStart, txtScript.SelectionLength);
            txtScript.SelectionStart = iScrollPos;
            txtScript.ScrollToCaret();

            // invalidate compilation
            ScriptState scriptState = (ScriptState)txtScript.Tag;
            scriptState.m_bNeedsSaving = true;
            scriptState.m_script = null;
            scriptState.m_scriptContext = null;
            txtScript.Tag = scriptState;
            UpdateInterfaceByteCode();

            // (script history tracked by script change event)

            UpdateInterface();
        }

        private void m_mniEditCopy_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive())
            {
                m_mniDebugStop_Click(objectSender, eventArgs);
                return;
            }

            // copy to clipboard
            TextBox txtScript = GetCurrentScript();
            if (txtScript == null) return;
            if (txtScript.SelectedText == null) return;
            if (txtScript.SelectedText.Length == 0) return;
            Clipboard.SetText(txtScript.SelectedText);

            // track script history
            m_scriptHistoryManager.AddState(
                m_tbcScripts.SelectedTab.Text, txtScript.Text);

            UpdateInterface();
        }

        private void m_mniEditPaste_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;

            TextBox txtScript = GetCurrentScript();
            if (txtScript == null) return;
            String strText = Clipboard.GetText();

            int iScrollPos = txtScript.SelectionStart;

            // first remove any currently selected text
            if (txtScript.SelectionLength > 0)
                txtScript.Text = txtScript.Text.Remove(
                    txtScript.SelectionStart, txtScript.SelectionLength);

            txtScript.Text = txtScript.Text.Insert(iScrollPos, strText);
            txtScript.SelectionStart = iScrollPos + strText.Length;
            txtScript.ScrollToCaret();

            // invalidate compilation
            ScriptState scriptState = (ScriptState)txtScript.Tag;
            scriptState.m_bNeedsSaving = true;
            scriptState.m_script = null;
            scriptState.m_scriptContext = null;
            txtScript.Tag = scriptState;
            UpdateInterfaceByteCode();

            // (script history tracked by script change event)

            UpdateInterface();
        }

        private void m_mniEditDelete_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;

            TextBox txtScript = GetCurrentScript();
            if (txtScript == null) return;
            if (txtScript.SelectedText == null) return;

            // remove from source
            int iScrollPos = txtScript.SelectionStart;
            txtScript.Text = txtScript.Text.Remove(
                txtScript.SelectionStart, txtScript.SelectionLength);
            txtScript.SelectionStart = iScrollPos;
            txtScript.ScrollToCaret();

            // invalidate compilation
            ScriptState scriptState = (ScriptState)txtScript.Tag;
            scriptState.m_bNeedsSaving = true;
            scriptState.m_script = null;
            scriptState.m_scriptContext = null;
            txtScript.Tag = scriptState;
            UpdateInterfaceByteCode();

            // track script history
            m_scriptHistoryManager.AddState(
                m_tbcScripts.SelectedTab.Text, txtScript.Text);

            UpdateInterface();
        }

        private void m_mniEditSelectAll_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;
            TextBox txtScript = GetCurrentScript();
            if (txtScript == null) return;
            txtScript.SelectAll();
        }

        private void m_mniBuildScript_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;
            if (IsScriptActive()) return;

            ScriptState scriptState = GetCurrentScriptState();
            //ClearOutput();
            BuildScript(false);
            UpdateInterface();
        }

        private void m_mniBuildRebuild_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;
            if (IsScriptActive()) return;

            ScriptState scriptState = GetCurrentScriptState();
            //ClearOutput();
            BuildScript(true);
            UpdateInterface();
        }

        private void m_mniBuildSettings_Click(object objectSender, EventArgs eventArgs)
        {
            BuildSettingsForm buildSettingsForm = new BuildSettingsForm();
            buildSettingsForm.DebugMode = m_scriptManager.Debug;
            buildSettingsForm.OptimiseCode = m_scriptManager.Optimize;
            buildSettingsForm.DebuggerTimerIntervalMs = m_tmrDebugger.Interval;
            if (buildSettingsForm.ShowDialog(this) == DialogResult.Cancel) return;
            m_scriptManager.Debug = buildSettingsForm.DebugMode;
            m_scriptManager.Optimize = buildSettingsForm.OptimiseCode;
            m_tmrDebugger.Interval = buildSettingsForm.DebuggerTimerIntervalMs;
        }

        private void m_mniBuildHostEnvironment_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptActive()) return;

            PluginLoaderForm hostEnvironmentForm = new PluginLoaderForm(m_scriptManager);
            hostEnvironmentForm.ShowDialog(this);
        }

        private void m_mniDebugStart_Click(object objectSender, EventArgs eventArgs)
        {
            if (IsScriptSuspended())
                ContinueScript();
            else
                RunScript(true);
        }

        private void m_mniDebugRun_Click(object objectSender, EventArgs eventArgs)
        {
            RunScript(false);
        }

        private void m_mniDebugBreak_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;
            ScriptState scriptState = GetCurrentScriptState();
            if (scriptState.m_debugState != DebugState.Debugging) return;

            TextBox txtScript = GetCurrentScript();

            m_tmrDebugger.Enabled = false;
            scriptState.m_debugState = DebugState.Suspended;
            txtScript.Tag = scriptState;
            m_lsbByteCode.SelectedIndex = m_lsbByteCode.NextInstruction;
            UpdateInterface();
            WriteOutput("Script interrupted.");
            return;
        }

        private void m_mniDebugStop_Click(object objectSender, EventArgs eventArgs)
        {
            if (!IsScriptActive()) return;

            m_tmrDebugger.Enabled = false;
            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = GetCurrentScriptState();
            scriptState.m_scriptContext.Reset();
            scriptState.m_debugState = DebugState.Editor;
            txtScript.Tag = scriptState;
            UpdateInterface();
            WriteOutput("Script terminated.");
        }

        private void m_mniDebugStepInto_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;

            bool bSuspended = IsScriptSuspended();
            bool bEditor = IsScriptEditing();

            if (!bSuspended && !bEditor) return;

            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = (ScriptState)txtScript.Tag;

            if (bEditor)
            {
                BuildScript(false);
                scriptState = (ScriptState)txtScript.Tag;
                if (scriptState.m_script == null) return;
                scriptState.m_debugState = DebugState.Suspended;
                Interpreter scriptContextCurrent = CreateScriptContext(scriptState.m_script);
                if (scriptContextCurrent == null) return;
                scriptState.m_scriptContext = scriptContextCurrent;
                txtScript.Tag = scriptState;
            }
            else
            {
                try
                {
                    scriptState.m_scriptContext.Interpret(1);

                    // check for end of script
                    if (scriptState.m_scriptContext.Finished)
                    {
                        m_tmrDebugger.Enabled = false;
                        scriptState.m_debugState = DebugState.Editor;
                        scriptState.m_scriptContext.Reset();
                        txtScript.Tag = scriptState;
                        UpdateInterface();
                        m_tbcVirtualMachine.SelectedIndex = 0;
                        return;
                    }
                }
                catch (Exception exception)
                {
                    m_tmrDebugger.Enabled = false;
                    scriptState.m_debugState = DebugState.Editor;
                    scriptState.m_scriptContext.Reset();
                    txtScript.Tag = scriptState;
                    UpdateInterface();
                    WriteOutput("Runtime Error: " + exception);
                    return;
                }
            }

            m_lsbByteCode.NextInstruction = scriptState.m_scriptContext.NextInstruction;
            m_lsbByteCode.SelectedIndex = m_lsbByteCode.NextInstruction;
            UpdateInterface();
        }

        private void m_mniDebugStepOver_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;

            bool bSuspended = IsScriptSuspended();
            bool bEditor = IsScriptEditing();

            if (!bSuspended && !bEditor) return;

            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = (ScriptState)txtScript.Tag;

            if (bEditor)
            {
                BuildScript(false);
                scriptState = (ScriptState)txtScript.Tag;
                if (scriptState.m_script == null) return;
                scriptState.m_debugState = DebugState.Suspended;
                Interpreter scriptContextCurrent = CreateScriptContext(scriptState.m_script);
                if (scriptContextCurrent == null) return;
                scriptState.m_scriptContext = scriptContextCurrent;
                txtScript.Tag = scriptState;
                m_tbcVirtualMachine.SelectedIndex = 0;
            }
            else
            {
                Interpreter scriptContext = scriptState.m_scriptContext;
                Script script = scriptContext.Script;
                int iNextInstruction = scriptContext.NextInstruction;
                //ScriptInstrustion scriptInstruction = script.Instructions[iNextInstruction];
                Instruction scriptInstruction = script.Executable.Runnable[iNextInstruction]; //Instructions[iNextInstruction];

                try
                {
                    if (scriptInstruction.OpCode != OpCode.CALL)
                        scriptContext.Interpret(1);
                    else
                    {
                        ++iNextInstruction;
                        int iStackDepth = scriptContext.FunctionStack.Count;
                        while (scriptContext.NextInstruction != iNextInstruction
                            || iStackDepth != scriptContext.FunctionStack.Count)
                            scriptContext.Interpret(1);
                    }

                    // check for end of script
                    if (scriptContext.Finished)
                    {
                        m_tmrDebugger.Enabled = false;
                        scriptState.m_debugState = DebugState.Editor;
                        scriptState.m_scriptContext.Reset();
                        txtScript.Tag = scriptState;
                        UpdateInterface();
                        return;
                    }
                }
                catch (Exception exception)
                {
                    m_tmrDebugger.Enabled = false;
                    scriptState.m_debugState = DebugState.Editor;
                    scriptState.m_scriptContext.Reset();
                    txtScript.Tag = scriptState;
                    UpdateInterface();
                    WriteOutput("Runtime Error: " + exception);
                    return;
                }
            }

            m_lsbByteCode.NextInstruction = scriptState.m_scriptContext.NextInstruction;
            m_lsbByteCode.SelectedIndex = m_lsbByteCode.NextInstruction;
            UpdateInterface();
        }

        private void m_mniDebugStepOut_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;

            bool bSuspended = IsScriptSuspended();
            bool bEditor = IsScriptEditing();

            if (!bSuspended && !bEditor) return;

            TextBox txtScript = GetCurrentScript();
            ScriptState scriptState = (ScriptState)txtScript.Tag;

            if (bEditor)
            {
                BuildScript(false);
                scriptState = (ScriptState)txtScript.Tag;
                if (scriptState.m_script == null) return;
                scriptState.m_debugState = DebugState.Suspended;
                Interpreter scriptContextCurrent = CreateScriptContext(scriptState.m_script);
                if (scriptContextCurrent == null) return;
                scriptState.m_scriptContext = scriptContextCurrent;
                txtScript.Tag = scriptState;
                m_tbcVirtualMachine.SelectedIndex = 0;
            }
            else
            {
                Interpreter scriptContext = scriptState.m_scriptContext;
                Script script = scriptContext.Script;
                int iNextInstruction = scriptContext.NextInstruction;
                Instruction scriptInstruction = script.Executable.Runnable[iNextInstruction];

                try
                {
                    int iStackDepth = scriptContext.FunctionStack.Count;
                    if (iStackDepth == 1)
                        scriptContext.Interpret(1);
                    else
                        while (scriptContext.FunctionStack.Count >= iStackDepth)
                            scriptContext.Interpret(1);

                    // check for end of script
                    if (scriptContext.Finished)
                    {
                        m_tmrDebugger.Enabled = false;
                        scriptState.m_debugState = DebugState.Editor;
                        scriptState.m_scriptContext.Reset();
                        txtScript.Tag = scriptState;
                        UpdateInterface();
                        return;
                    }
                }
                catch (Exception exception)
                {
                    m_tmrDebugger.Enabled = false;
                    scriptState.m_debugState = DebugState.Editor;
                    scriptState.m_scriptContext.Reset();
                    txtScript.Tag = scriptState;
                    UpdateInterface();
                    WriteOutput("Runtime Error: " + exception);
                    return;
                }
            }

            m_lsbByteCode.NextInstruction = scriptState.m_scriptContext.NextInstruction;
            m_lsbByteCode.SelectedIndex = m_lsbByteCode.NextInstruction;
            UpdateInterface();
        }

        private void m_mniDebugToggleBreakpoint_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;

            m_lsbByteCode.ToggleBreakpoint();
        }

        private void m_mniDebugDeleteAllBreakpoints_Click(object objectSender, EventArgs eventArgs)
        {
            if (m_tbcScripts.TabCount == 0) return;

            m_lsbByteCode.ClearBreakpoints();
        }

        private void m_mniHelpAbout_Click(object objectSender, EventArgs eventArgs)
        {
            new AboutBox().ShowDialog(this);
        }

        private void m_tbcScripts_SelectedIndexChanged(object objectSender, EventArgs eventArgs)
        {
            UpdateInterface();
            UpdateInterfaceByteCode();
        }

        #endregion

        #region Public Methods

        public Debugger()
        {
            InitializeComponent();
        }

        public object Invoke(String strFunctionName, List<object> listParameters) {
            if (strFunctionName == "Print") {
                WriteOutput(listParameters[0].ToString());
            }
            return null;
        }

        #endregion
    }

}


