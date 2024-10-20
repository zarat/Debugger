namespace IDE
{
    partial class RunScriptForm
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
            m_lblFunction = new Label();
            m_cmbFunction = new ComboBox();
            m_lblParameters = new Label();
            m_dgvParameters = new DataGridView();
            ParameterName = new DataGridViewTextBoxColumn();
            ParameterValue = new DataGridViewTextBoxColumn();
            m_btnOk = new Button();
            m_btnCancel = new Button();
            m_erpDialog = new ErrorProvider(components);
            labelStringReminder = new Label();
            ((System.ComponentModel.ISupportInitialize)m_dgvParameters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)m_erpDialog).BeginInit();
            SuspendLayout();
            // 
            // m_lblFunction
            // 
            m_lblFunction.AutoSize = true;
            m_lblFunction.Location = new Point(14, 18);
            m_lblFunction.Margin = new Padding(4, 0, 4, 0);
            m_lblFunction.Name = "m_lblFunction";
            m_lblFunction.Size = new Size(54, 15);
            m_lblFunction.TabIndex = 0;
            m_lblFunction.Text = "Function";
            // 
            // m_cmbFunction
            // 
            m_cmbFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            m_cmbFunction.FormattingEnabled = true;
            m_cmbFunction.Location = new Point(92, 14);
            m_cmbFunction.Margin = new Padding(4, 3, 4, 3);
            m_cmbFunction.Name = "m_cmbFunction";
            m_cmbFunction.Size = new Size(341, 23);
            m_cmbFunction.TabIndex = 1;
            m_cmbFunction.SelectedIndexChanged += m_cmbFunction_SelectedIndexChanged;
            // 
            // m_lblParameters
            // 
            m_lblParameters.AutoSize = true;
            m_lblParameters.Location = new Point(13, 64);
            m_lblParameters.Margin = new Padding(4, 0, 4, 0);
            m_lblParameters.Name = "m_lblParameters";
            m_lblParameters.Size = new Size(66, 15);
            m_lblParameters.TabIndex = 2;
            m_lblParameters.Text = "Parameters";
            // 
            // m_dgvParameters
            // 
            m_dgvParameters.AllowUserToAddRows = false;
            m_dgvParameters.AllowUserToDeleteRows = false;
            m_dgvParameters.AllowUserToResizeColumns = false;
            m_dgvParameters.AllowUserToResizeRows = false;
            m_dgvParameters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvParameters.Columns.AddRange(new DataGridViewColumn[] { ParameterName, ParameterValue });
            m_dgvParameters.Location = new Point(92, 64);
            m_dgvParameters.Margin = new Padding(4, 3, 4, 3);
            m_dgvParameters.Name = "m_dgvParameters";
            m_dgvParameters.RowHeadersVisible = false;
            m_dgvParameters.Size = new Size(342, 148);
            m_dgvParameters.TabIndex = 3;
            m_dgvParameters.CellValidated += m_dgvParameters_CellValidated;
            m_dgvParameters.CellValidating += m_dgvParameters_CellValidating;
            // 
            // ParameterName
            // 
            ParameterName.Frozen = true;
            ParameterName.HeaderText = "Name";
            ParameterName.Name = "ParameterName";
            ParameterName.ReadOnly = true;
            // 
            // ParameterValue
            // 
            ParameterValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ParameterValue.HeaderText = "Value";
            ParameterValue.Name = "ParameterValue";
            // 
            // m_btnOk
            // 
            m_btnOk.Location = new Point(251, 264);
            m_btnOk.Margin = new Padding(4, 3, 4, 3);
            m_btnOk.Name = "m_btnOk";
            m_btnOk.Size = new Size(88, 27);
            m_btnOk.TabIndex = 4;
            m_btnOk.Text = "OK";
            m_btnOk.UseVisualStyleBackColor = true;
            m_btnOk.Click += m_btnOk_Click;
            // 
            // m_btnCancel
            // 
            m_btnCancel.DialogResult = DialogResult.Cancel;
            m_btnCancel.Location = new Point(345, 264);
            m_btnCancel.Margin = new Padding(4, 3, 4, 3);
            m_btnCancel.Name = "m_btnCancel";
            m_btnCancel.Size = new Size(88, 27);
            m_btnCancel.TabIndex = 5;
            m_btnCancel.Text = "Cancel";
            m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_erpDialog
            // 
            m_erpDialog.ContainerControl = this;
            // 
            // labelStringReminder
            // 
            labelStringReminder.AutoSize = true;
            labelStringReminder.Location = new Point(92, 226);
            labelStringReminder.Margin = new Padding(4, 0, 4, 0);
            labelStringReminder.Name = "labelStringReminder";
            labelStringReminder.Size = new Size(218, 15);
            labelStringReminder.TabIndex = 6;
            labelStringReminder.Text = "Strings must be enclosed in parenthesis!";
            // 
            // RunScriptForm
            // 
            AcceptButton = m_btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = m_btnCancel;
            ClientSize = new Size(448, 305);
            Controls.Add(labelStringReminder);
            Controls.Add(m_btnCancel);
            Controls.Add(m_btnOk);
            Controls.Add(m_dgvParameters);
            Controls.Add(m_lblParameters);
            Controls.Add(m_cmbFunction);
            Controls.Add(m_lblFunction);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RunScriptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Entry Point";
            Load += RunScriptForm_Load;
            ((System.ComponentModel.ISupportInitialize)m_dgvParameters).EndInit();
            ((System.ComponentModel.ISupportInitialize)m_erpDialog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label m_lblFunction;
        private System.Windows.Forms.ComboBox m_cmbFunction;
        private System.Windows.Forms.Label m_lblParameters;
        private System.Windows.Forms.DataGridView m_dgvParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValue;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.ErrorProvider m_erpDialog;
        private Label labelStringReminder;
    }
}