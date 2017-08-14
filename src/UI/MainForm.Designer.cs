namespace ESBToolkitEntLibMachineConfigToggler.UI
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
            this.toggleButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toggleButton
            // 
            this.toggleButton.Location = new System.Drawing.Point(528, 12);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(75, 35);
            this.toggleButton.TabIndex = 0;
            this.toggleButton.Text = "Toggle";
            this.toggleButton.UseVisualStyleBackColor = true;
            this.toggleButton.Click += new System.EventHandler(this.toggleButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(12, 12);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(504, 241);
            this.statusTextBox.TabIndex = 1;
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(528, 53);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 27);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 267);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.toggleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESB Toolkit Enterprise Library Machine Config Toggler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button aboutButton;
    }
}

