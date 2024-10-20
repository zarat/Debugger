using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using ScriptStack;
using ScriptStack.Compiler;
using ScriptStack.Runtime;

namespace IDE
{
    internal class ScriptLoaderIDE
        : Scanner
    {
        #region Private Methods

        private TabControl m_tabControl;
        private Scanner m_scriptLoaderDefault;
        private Manager manager;

        #endregion

        #region Public Methods

        public ScriptLoaderIDE(TabControl tabControl, Scanner scriptLoaderDefault, Manager m)
        {
            m_tabControl = tabControl;
            m_scriptLoaderDefault = scriptLoaderDefault;
            manager = m;
        }

        public List<String> Scan(String strResourceName)
        {
            TabPage tabPageFound = null;
            foreach (TabPage tabPage in m_tabControl.TabPages)
            {
                if (tabPage.Text == strResourceName)
                {
                    tabPageFound = tabPage;
                    break;
                }
            }

            if (tabPageFound != null)
            {

                TextBox txtScript = (TextBox)tabPageFound.Controls[0];
                String strSource = txtScript.Text;

                strSource = strSource.Replace("\r\n","\r");

                String[] strSourceLines = strSource.Split('\r');

                int c = 0;
                foreach (string line in strSourceLines)
                {

                    /*
                    if (line.StartsWith("#import")) {
                        
                        string model = strSourceLines[c].Split(' ')[1];
                        manager.LoadComponents(model);
                        strSourceLines[c] = "";
                    }
                    */

                    c++;
                }

                List<String> listSourceLines = new List<string>();
                listSourceLines.AddRange(strSourceLines);

                // handle imports and includes!

                return listSourceLines;
            }
            else
            {
                return m_scriptLoaderDefault.Scan(strResourceName);
            }
        }

        #endregion
    }
}
