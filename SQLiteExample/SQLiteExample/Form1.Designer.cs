namespace SQLiteExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxDbFileName = new TextBox();
            textBoxTableName = new TextBox();
            label2 = new Label();
            buttonSetup = new Button();
            label3 = new Label();
            label4 = new Label();
            textBoxMessage = new TextBox();
            comboBox1 = new ComboBox();
            buttonInsert = new Button();
            dataGridViewDBData = new DataGridView();
            labelStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDBData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "資料庫名稱";
            // 
            // textBoxDbFileName
            // 
            textBoxDbFileName.Location = new Point(12, 27);
            textBoxDbFileName.Name = "textBoxDbFileName";
            textBoxDbFileName.Size = new Size(100, 23);
            textBoxDbFileName.TabIndex = 1;
            textBoxDbFileName.Text = "MyData";
            // 
            // textBoxTableName
            // 
            textBoxTableName.Location = new Point(118, 27);
            textBoxTableName.Name = "textBoxTableName";
            textBoxTableName.Size = new Size(100, 23);
            textBoxTableName.TabIndex = 3;
            textBoxTableName.Text = "MyTable";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 9);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "表格名稱";
            // 
            // buttonSetup
            // 
            buttonSetup.Location = new Point(224, 27);
            buttonSetup.Name = "buttonSetup";
            buttonSetup.Size = new Size(75, 23);
            buttonSetup.TabIndex = 4;
            buttonSetup.Text = "Setup";
            buttonSetup.UseVisualStyleBackColor = true;
            buttonSetup.Click += buttonSetup_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 64);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 5;
            label3.Text = "主題";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 108);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 7;
            label4.Text = "訊息";
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 126);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(206, 67);
            textBoxMessage.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(224, 170);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(75, 23);
            buttonInsert.TabIndex = 10;
            buttonInsert.Text = "Insert";
            buttonInsert.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDBData
            // 
            dataGridViewDBData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDBData.Location = new Point(12, 211);
            dataGridViewDBData.Name = "dataGridViewDBData";
            dataGridViewDBData.Size = new Size(287, 150);
            dataGridViewDBData.TabIndex = 11;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 375);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(53, 15);
            labelStatus.TabIndex = 12;
            labelStatus.Text = "Initialize";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 415);
            Controls.Add(labelStatus);
            Controls.Add(dataGridViewDBData);
            Controls.Add(buttonInsert);
            Controls.Add(comboBox1);
            Controls.Add(textBoxMessage);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(buttonSetup);
            Controls.Add(textBoxTableName);
            Controls.Add(label2);
            Controls.Add(textBoxDbFileName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDBData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxDbFileName;
        private TextBox textBoxTableName;
        private Label label2;
        private Button buttonSetup;
        private Label label3;
        private Label label4;
        private TextBox textBoxMessage;
        private ComboBox comboBox1;
        private Button buttonInsert;
        private DataGridView dataGridViewDBData;
        private Label labelStatus;
    }
}
