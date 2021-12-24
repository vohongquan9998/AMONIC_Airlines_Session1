namespace Session1_2.view
{
    partial class FormDetected
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
            this.txtReason = new System.Windows.Forms.TextBox();
            this.radSoftware = new System.Windows.Forms.RadioButton();
            this.radSystemCrash = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(12, 110);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(491, 294);
            this.txtReason.TabIndex = 0;
            // 
            // radSoftware
            // 
            this.radSoftware.AutoSize = true;
            this.radSoftware.Location = new System.Drawing.Point(34, 416);
            this.radSoftware.Name = "radSoftware";
            this.radSoftware.Size = new System.Drawing.Size(97, 17);
            this.radSoftware.TabIndex = 1;
            this.radSoftware.Text = "Software Crash";
            this.radSoftware.UseVisualStyleBackColor = true;
            // 
            // radSystemCrash
            // 
            this.radSystemCrash.AutoSize = true;
            this.radSystemCrash.Location = new System.Drawing.Point(177, 416);
            this.radSystemCrash.Name = "radSystemCrash";
            this.radSystemCrash.Size = new System.Drawing.Size(89, 17);
            this.radSystemCrash.TabIndex = 2;
            this.radSystemCrash.Text = "System Crash";
            this.radSystemCrash.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(390, 410);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 41);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Confirm";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reason";
            // 
            // lbShow
            // 
            this.lbShow.AutoSize = true;
            this.lbShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShow.Location = new System.Drawing.Point(31, 34);
            this.lbShow.Name = "lbShow";
            this.lbShow.Size = new System.Drawing.Size(238, 18);
            this.lbShow.TabIndex = 5;
            this.lbShow.Text = "No logout detected for last login on";
            // 
            // FormDetected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 463);
            this.Controls.Add(this.lbShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.radSystemCrash);
            this.Controls.Add(this.radSoftware);
            this.Controls.Add(this.txtReason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormDetected";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No Logout Detected";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.RadioButton radSoftware;
        private System.Windows.Forms.RadioButton radSystemCrash;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbShow;
    }
}