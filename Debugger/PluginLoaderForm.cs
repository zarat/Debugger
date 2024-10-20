using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using ScriptStack;
using ScriptStack.Compiler;
using ScriptStack.Runtime;

namespace IDE
{
    public partial class PluginLoaderForm : Form
    {
        #region Private Variables

        Manager m_scriptManager;

        #endregion

        #region Private Methods

        private void UpdateModuleControl()
        {

            m_dgvHostFunctions.Rows.Clear();

            foreach (Routine hostFunctionPrototype in m_scriptManager.Routines.Values)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(m_dgvHostFunctions);
                dataGridViewRow.Cells[0].Value = hostFunctionPrototype.ToString();
                Host hostFunctionHandler = hostFunctionPrototype.Handler;

                Version v = hostFunctionHandler.GetType().Assembly.GetName().Version;

                dataGridViewRow.Cells[1].Value = hostFunctionHandler.GetType().FullName + " v" + v.ToString();

                dataGridViewRow.Cells[2].Value = hostFunctionPrototype.Description(); //hostFunctionHandler.GetType().Assembly.FullName;

                m_dgvHostFunctions.Rows.Add(dataGridViewRow);
            }
        }

        private void UpdateModuleControl(string str)
        {

            m_dgvHostFunctions.Rows.Clear();

            foreach (Routine hostFunctionPrototype in m_scriptManager.Routines.Values)
            {

                if (hostFunctionPrototype.ToString().Contains(str) || hostFunctionPrototype.Handler.GetType().Name.Contains(str) || ( null != hostFunctionPrototype.Description() && hostFunctionPrototype.Description().Contains(str) ) )
                {

                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(m_dgvHostFunctions);
                    dataGridViewRow.Cells[0].Value = hostFunctionPrototype.ToString();
                    Host hostFunctionHandler = hostFunctionPrototype.Handler;

                    Version v = hostFunctionHandler.GetType().Assembly.GetName().Version;

                    dataGridViewRow.Cells[1].Value = hostFunctionHandler.GetType().FullName + " v" + v.ToString();
                    dataGridViewRow.Cells[2].Value = hostFunctionPrototype.Description(); // hostFunctionHandler.GetType().Assembly.FullName;

                    m_dgvHostFunctions.Rows.Add(dataGridViewRow);

                }
            }
        }

        private void HostEnvironmentForm_Load(object objectSender, EventArgs eventArgs)
        {
            UpdateModuleControl();
            textBox1.Select();  // Fokus auf textBox1 setzen
        }

        private void m_btnRegisterModule_Click(object objectSender, EventArgs eventArgs)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Register Module";
            openFileDialog.Filter = "Assemblies (*.exe, *.dll)|*.exe;*.dll|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) 
                return;

            Assembly assembly = null;
            try
            {
                assembly = System.Reflection.Assembly.LoadFile(openFileDialog.FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this,
                    "Error while loading assembly. Reason: " + exception,
                    "Register module",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Type[] arrayTypes = assembly.GetExportedTypes();
            foreach (Type type in arrayTypes)
            {

                if (!typeof(ScriptStack.Runtime.Model).IsAssignableFrom(type))
                    continue;

                ConstructorInfo constructorInfo = null;
                try
                {
                    constructorInfo = type.GetConstructor(new Type[0]);
                }
                catch (Exception)
                {
                    continue;
                }

                try
                {
                    object objectHostModule = constructorInfo.Invoke(new object[0]);
                    ScriptStack.Runtime.Model hostModule = (ScriptStack.Runtime.Model)objectHostModule; 
                    m_scriptManager.Register(hostModule);
                }
                catch(Exception e) { continue; }

            }

            UpdateModuleControl();
        }

        #endregion

        #region Public Methods

        public PluginLoaderForm(Manager scriptManager)
        {
            InitializeComponent();

            m_scriptManager = scriptManager;
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //m_dgvHostFunctions.Rows.Clear();
            UpdateModuleControl(textBox1.Text);

        }
    }
}