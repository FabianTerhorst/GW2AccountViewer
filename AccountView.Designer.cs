namespace GW2AccountViewer
{
    partial class AccountView
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
            this.characters = new System.Windows.Forms.ListView();
            this.accountName = new System.Windows.Forms.Label();
            this.world_name = new System.Windows.Forms.Label();
            this.guilds = new System.Windows.Forms.ListBox();
            this.wallet = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // characters
            // 
            this.characters.Location = new System.Drawing.Point(625, 12);
            this.characters.Name = "characters";
            this.characters.Size = new System.Drawing.Size(121, 381);
            this.characters.TabIndex = 2;
            this.characters.UseCompatibleStateImageBehavior = false;
            // 
            // accountName
            // 
            this.accountName.AutoSize = true;
            this.accountName.Location = new System.Drawing.Point(13, 13);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(35, 13);
            this.accountName.TabIndex = 3;
            this.accountName.Text = "label1";
            // 
            // world_name
            // 
            this.world_name.AutoSize = true;
            this.world_name.Location = new System.Drawing.Point(13, 30);
            this.world_name.Name = "world_name";
            this.world_name.Size = new System.Drawing.Size(35, 13);
            this.world_name.TabIndex = 4;
            this.world_name.Text = "label2";
            // 
            // guilds
            // 
            this.guilds.FormattingEnabled = true;
            this.guilds.Location = new System.Drawing.Point(12, 52);
            this.guilds.Name = "guilds";
            this.guilds.Size = new System.Drawing.Size(120, 121);
            this.guilds.TabIndex = 5;
            // 
            // wallet
            // 
            this.wallet.FormattingEnabled = true;
            this.wallet.Location = new System.Drawing.Point(12, 190);
            this.wallet.Name = "wallet";
            this.wallet.Size = new System.Drawing.Size(120, 199);
            this.wallet.TabIndex = 6;
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 405);
            this.Controls.Add(this.wallet);
            this.Controls.Add(this.guilds);
            this.Controls.Add(this.world_name);
            this.Controls.Add(this.accountName);
            this.Controls.Add(this.characters);
            this.Name = "AccountView";
            this.Text = "AccountView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView characters;
        private System.Windows.Forms.Label accountName;
        private System.Windows.Forms.Label world_name;
        private System.Windows.Forms.ListBox guilds;
        private System.Windows.Forms.ListBox wallet;
    }
}