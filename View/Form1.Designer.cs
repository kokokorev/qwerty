namespace View
{
    partial class Form1
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
            this.controlComboBox = new Components.ControlComboBox();
            this.controlTextBox = new Components.ControlTextBox();
            this.controlListBox = new Components.ControlListBox();
            this.SuspendLayout();
            // 
            // controlComboBox
            // 
            this.controlComboBox.Location = new System.Drawing.Point(12, 12);
            this.controlComboBox.Name = "controlComboBox";
            this.controlComboBox.SelectedValue = "";
            this.controlComboBox.Size = new System.Drawing.Size(223, 59);
            this.controlComboBox.TabIndex = 0;
            // 
            // controlTextBox
            // 
            this.controlTextBox.EnteredValue = "";
            this.controlTextBox.Location = new System.Drawing.Point(241, 12);
            this.controlTextBox.Name = "controlTextBox";
            this.controlTextBox.Size = new System.Drawing.Size(256, 59);
            this.controlTextBox.TabIndex = 0;
            // 
            // controlListBox
            // 
            this.controlListBox.Location = new System.Drawing.Point(12, 133);
            this.controlListBox.Name = "controlListBox";
            this.controlListBox.SelectedIndex = -1;
            this.controlListBox.Size = new System.Drawing.Size(356, 141);
            this.controlListBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 307);
            this.Controls.Add(this.controlComboBox);
            this.Controls.Add(this.controlTextBox);
            this.Controls.Add(this.controlListBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private Components.ControlComboBox controlComboBox;
        private Components.ControlTextBox controlTextBox;
        private Components.ControlListBox controlListBox;
    }
}