namespace IDE
{
    partial class Debugger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            m_spcHorizontal = new SplitContainer();
            m_spcVertical = new SplitContainer();
            m_grpScripts = new Panel();
            m_tbcScripts = new TabControl();
            m_cmsScript = new ContextMenuStrip(components);
            m_tmiScriptSave = new ToolStripMenuItem();
            m_tmiScriptClose = new ToolStripMenuItem();
            m_grpVirtualMachine = new Panel();
            m_tbcVirtualMachine = new TabControl();
            m_tbpByteCode = new TabPage();
            m_lsbByteCode = new ByteCodeListBox(components);
            m_tbpScopeGlobal = new TabPage();
            m_vdtGlobal = new VariableDictionaryTreeView();
            m_tbpScopeScript = new TabPage();
            m_vdtScript = new VariableDictionaryTreeView();
            m_tbpScopeLocal = new TabPage();
            m_vdtLocal = new VariableDictionaryTreeView();
            m_grpOutput = new GroupBox();
            m_stsStatus = new StatusStrip();
            m_tslMessage = new ToolStripStatusLabel();
            m_tslLineNumber = new ToolStripStatusLabel();
            m_tslCharNumber = new ToolStripStatusLabel();
            m_txtOutput = new TextBox();
            m_tbpCallStack = new TabPage();
            m_lsbCallStack = new ListBox();
            m_tbpParameterStack = new TabPage();
            m_lsbParameterStack = new ListBox();
            m_tbpLocks = new TabPage();
            m_lsbLocks = new ListBox();
            m_mnsMain = new MenuStrip();
            m_mniFile = new ToolStripMenuItem();
            m_mniFileNew = new ToolStripMenuItem();
            m_mniFileOpen = new ToolStripMenuItem();
            m_mniFileClose = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            m_mniFileSave = new ToolStripMenuItem();
            m_mniFileSaveAs = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            m_mniBuild = new ToolStripMenuItem();
            m_mniBuildScript = new ToolStripMenuItem();
            m_mniBuildRebuild = new ToolStripMenuItem();
            m_mniBuildSettings = new ToolStripMenuItem();
            m_mniBuildHostEnvironment = new ToolStripMenuItem();
            m_mniDebug = new ToolStripMenuItem();
            m_mniDebugStart = new ToolStripMenuItem();
            m_mniDebugRun = new ToolStripMenuItem();
            m_mniDebugBreak = new ToolStripMenuItem();
            m_mniDebugStop = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            m_mniDebugStepInto = new ToolStripMenuItem();
            m_mniDebugStepOver = new ToolStripMenuItem();
            m_mniDebugStepOut = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            m_mniDebugToggleBreakpoint = new ToolStripMenuItem();
            m_mniDebugDeleteAllBreakpoints = new ToolStripMenuItem();
            m_mniHelp = new ToolStripMenuItem();
            m_mniHelpAbout = new ToolStripMenuItem();
            m_mniEdit = new ToolStripMenuItem();
            m_mniEditUndo = new ToolStripMenuItem();
            m_mniEditRedo = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            m_mniEditCut = new ToolStripMenuItem();
            m_mniEditCopy = new ToolStripMenuItem();
            m_mniEditPaste = new ToolStripMenuItem();
            m_mniEditDelete = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            m_mniEditSelectAll = new ToolStripMenuItem();
            m_tmrDebugger = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)m_spcHorizontal).BeginInit();
            m_spcHorizontal.Panel1.SuspendLayout();
            m_spcHorizontal.Panel2.SuspendLayout();
            m_spcHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_spcVertical).BeginInit();
            m_spcVertical.Panel1.SuspendLayout();
            m_spcVertical.Panel2.SuspendLayout();
            m_spcVertical.SuspendLayout();
            m_grpScripts.SuspendLayout();
            m_cmsScript.SuspendLayout();
            m_grpVirtualMachine.SuspendLayout();
            m_tbcVirtualMachine.SuspendLayout();
            m_tbpByteCode.SuspendLayout();
            m_tbpScopeGlobal.SuspendLayout();
            m_tbpScopeScript.SuspendLayout();
            m_tbpScopeLocal.SuspendLayout();
            m_grpOutput.SuspendLayout();
            m_stsStatus.SuspendLayout();
            m_tbpCallStack.SuspendLayout();
            m_tbpParameterStack.SuspendLayout();
            m_tbpLocks.SuspendLayout();
            m_mnsMain.SuspendLayout();
            SuspendLayout();
            // 
            // m_spcHorizontal
            // 
            m_spcHorizontal.Dock = DockStyle.Fill;
            m_spcHorizontal.Location = new Point(0, 24);
            m_spcHorizontal.Margin = new Padding(4, 3, 4, 3);
            m_spcHorizontal.Name = "m_spcHorizontal";
            m_spcHorizontal.Orientation = Orientation.Horizontal;
            // 
            // m_spcHorizontal.Panel1
            // 
            m_spcHorizontal.Panel1.Controls.Add(m_spcVertical);
            // 
            // m_spcHorizontal.Panel2
            // 
            m_spcHorizontal.Panel2.Controls.Add(m_grpOutput);
            m_spcHorizontal.Size = new Size(910, 627);
            m_spcHorizontal.SplitterDistance = 499;
            m_spcHorizontal.SplitterWidth = 5;
            m_spcHorizontal.TabIndex = 1;
            // 
            // m_spcVertical
            // 
            m_spcVertical.Dock = DockStyle.Fill;
            m_spcVertical.Location = new Point(0, 0);
            m_spcVertical.Margin = new Padding(4, 3, 4, 3);
            m_spcVertical.Name = "m_spcVertical";
            // 
            // m_spcVertical.Panel1
            // 
            m_spcVertical.Panel1.Controls.Add(m_grpScripts);
            // 
            // m_spcVertical.Panel2
            // 
            m_spcVertical.Panel2.Controls.Add(m_grpVirtualMachine);
            m_spcVertical.Size = new Size(910, 499);
            m_spcVertical.SplitterDistance = 579;
            m_spcVertical.SplitterWidth = 5;
            m_spcVertical.TabIndex = 3;
            // 
            // m_grpScripts
            // 
            m_grpScripts.Controls.Add(m_tbcScripts);
            m_grpScripts.Dock = DockStyle.Fill;
            m_grpScripts.Location = new Point(0, 0);
            m_grpScripts.Margin = new Padding(4, 3, 4, 3);
            m_grpScripts.Name = "m_grpScripts";
            m_grpScripts.Size = new Size(579, 499);
            m_grpScripts.TabIndex = 2;
            m_grpScripts.Text = "Codebox";
            // 
            // m_tbcScripts
            // 
            m_tbcScripts.ContextMenuStrip = m_cmsScript;
            m_tbcScripts.Dock = DockStyle.Fill;
            m_tbcScripts.HotTrack = true;
            m_tbcScripts.Location = new Point(0, 0);
            m_tbcScripts.Margin = new Padding(4, 3, 4, 3);
            m_tbcScripts.Name = "m_tbcScripts";
            m_tbcScripts.SelectedIndex = 0;
            m_tbcScripts.Size = new Size(579, 499);
            m_tbcScripts.TabIndex = 1;
            m_tbcScripts.SelectedIndexChanged += m_tbcScripts_SelectedIndexChanged;
            m_tbcScripts.MouseDown += m_tbcScripts_MouseDown;
            // 
            // m_cmsScript
            // 
            m_cmsScript.Items.AddRange(new ToolStripItem[] { m_tmiScriptSave, m_tmiScriptClose });
            m_cmsScript.Name = "m_cmsScript";
            m_cmsScript.Size = new Size(129, 48);
            // 
            // m_tmiScriptSave
            // 
            m_tmiScriptSave.Name = "m_tmiScriptSave";
            m_tmiScriptSave.Size = new Size(128, 22);
            m_tmiScriptSave.Text = "Speichern";
            m_tmiScriptSave.Click += m_mniFileSave_Click;
            // 
            // m_tmiScriptClose
            // 
            m_tmiScriptClose.Name = "m_tmiScriptClose";
            m_tmiScriptClose.Size = new Size(128, 22);
            m_tmiScriptClose.Text = "Schliessen";
            m_tmiScriptClose.Click += m_mniFileClose_Click;
            // 
            // m_grpVirtualMachine
            // 
            m_grpVirtualMachine.Controls.Add(m_tbcVirtualMachine);
            m_grpVirtualMachine.Dock = DockStyle.Fill;
            m_grpVirtualMachine.Location = new Point(0, 0);
            m_grpVirtualMachine.Margin = new Padding(4, 3, 4, 3);
            m_grpVirtualMachine.Name = "m_grpVirtualMachine";
            m_grpVirtualMachine.Size = new Size(326, 499);
            m_grpVirtualMachine.TabIndex = 0;
            m_grpVirtualMachine.Text = "Debugger / virtuelle Umgebung";
            // 
            // m_tbcVirtualMachine
            // 
            m_tbcVirtualMachine.Controls.Add(m_tbpByteCode);
            m_tbcVirtualMachine.Controls.Add(m_tbpScopeGlobal);
            m_tbcVirtualMachine.Controls.Add(m_tbpScopeScript);
            m_tbcVirtualMachine.Controls.Add(m_tbpScopeLocal);
            m_tbcVirtualMachine.Dock = DockStyle.Fill;
            m_tbcVirtualMachine.Location = new Point(0, 0);
            m_tbcVirtualMachine.Margin = new Padding(4, 3, 4, 3);
            m_tbcVirtualMachine.Name = "m_tbcVirtualMachine";
            m_tbcVirtualMachine.SelectedIndex = 0;
            m_tbcVirtualMachine.Size = new Size(326, 499);
            m_tbcVirtualMachine.TabIndex = 0;
            // 
            // m_tbpByteCode
            // 
            m_tbpByteCode.Controls.Add(m_lsbByteCode);
            m_tbpByteCode.Location = new Point(4, 24);
            m_tbpByteCode.Margin = new Padding(4, 3, 4, 3);
            m_tbpByteCode.Name = "m_tbpByteCode";
            m_tbpByteCode.Size = new Size(318, 471);
            m_tbpByteCode.TabIndex = 4;
            m_tbpByteCode.Text = "Instruktionen";
            m_tbpByteCode.UseVisualStyleBackColor = true;
            // 
            // m_lsbByteCode
            // 
            m_lsbByteCode.BorderStyle = BorderStyle.None;
            m_lsbByteCode.Dock = DockStyle.Fill;
            m_lsbByteCode.DrawMode = DrawMode.OwnerDrawFixed;
            m_lsbByteCode.Font = new Font("Courier New", 8F, FontStyle.Regular, GraphicsUnit.Point);
            m_lsbByteCode.FormattingEnabled = true;
            m_lsbByteCode.IntegralHeight = false;
            m_lsbByteCode.ItemHeight = 16;
            m_lsbByteCode.Location = new Point(0, 0);
            m_lsbByteCode.Margin = new Padding(4, 3, 4, 3);
            m_lsbByteCode.Name = "m_lsbByteCode";
            m_lsbByteCode.NextInstruction = 0;
            m_lsbByteCode.Size = new Size(318, 471);
            m_lsbByteCode.TabIndex = 1;
            // 
            // m_tbpScopeGlobal
            // 
            m_tbpScopeGlobal.Controls.Add(m_vdtGlobal);
            m_tbpScopeGlobal.Location = new Point(4, 24);
            m_tbpScopeGlobal.Margin = new Padding(4, 3, 4, 3);
            m_tbpScopeGlobal.Name = "m_tbpScopeGlobal";
            m_tbpScopeGlobal.Padding = new Padding(4, 3, 4, 3);
            m_tbpScopeGlobal.Size = new Size(318, 471);
            m_tbpScopeGlobal.TabIndex = 0;
            m_tbpScopeGlobal.Text = "Globaler Bereich";
            m_tbpScopeGlobal.UseVisualStyleBackColor = true;
            // 
            // m_vdtGlobal
            // 
            m_vdtGlobal.BorderStyle = BorderStyle.None;
            m_vdtGlobal.Dock = DockStyle.Fill;
            m_vdtGlobal.DrawMode = TreeViewDrawMode.OwnerDrawText;
            m_vdtGlobal.Location = new Point(4, 3);
            m_vdtGlobal.Margin = new Padding(4, 3, 4, 3);
            m_vdtGlobal.Name = "m_vdtGlobal";
            m_vdtGlobal.Size = new Size(310, 465);
            m_vdtGlobal.TabIndex = 0;
            m_vdtGlobal.VariableDictionary = null;
            // 
            // m_tbpScopeScript
            // 
            m_tbpScopeScript.Controls.Add(m_vdtScript);
            m_tbpScopeScript.Location = new Point(4, 24);
            m_tbpScopeScript.Margin = new Padding(4, 3, 4, 3);
            m_tbpScopeScript.Name = "m_tbpScopeScript";
            m_tbpScopeScript.Padding = new Padding(4, 3, 4, 3);
            m_tbpScopeScript.Size = new Size(318, 471);
            m_tbpScopeScript.TabIndex = 1;
            m_tbpScopeScript.Text = "Script Bereich";
            m_tbpScopeScript.UseVisualStyleBackColor = true;
            // 
            // m_vdtScript
            // 
            m_vdtScript.BorderStyle = BorderStyle.None;
            m_vdtScript.Dock = DockStyle.Fill;
            m_vdtScript.DrawMode = TreeViewDrawMode.OwnerDrawText;
            m_vdtScript.Location = new Point(4, 3);
            m_vdtScript.Margin = new Padding(4, 3, 4, 3);
            m_vdtScript.Name = "m_vdtScript";
            m_vdtScript.Size = new Size(310, 465);
            m_vdtScript.TabIndex = 0;
            m_vdtScript.VariableDictionary = null;
            // 
            // m_tbpScopeLocal
            // 
            m_tbpScopeLocal.Controls.Add(m_vdtLocal);
            m_tbpScopeLocal.Location = new Point(4, 24);
            m_tbpScopeLocal.Margin = new Padding(4, 3, 4, 3);
            m_tbpScopeLocal.Name = "m_tbpScopeLocal";
            m_tbpScopeLocal.Padding = new Padding(4, 3, 4, 3);
            m_tbpScopeLocal.Size = new Size(318, 471);
            m_tbpScopeLocal.TabIndex = 2;
            m_tbpScopeLocal.Text = "Lokale Variablen";
            m_tbpScopeLocal.UseVisualStyleBackColor = true;
            // 
            // m_vdtLocal
            // 
            m_vdtLocal.BorderStyle = BorderStyle.None;
            m_vdtLocal.Dock = DockStyle.Fill;
            m_vdtLocal.DrawMode = TreeViewDrawMode.OwnerDrawText;
            m_vdtLocal.Location = new Point(4, 3);
            m_vdtLocal.Margin = new Padding(4, 3, 4, 3);
            m_vdtLocal.Name = "m_vdtLocal";
            m_vdtLocal.Size = new Size(310, 465);
            m_vdtLocal.TabIndex = 0;
            m_vdtLocal.VariableDictionary = null;
            // 
            // m_grpOutput
            // 
            m_grpOutput.Controls.Add(m_stsStatus);
            m_grpOutput.Controls.Add(m_txtOutput);
            m_grpOutput.Dock = DockStyle.Fill;
            m_grpOutput.Location = new Point(0, 0);
            m_grpOutput.Margin = new Padding(4, 3, 4, 3);
            m_grpOutput.Name = "m_grpOutput";
            m_grpOutput.Padding = new Padding(4, 3, 4, 3);
            m_grpOutput.Size = new Size(910, 123);
            m_grpOutput.TabIndex = 2;
            m_grpOutput.TabStop = false;
            m_grpOutput.Text = "Ausgabe";
            // 
            // m_stsStatus
            // 
            m_stsStatus.Items.AddRange(new ToolStripItem[] { m_tslMessage, m_tslLineNumber, m_tslCharNumber });
            m_stsStatus.Location = new Point(4, 98);
            m_stsStatus.Name = "m_stsStatus";
            m_stsStatus.Padding = new Padding(1, 0, 16, 0);
            m_stsStatus.Size = new Size(902, 22);
            m_stsStatus.TabIndex = 2;
            m_stsStatus.Text = "Status Strip";
            // 
            // m_tslMessage
            // 
            m_tslMessage.AutoSize = false;
            m_tslMessage.Name = "m_tslMessage";
            m_tslMessage.Size = new Size(757, 17);
            m_tslMessage.Spring = true;
            m_tslMessage.Text = "Ready";
            m_tslMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // m_tslLineNumber
            // 
            m_tslLineNumber.AutoSize = false;
            m_tslLineNumber.Name = "m_tslLineNumber";
            m_tslLineNumber.Size = new Size(64, 17);
            m_tslLineNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // m_tslCharNumber
            // 
            m_tslCharNumber.AutoSize = false;
            m_tslCharNumber.Name = "m_tslCharNumber";
            m_tslCharNumber.Size = new Size(64, 17);
            m_tslCharNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // m_txtOutput
            // 
            m_txtOutput.AcceptsReturn = true;
            m_txtOutput.AcceptsTab = true;
            m_txtOutput.Dock = DockStyle.Fill;
            m_txtOutput.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            m_txtOutput.Location = new Point(4, 19);
            m_txtOutput.Margin = new Padding(4, 3, 4, 3);
            m_txtOutput.Multiline = true;
            m_txtOutput.Name = "m_txtOutput";
            m_txtOutput.ReadOnly = true;
            m_txtOutput.ScrollBars = ScrollBars.Both;
            m_txtOutput.Size = new Size(902, 101);
            m_txtOutput.TabIndex = 1;
            // 
            // m_tbpCallStack
            // 
            m_tbpCallStack.Controls.Add(m_lsbCallStack);
            m_tbpCallStack.Location = new Point(4, 22);
            m_tbpCallStack.Name = "m_tbpCallStack";
            m_tbpCallStack.Size = new Size(271, 404);
            m_tbpCallStack.TabIndex = 6;
            m_tbpCallStack.Text = "Call Stack";
            m_tbpCallStack.UseVisualStyleBackColor = true;
            // 
            // m_lsbCallStack
            // 
            m_lsbCallStack.BorderStyle = BorderStyle.None;
            m_lsbCallStack.Dock = DockStyle.Fill;
            m_lsbCallStack.FormattingEnabled = true;
            m_lsbCallStack.IntegralHeight = false;
            m_lsbCallStack.Location = new Point(0, 0);
            m_lsbCallStack.Name = "m_lsbCallStack";
            m_lsbCallStack.Size = new Size(271, 404);
            m_lsbCallStack.TabIndex = 0;
            // 
            // m_tbpParameterStack
            // 
            m_tbpParameterStack.Controls.Add(m_lsbParameterStack);
            m_tbpParameterStack.Location = new Point(4, 22);
            m_tbpParameterStack.Name = "m_tbpParameterStack";
            m_tbpParameterStack.Size = new Size(266, 385);
            m_tbpParameterStack.TabIndex = 5;
            m_tbpParameterStack.Text = "Parameter Stack";
            m_tbpParameterStack.UseVisualStyleBackColor = true;
            // 
            // m_lsbParameterStack
            // 
            m_lsbParameterStack.BorderStyle = BorderStyle.None;
            m_lsbParameterStack.Dock = DockStyle.Fill;
            m_lsbParameterStack.FormattingEnabled = true;
            m_lsbParameterStack.IntegralHeight = false;
            m_lsbParameterStack.Location = new Point(0, 0);
            m_lsbParameterStack.Name = "m_lsbParameterStack";
            m_lsbParameterStack.Size = new Size(266, 385);
            m_lsbParameterStack.TabIndex = 0;
            // 
            // m_tbpLocks
            // 
            m_tbpLocks.Controls.Add(m_lsbLocks);
            m_tbpLocks.Location = new Point(4, 22);
            m_tbpLocks.Name = "m_tbpLocks";
            m_tbpLocks.Size = new Size(266, 385);
            m_tbpLocks.TabIndex = 3;
            m_tbpLocks.Text = "Locks";
            m_tbpLocks.UseVisualStyleBackColor = true;
            // 
            // m_lsbLocks
            // 
            m_lsbLocks.BorderStyle = BorderStyle.None;
            m_lsbLocks.Dock = DockStyle.Fill;
            m_lsbLocks.FormattingEnabled = true;
            m_lsbLocks.IntegralHeight = false;
            m_lsbLocks.Location = new Point(0, 0);
            m_lsbLocks.Name = "m_lsbLocks";
            m_lsbLocks.Size = new Size(266, 385);
            m_lsbLocks.TabIndex = 0;
            // 
            // m_mnsMain
            // 
            m_mnsMain.Items.AddRange(new ToolStripItem[] { m_mniFile, m_mniBuild, m_mniDebug, m_mniHelp });
            m_mnsMain.Location = new Point(0, 0);
            m_mnsMain.Name = "m_mnsMain";
            m_mnsMain.Padding = new Padding(7, 2, 0, 2);
            m_mnsMain.Size = new Size(910, 24);
            m_mnsMain.TabIndex = 2;
            m_mnsMain.Text = "menuStrip1";
            // 
            // m_mniFile
            // 
            m_mniFile.DropDownItems.AddRange(new ToolStripItem[] { m_mniFileNew, m_mniFileOpen, m_mniFileClose, toolStripSeparator1, m_mniFileSave, m_mniFileSaveAs, toolStripSeparator2, exitToolStripMenuItem });
            m_mniFile.Name = "m_mniFile";
            m_mniFile.Size = new Size(46, 20);
            m_mniFile.Text = "&Datei";
            // 
            // m_mniFileNew
            // 
            m_mniFileNew.Name = "m_mniFileNew";
            m_mniFileNew.ShortcutKeys = Keys.Control | Keys.N;
            m_mniFileNew.Size = new Size(176, 22);
            m_mniFileNew.Text = "&Neu";
            m_mniFileNew.Click += m_mniFileNew_Click;
            // 
            // m_mniFileOpen
            // 
            m_mniFileOpen.Name = "m_mniFileOpen";
            m_mniFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            m_mniFileOpen.Size = new Size(176, 22);
            m_mniFileOpen.Text = "&Öffnen";
            m_mniFileOpen.Click += m_mniFileOpen_Click;
            // 
            // m_mniFileClose
            // 
            m_mniFileClose.Name = "m_mniFileClose";
            m_mniFileClose.ShortcutKeys = Keys.Control | Keys.F4;
            m_mniFileClose.Size = new Size(176, 22);
            m_mniFileClose.Text = "&Schliessen";
            m_mniFileClose.Click += m_mniFileClose_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(173, 6);
            // 
            // m_mniFileSave
            // 
            m_mniFileSave.Name = "m_mniFileSave";
            m_mniFileSave.ShortcutKeys = Keys.Control | Keys.S;
            m_mniFileSave.Size = new Size(176, 22);
            m_mniFileSave.Text = "&Speichern";
            m_mniFileSave.Click += m_mniFileSave_Click;
            // 
            // m_mniFileSaveAs
            // 
            m_mniFileSaveAs.Name = "m_mniFileSaveAs";
            m_mniFileSaveAs.Size = new Size(176, 22);
            m_mniFileSaveAs.Text = "Speichern unter";
            m_mniFileSaveAs.Click += m_mniFileSaveAs_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(173, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(176, 22);
            exitToolStripMenuItem.Text = "Beenden";
            // 
            // m_mniBuild
            // 
            m_mniBuild.DropDownItems.AddRange(new ToolStripItem[] { m_mniBuildScript, m_mniBuildRebuild, m_mniBuildSettings, m_mniBuildHostEnvironment });
            m_mniBuild.Name = "m_mniBuild";
            m_mniBuild.Size = new Size(46, 20);
            m_mniBuild.Text = "&Build";
            // 
            // m_mniBuildScript
            // 
            m_mniBuildScript.Name = "m_mniBuildScript";
            m_mniBuildScript.ShortcutKeys = Keys.Control | Keys.B;
            m_mniBuildScript.Size = new Size(180, 22);
            m_mniBuildScript.Text = "Build Script";
            m_mniBuildScript.Click += m_mniBuildScript_Click;
            // 
            // m_mniBuildRebuild
            // 
            m_mniBuildRebuild.Name = "m_mniBuildRebuild";
            m_mniBuildRebuild.Size = new Size(180, 22);
            m_mniBuildRebuild.Text = "&Rebuild Script";
            m_mniBuildRebuild.Click += m_mniBuildRebuild_Click;
            // 
            // m_mniBuildSettings
            // 
            m_mniBuildSettings.Name = "m_mniBuildSettings";
            m_mniBuildSettings.Size = new Size(180, 22);
            m_mniBuildSettings.Text = "Build &Settings...";
            m_mniBuildSettings.Click += m_mniBuildSettings_Click;
            // 
            // m_mniBuildHostEnvironment
            // 
            m_mniBuildHostEnvironment.Name = "m_mniBuildHostEnvironment";
            m_mniBuildHostEnvironment.ShortcutKeys = Keys.Control | Keys.M;
            m_mniBuildHostEnvironment.Size = new Size(180, 22);
            m_mniBuildHostEnvironment.Text = "&Modules";
            m_mniBuildHostEnvironment.Click += m_mniBuildHostEnvironment_Click;
            // 
            // m_mniDebug
            // 
            m_mniDebug.DropDownItems.AddRange(new ToolStripItem[] { m_mniDebugStart, m_mniDebugRun, m_mniDebugBreak, m_mniDebugStop, toolStripSeparator4, m_mniDebugStepInto, m_mniDebugStepOver, m_mniDebugStepOut, toolStripSeparator5, m_mniDebugToggleBreakpoint, m_mniDebugDeleteAllBreakpoints });
            m_mniDebug.Name = "m_mniDebug";
            m_mniDebug.Size = new Size(54, 20);
            m_mniDebug.Text = "&Debug";
            // 
            // m_mniDebugStart
            // 
            m_mniDebugStart.Name = "m_mniDebugStart";
            m_mniDebugStart.ShortcutKeys = Keys.F5;
            m_mniDebugStart.Size = new Size(320, 22);
            m_mniDebugStart.Text = "Start Debugging";
            m_mniDebugStart.Click += m_mniDebugStart_Click;
            // 
            // m_mniDebugRun
            // 
            m_mniDebugRun.Name = "m_mniDebugRun";
            m_mniDebugRun.ShortcutKeys = Keys.Control | Keys.F5;
            m_mniDebugRun.Size = new Size(320, 22);
            m_mniDebugRun.Text = "Start Without Debugging";
            m_mniDebugRun.Click += m_mniDebugRun_Click;
            // 
            // m_mniDebugBreak
            // 
            m_mniDebugBreak.Name = "m_mniDebugBreak";
            m_mniDebugBreak.ShortcutKeys = Keys.Control | Keys.F12;
            m_mniDebugBreak.Size = new Size(320, 22);
            m_mniDebugBreak.Text = "Break";
            m_mniDebugBreak.Click += m_mniDebugBreak_Click;
            // 
            // m_mniDebugStop
            // 
            m_mniDebugStop.Name = "m_mniDebugStop";
            m_mniDebugStop.ShortcutKeys = Keys.Control | Keys.End;
            m_mniDebugStop.Size = new Size(320, 22);
            m_mniDebugStop.Text = "Stop";
            m_mniDebugStop.Click += m_mniDebugStop_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(317, 6);
            // 
            // m_mniDebugStepInto
            // 
            m_mniDebugStepInto.Name = "m_mniDebugStepInto";
            m_mniDebugStepInto.ShortcutKeys = Keys.F11;
            m_mniDebugStepInto.Size = new Size(320, 22);
            m_mniDebugStepInto.Text = "Step Into";
            m_mniDebugStepInto.Click += m_mniDebugStepInto_Click;
            // 
            // m_mniDebugStepOver
            // 
            m_mniDebugStepOver.Name = "m_mniDebugStepOver";
            m_mniDebugStepOver.ShortcutKeys = Keys.F10;
            m_mniDebugStepOver.Size = new Size(320, 22);
            m_mniDebugStepOver.Text = "Step Over";
            m_mniDebugStepOver.Click += m_mniDebugStepOver_Click;
            // 
            // m_mniDebugStepOut
            // 
            m_mniDebugStepOut.Name = "m_mniDebugStepOut";
            m_mniDebugStepOut.ShortcutKeys = Keys.Shift | Keys.F11;
            m_mniDebugStepOut.Size = new Size(320, 22);
            m_mniDebugStepOut.Text = "Step Out";
            m_mniDebugStepOut.Click += m_mniDebugStepOut_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(317, 6);
            // 
            // m_mniDebugToggleBreakpoint
            // 
            m_mniDebugToggleBreakpoint.Name = "m_mniDebugToggleBreakpoint";
            m_mniDebugToggleBreakpoint.ShortcutKeys = Keys.F9;
            m_mniDebugToggleBreakpoint.Size = new Size(320, 22);
            m_mniDebugToggleBreakpoint.Text = "Toggle Breakpoint";
            m_mniDebugToggleBreakpoint.Click += m_mniDebugToggleBreakpoint_Click;
            // 
            // m_mniDebugDeleteAllBreakpoints
            // 
            m_mniDebugDeleteAllBreakpoints.Name = "m_mniDebugDeleteAllBreakpoints";
            m_mniDebugDeleteAllBreakpoints.ShortcutKeys = Keys.Control | Keys.Shift | Keys.F9;
            m_mniDebugDeleteAllBreakpoints.Size = new Size(320, 22);
            m_mniDebugDeleteAllBreakpoints.Text = "Delete All Breakpoints";
            m_mniDebugDeleteAllBreakpoints.Click += m_mniDebugDeleteAllBreakpoints_Click;
            // 
            // m_mniHelp
            // 
            m_mniHelp.DropDownItems.AddRange(new ToolStripItem[] { m_mniHelpAbout });
            m_mniHelp.Name = "m_mniHelp";
            m_mniHelp.Size = new Size(44, 20);
            m_mniHelp.Text = "&Help";
            // 
            // m_mniHelpAbout
            // 
            m_mniHelpAbout.Name = "m_mniHelpAbout";
            m_mniHelpAbout.ShortcutKeys = Keys.F1;
            m_mniHelpAbout.Size = new Size(126, 22);
            m_mniHelpAbout.Text = "&About";
            m_mniHelpAbout.Click += m_mniHelpAbout_Click;
            // 
            // m_mniEdit
            // 
            m_mniEdit.DropDownItems.AddRange(new ToolStripItem[] { m_mniEditUndo, m_mniEditRedo, toolStripSeparator3, m_mniEditCut, m_mniEditCopy, m_mniEditPaste, m_mniEditDelete, toolStripSeparator6, m_mniEditSelectAll });
            m_mniEdit.Name = "m_mniEdit";
            m_mniEdit.Size = new Size(75, 20);
            m_mniEdit.Text = "Bearbeiten";
            // 
            // m_mniEditUndo
            // 
            m_mniEditUndo.Name = "m_mniEditUndo";
            m_mniEditUndo.ShortcutKeys = Keys.Control | Keys.Z;
            m_mniEditUndo.Size = new Size(202, 22);
            m_mniEditUndo.Text = "Rückgängig";
            m_mniEditUndo.Click += m_mniEditUndo_Click;
            // 
            // m_mniEditRedo
            // 
            m_mniEditRedo.Name = "m_mniEditRedo";
            m_mniEditRedo.ShortcutKeys = Keys.Control | Keys.Y;
            m_mniEditRedo.Size = new Size(202, 22);
            m_mniEditRedo.Text = "Widerholen";
            m_mniEditRedo.Click += m_mniEditRedo_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(199, 6);
            // 
            // m_mniEditCut
            // 
            m_mniEditCut.Name = "m_mniEditCut";
            m_mniEditCut.ShortcutKeys = Keys.Control | Keys.X;
            m_mniEditCut.Size = new Size(202, 22);
            m_mniEditCut.Text = "Ausschneiden";
            m_mniEditCut.Click += m_mniEditCut_Click;
            // 
            // m_mniEditCopy
            // 
            m_mniEditCopy.Name = "m_mniEditCopy";
            m_mniEditCopy.ShortcutKeys = Keys.Control | Keys.C;
            m_mniEditCopy.Size = new Size(202, 22);
            m_mniEditCopy.Text = "Kopieren";
            m_mniEditCopy.Click += m_mniEditCopy_Click;
            // 
            // m_mniEditPaste
            // 
            m_mniEditPaste.Name = "m_mniEditPaste";
            m_mniEditPaste.ShortcutKeys = Keys.Control | Keys.V;
            m_mniEditPaste.Size = new Size(202, 22);
            m_mniEditPaste.Text = "Einfügen";
            m_mniEditPaste.Click += m_mniEditPaste_Click;
            // 
            // m_mniEditDelete
            // 
            m_mniEditDelete.Name = "m_mniEditDelete";
            m_mniEditDelete.ShortcutKeys = Keys.Delete;
            m_mniEditDelete.Size = new Size(202, 22);
            m_mniEditDelete.Text = "Löschen";
            m_mniEditDelete.Click += m_mniEditDelete_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(199, 6);
            // 
            // m_mniEditSelectAll
            // 
            m_mniEditSelectAll.Name = "m_mniEditSelectAll";
            m_mniEditSelectAll.ShortcutKeys = Keys.Control | Keys.A;
            m_mniEditSelectAll.Size = new Size(202, 22);
            m_mniEditSelectAll.Text = "Alles auswählen";
            m_mniEditSelectAll.Click += m_mniEditSelectAll_Click;
            // 
            // m_tmrDebugger
            // 
            m_tmrDebugger.Interval = 1;
            m_tmrDebugger.Tick += m_tmrDebugger_Tick;
            // 
            // Debugger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 651);
            Controls.Add(m_spcHorizontal);
            Controls.Add(m_mnsMain);
            DoubleBuffered = true;
            MainMenuStrip = m_mnsMain;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Debugger";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Debugger";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            m_spcHorizontal.Panel1.ResumeLayout(false);
            m_spcHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_spcHorizontal).EndInit();
            m_spcHorizontal.ResumeLayout(false);
            m_spcVertical.Panel1.ResumeLayout(false);
            m_spcVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_spcVertical).EndInit();
            m_spcVertical.ResumeLayout(false);
            m_grpScripts.ResumeLayout(false);
            m_cmsScript.ResumeLayout(false);
            m_grpVirtualMachine.ResumeLayout(false);
            m_tbcVirtualMachine.ResumeLayout(false);
            m_tbpByteCode.ResumeLayout(false);
            m_tbpScopeGlobal.ResumeLayout(false);
            m_tbpScopeScript.ResumeLayout(false);
            m_tbpScopeLocal.ResumeLayout(false);
            m_grpOutput.ResumeLayout(false);
            m_grpOutput.PerformLayout();
            m_stsStatus.ResumeLayout(false);
            m_stsStatus.PerformLayout();
            m_tbpCallStack.ResumeLayout(false);
            m_tbpParameterStack.ResumeLayout(false);
            m_tbpLocks.ResumeLayout(false);
            m_mnsMain.ResumeLayout(false);
            m_mnsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer m_spcHorizontal;
        private System.Windows.Forms.MenuStrip m_mnsMain;
        private System.Windows.Forms.ToolStripMenuItem m_mniFile;
        private System.Windows.Forms.TextBox m_txtOutput;
        private System.Windows.Forms.ToolStripMenuItem m_mniFileNew;
        private System.Windows.Forms.ToolStripMenuItem m_mniFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_mniFileSave;
        private System.Windows.Forms.ToolStripMenuItem m_mniFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl m_tbcScripts;
        private System.Windows.Forms.ToolStripMenuItem m_mniEdit;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditCut;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditCopy;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditPaste;
        private System.Windows.Forms.ToolStripMenuItem m_mniBuild;
        private System.Windows.Forms.ToolStripMenuItem m_mniBuildScript;
        private System.Windows.Forms.ToolStripMenuItem m_mniBuildSettings;
        private System.Windows.Forms.ToolStripMenuItem m_mniBuildHostEnvironment;
        private System.Windows.Forms.GroupBox m_grpOutput;
        private System.Windows.Forms.Panel m_grpScripts;
        private System.Windows.Forms.SplitContainer m_spcVertical;
        private System.Windows.Forms.Panel m_grpVirtualMachine;
        private System.Windows.Forms.TabControl m_tbcVirtualMachine;
        private System.Windows.Forms.TabPage m_tbpScopeGlobal;
        private System.Windows.Forms.TabPage m_tbpScopeScript;
        private System.Windows.Forms.TabPage m_tbpScopeLocal;
        private System.Windows.Forms.TabPage m_tbpByteCode;
        private System.Windows.Forms.TabPage m_tbpLocks;
        private System.Windows.Forms.ToolStripMenuItem m_mniFileClose;
        private System.Windows.Forms.TabPage m_tbpCallStack;
        private System.Windows.Forms.TabPage m_tbpParameterStack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditSelectAll;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebug;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugStart;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugRun;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugStepInto;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugStepOver;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugStepOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugToggleBreakpoint;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugDeleteAllBreakpoints;
        private System.Windows.Forms.Timer m_tmrDebugger;
        private System.Windows.Forms.ToolStripMenuItem m_mniDebugBreak;
        private ByteCodeListBox m_lsbByteCode;
        private System.Windows.Forms.ListBox m_lsbParameterStack;
        private VariableDictionaryTreeView m_vdtLocal;
        private VariableDictionaryTreeView m_vdtScript;
        private VariableDictionaryTreeView m_vdtGlobal;
        private System.Windows.Forms.ListBox m_lsbCallStack;
        private System.Windows.Forms.ToolStripMenuItem m_mniBuildRebuild;
        private System.Windows.Forms.ToolStripMenuItem m_mniHelp;
        private System.Windows.Forms.ToolStripMenuItem m_mniHelpAbout;
        private System.Windows.Forms.ListBox m_lsbLocks;
        private System.Windows.Forms.StatusStrip m_stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel m_tslMessage;
        private System.Windows.Forms.ToolStripStatusLabel m_tslLineNumber;
        private System.Windows.Forms.ToolStripStatusLabel m_tslCharNumber;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditDelete;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditUndo;
        private System.Windows.Forms.ToolStripMenuItem m_mniEditRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip m_cmsScript;
        private System.Windows.Forms.ToolStripMenuItem m_tmiScriptSave;
        private System.Windows.Forms.ToolStripMenuItem m_tmiScriptClose;
    }
}

