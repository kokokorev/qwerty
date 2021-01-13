namespace EmployeeView
{
    partial class MainForm
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlDataTreeTable = new WindowsFormsControlLibrary.Data.ControlDataTreeTable();
            this.createEmployeeButton = new System.Windows.Forms.Button();
            this.backupSaveButton = new System.Windows.Forms.Button();
            this.componentBackupXml = new NonVisualComponents.Kokorev.ComponentBackupXml(this.components);
            this.buttonWordPosition = new System.Windows.Forms.Button();
            this.buttonWordVacation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlDataTreeTable
            // 
            this.controlDataTreeTable.Location = new System.Drawing.Point(12, 12);
            this.controlDataTreeTable.Name = "controlDataTreeTable";
            this.controlDataTreeTable.Size = new System.Drawing.Size(620, 369);
            this.controlDataTreeTable.TabIndex = 1;
            // 
            // createEmployeeButton
            // 
            this.createEmployeeButton.Location = new System.Drawing.Point(638, 12);
            this.createEmployeeButton.Name = "createEmployeeButton";
            this.createEmployeeButton.Size = new System.Drawing.Size(109, 23);
            this.createEmployeeButton.TabIndex = 2;
            this.createEmployeeButton.Text = "Создать";
            this.createEmployeeButton.UseVisualStyleBackColor = true;
            this.createEmployeeButton.Click += new System.EventHandler(this.createEmployeeButton_Click);
            // 
            // backupSaveButton
            // 
            this.backupSaveButton.Location = new System.Drawing.Point(638, 41);
            this.backupSaveButton.Name = "backupSaveButton";
            this.backupSaveButton.Size = new System.Drawing.Size(109, 23);
            this.backupSaveButton.TabIndex = 3;
            this.backupSaveButton.Text = "Создать бэкап";
            this.backupSaveButton.UseVisualStyleBackColor = true;
            this.backupSaveButton.Click += new System.EventHandler(this.backupSaveButton_Click);
            // 
            // buttonWordPosition
            // 
            this.buttonWordPosition.Location = new System.Drawing.Point(640, 87);
            this.buttonWordPosition.Name = "buttonWordPosition";
            this.buttonWordPosition.Size = new System.Drawing.Size(108, 23);
            this.buttonWordPosition.TabIndex = 4;
            this.buttonWordPosition.Text = "По должностям";
            this.buttonWordPosition.UseVisualStyleBackColor = true;
            this.buttonWordPosition.Click += new System.EventHandler(this.buttonWordPosition_Click);
            // 
            // buttonWordVacation
            // 
            this.buttonWordVacation.Location = new System.Drawing.Point(640, 116);
            this.buttonWordVacation.Name = "buttonWordVacation";
            this.buttonWordVacation.Size = new System.Drawing.Size(108, 23);
            this.buttonWordVacation.TabIndex = 5;
            this.buttonWordVacation.Text = "По отпускам";
            this.buttonWordVacation.UseVisualStyleBackColor = true;
            this.buttonWordVacation.Click += new System.EventHandler(this.buttonWordVacation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Отчеты в Word";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWordVacation);
            this.Controls.Add(this.buttonWordPosition);
            this.Controls.Add(this.backupSaveButton);
            this.Controls.Add(this.createEmployeeButton);
            this.Controls.Add(this.controlDataTreeTable);
            this.Name = "MainForm";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WindowsFormsControlLibrary.Data.ControlDataTreeTable controlDataTreeTable;
        private System.Windows.Forms.Button createEmployeeButton;
        private System.Windows.Forms.Button backupSaveButton;
        private NonVisualComponents.Kokorev.ComponentBackupXml componentBackupXml;
        private System.Windows.Forms.Button buttonWordPosition;
        private System.Windows.Forms.Button buttonWordVacation;
        private System.Windows.Forms.Label label1;
    }
}

