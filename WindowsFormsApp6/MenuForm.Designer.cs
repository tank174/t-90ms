namespace WindowsFormsApp6
{
    partial class MenuForm
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
            this.btEvents = new System.Windows.Forms.Button();
            this.btReports = new System.Windows.Forms.Button();
            this.btManager = new System.Windows.Forms.Button();
            this.btAccountans = new System.Windows.Forms.Button();
            this.btCashier = new System.Windows.Forms.Button();
            this.btEntertainers = new System.Windows.Forms.Button();
            this.btChangePass = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btEvents
            // 
            this.btEvents.Location = new System.Drawing.Point(13, 13);
            this.btEvents.Name = "btEvents";
            this.btEvents.Size = new System.Drawing.Size(198, 26);
            this.btEvents.TabIndex = 0;
            this.btEvents.Text = "Учет клиентов";
            this.btEvents.UseVisualStyleBackColor = true;
            // 
            // btReports
            // 
            this.btReports.Location = new System.Drawing.Point(13, 45);
            this.btReports.Name = "btReports";
            this.btReports.Size = new System.Drawing.Size(198, 26);
            this.btReports.TabIndex = 1;
            this.btReports.Text = "Отчеты";
            this.btReports.UseVisualStyleBackColor = true;
            this.btReports.Click += new System.EventHandler(this.btReports_Click);
            // 
            // btManager
            // 
            this.btManager.Location = new System.Drawing.Point(13, 77);
            this.btManager.Name = "btManager";
            this.btManager.Size = new System.Drawing.Size(198, 26);
            this.btManager.TabIndex = 2;
            this.btManager.Text = "Руководители";
            this.btManager.UseVisualStyleBackColor = true;
            this.btManager.Click += new System.EventHandler(this.btManagers_Click);
            // 
            // btAccountans
            // 
            this.btAccountans.Location = new System.Drawing.Point(13, 109);
            this.btAccountans.Name = "btAccountans";
            this.btAccountans.Size = new System.Drawing.Size(198, 26);
            this.btAccountans.TabIndex = 3;
            this.btAccountans.Text = "Бухгалтеры";
            this.btAccountans.UseVisualStyleBackColor = true;
            this.btAccountans.Click += new System.EventHandler(this.btAccountants_Click);
            // 
            // btCashier
            // 
            this.btCashier.Location = new System.Drawing.Point(13, 141);
            this.btCashier.Name = "btCashier";
            this.btCashier.Size = new System.Drawing.Size(198, 26);
            this.btCashier.TabIndex = 4;
            this.btCashier.Text = "Кассиры";
            this.btCashier.UseVisualStyleBackColor = true;
            this.btCashier.Click += new System.EventHandler(this.btCashiers_Click);
            // 
            // btEntertainers
            // 
            this.btEntertainers.Location = new System.Drawing.Point(13, 173);
            this.btEntertainers.Name = "btEntertainers";
            this.btEntertainers.Size = new System.Drawing.Size(198, 26);
            this.btEntertainers.TabIndex = 5;
            this.btEntertainers.Text = "Аниматоры";
            this.btEntertainers.UseVisualStyleBackColor = true;
            // 
            // btChangePass
            // 
            this.btChangePass.Location = new System.Drawing.Point(13, 205);
            this.btChangePass.Name = "btChangePass";
            this.btChangePass.Size = new System.Drawing.Size(198, 26);
            this.btChangePass.TabIndex = 6;
            this.btChangePass.Text = "Изменить пароль";
            this.btChangePass.UseVisualStyleBackColor = true;
            this.btChangePass.Click += new System.EventHandler(this.btChangePass_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(13, 237);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(198, 26);
            this.btExit.TabIndex = 7;
            this.btExit.Text = "Выход";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 274);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btChangePass);
            this.Controls.Add(this.btEntertainers);
            this.Controls.Add(this.btCashier);
            this.Controls.Add(this.btAccountans);
            this.Controls.Add(this.btManager);
            this.Controls.Add(this.btReports);
            this.Controls.Add(this.btEvents);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEvents;
        private System.Windows.Forms.Button btReports;
        private System.Windows.Forms.Button btManager;
        private System.Windows.Forms.Button btAccountans;
        private System.Windows.Forms.Button btCashier;
        private System.Windows.Forms.Button btEntertainers;
        private System.Windows.Forms.Button btChangePass;
        private System.Windows.Forms.Button btExit;
    }
}