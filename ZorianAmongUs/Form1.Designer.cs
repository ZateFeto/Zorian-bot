
namespace ZorianAmongUs
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
            this.codeText = new System.Windows.Forms.TextBox();
            this.sendCode = new System.Windows.Forms.Button();
            this.statusText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // codeText
            // 
            this.codeText.Location = new System.Drawing.Point(13, 13);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(100, 23);
            this.codeText.TabIndex = 0;
            // 
            // sendCode
            // 
            this.sendCode.Location = new System.Drawing.Point(119, 12);
            this.sendCode.Name = "sendCode";
            this.sendCode.Size = new System.Drawing.Size(93, 23);
            this.sendCode.TabIndex = 1;
            this.sendCode.Text = "Send Code";
            this.sendCode.UseVisualStyleBackColor = true;
            this.sendCode.Click += new System.EventHandler(this.sendCode_Click);
            // 
            // statusText
            // 
            this.statusText.BackColor = System.Drawing.Color.Red;
            this.statusText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusText.Location = new System.Drawing.Point(13, 46);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(199, 27);
            this.statusText.TabIndex = 2;
            this.statusText.Text = "Offline";
            this.statusText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 81);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.sendCode);
            this.Controls.Add(this.codeText);
            this.Name = "Form1";
            this.Text = "Zorian Among Us";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeText;
        private System.Windows.Forms.Button sendCode;
        private System.Windows.Forms.TextBox statusText;
    }
}

