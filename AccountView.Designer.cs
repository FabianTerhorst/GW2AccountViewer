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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountView));
            this.accountName = new System.Windows.Forms.Label();
            this.world_name = new System.Windows.Forms.Label();
            this.guilds = new System.Windows.Forms.ListBox();
            this.wallet = new System.Windows.Forms.ListBox();
            this.accountCharacters = new System.Windows.Forms.ListBox();
            this.selectedCharacterName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.guilds.Size = new System.Drawing.Size(120, 316);
            this.guilds.TabIndex = 5;
            // 
            // wallet
            // 
            this.wallet.FormattingEnabled = true;
            this.wallet.Location = new System.Drawing.Point(12, 391);
            this.wallet.Name = "wallet";
            this.wallet.Size = new System.Drawing.Size(263, 368);
            this.wallet.TabIndex = 6;
            // 
            // accountCharacters
            // 
            this.accountCharacters.FormattingEnabled = true;
            this.accountCharacters.Location = new System.Drawing.Point(155, 13);
            this.accountCharacters.Name = "accountCharacters";
            this.accountCharacters.Size = new System.Drawing.Size(120, 355);
            this.accountCharacters.TabIndex = 7;
            this.accountCharacters.SelectedIndexChanged += new System.EventHandler(this.character_SelectedIndexChanged);
            // 
            // selectedCharacterName
            // 
            this.selectedCharacterName.AutoSize = true;
            this.selectedCharacterName.BackColor = System.Drawing.Color.Transparent;
            this.selectedCharacterName.Location = new System.Drawing.Point(305, 30);
            this.selectedCharacterName.Name = "selectedCharacterName";
            this.selectedCharacterName.Size = new System.Drawing.Size(35, 13);
            this.selectedCharacterName.TabIndex = 8;
            this.selectedCharacterName.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(281, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1009, 811);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 806);
            this.Controls.Add(this.selectedCharacterName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.accountCharacters);
            this.Controls.Add(this.wallet);
            this.Controls.Add(this.guilds);
            this.Controls.Add(this.world_name);
            this.Controls.Add(this.accountName);
            this.Name = "AccountView";
            this.Text = "AccountView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label accountName;
        private System.Windows.Forms.Label world_name;
        private System.Windows.Forms.ListBox guilds;
        private System.Windows.Forms.ListBox wallet;
        private System.Windows.Forms.ListBox accountCharacters;
        private System.Windows.Forms.Label selectedCharacterName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}