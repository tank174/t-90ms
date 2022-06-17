namespace WindowsFormsApp6
{
    partial class ChangePassForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOldPass = new System.Windows.Forms.TextBox();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.tbNewPassConfirm = new System.Windows.Forms.TextBox();
            this.byChangePass = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущий пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Новый пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Повторите пароль";
            // 
            // tbOldPass
            // 
            this.tbOldPass.Location = new System.Drawing.Point(111, 5);
            this.tbOldPass.Name = "tbOldPass";
            this.tbOldPass.Size = new System.Drawing.Size(105, 20);
            this.tbOldPass.TabIndex = 3;
            // 
            // tbNewPass
            // 
            this.tbNewPass.Location = new System.Drawing.Point(111, 31);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.Size = new System.Drawing.Size(105, 20);
            this.tbNewPass.TabIndex = 4;
            // 
            // tbNewPassConfirm
            // 
            this.tbNewPassConfirm.Location = new System.Drawing.Point(111, 57);
            this.tbNewPassConfirm.Name = "tbNewPassConfirm";
            this.tbNewPassConfirm.Size = new System.Drawing.Size(105, 20);
            this.tbNewPassConfirm.TabIndex = 5;
            // 
            // byChangePass
            // 
            this.byChangePass.Location = new System.Drawing.Point(8, 90);
            this.byChangePass.Name = "byChangePass";
            this.byChangePass.Size = new System.Drawing.Size(101, 23);
            this.byChangePass.TabIndex = 6;
            this.byChangePass.Text = "Сменить пароль";
            this.byChangePass.UseVisualStyleBackColor = true;
            this.byChangePass.Click += new System.EventHandler(this.byChangePass_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(115, 90);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(101, 23);
            this.btBack.TabIndex = 7;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // ChangePassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 121);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.byChangePass);
            this.Controls.Add(this.tbNewPassConfirm);
            this.Controls.Add(this.tbNewPass);
            this.Controls.Add(this.tbOldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassForm";
            this.Text = "ChangePassForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOldPass;
        private System.Windows.Forms.TextBox tbNewPass;
        private System.Windows.Forms.TextBox tbNewPassConfirm;
        private System.Windows.Forms.Button byChangePass;
        private System.Windows.Forms.Button btBack;
    }
}