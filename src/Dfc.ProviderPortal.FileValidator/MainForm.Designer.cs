namespace Dfc.Providerportal.FileValidator
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFileTextBox = new System.Windows.Forms.TextBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.validateFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectFileTextBox
            // 
            this.selectFileTextBox.Location = new System.Drawing.Point(12, 32);
            this.selectFileTextBox.Name = "selectFileTextBox";
            this.selectFileTextBox.Size = new System.Drawing.Size(473, 20);
            this.selectFileTextBox.TabIndex = 0;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(533, 29);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(12, 119);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(596, 276);
            this.outputTextBox.TabIndex = 2;
            this.outputTextBox.Text = "";
            // 
            // validateFileButton
            // 
            this.validateFileButton.Location = new System.Drawing.Point(533, 74);
            this.validateFileButton.Name = "validateFileButton";
            this.validateFileButton.Size = new System.Drawing.Size(75, 23);
            this.validateFileButton.TabIndex = 3;
            this.validateFileButton.Text = "Validate File";
            this.validateFileButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 407);
            this.Controls.Add(this.validateFileButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.selectFileTextBox);
            this.Name = "MainForm";
            this.Text = "CSV Validator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox selectFileTextBox;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Button validateFileButton;
    }
}

