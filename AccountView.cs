using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GW2AccountViewer
{
    public partial class AccountView : Form
    {

        GW2AccounViewerApplication application;
        Character selectedCharacter;

        public AccountView()
        {
            InitializeComponent();
            application = GW2AccounViewerApplication.Instance;
            application.dataSetChanged += dataSetChanged;
            application.refreshCharacters();
            application.refreshAccount();
            application.refreshWorlds();
            buildUI();
        }

        public void dataSetChanged(object sender, EventArgs e)
        {
            try {
                base.Invoke((Action)delegate { buildUI(); });
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in buildUI");
                Console.WriteLine(ex.Message);
            }
        }

        public void buildUI()
        {
            if (application.getCharacters().Count != 0 && application.getCharacters().Count != accountCharacters.Items.Count)
            {
                accountCharacters.Items.Clear();
            }
            if (application.getGuilds().Count != 0)
            {
                guilds.Items.Clear();
            }
            World accountWorld = application.getAccountWorld();
            if (accountWorld != null)
            {
                world_name.Text = accountWorld.Name;
            }
            {
                guilds.Items.Clear();
            }
            if (application.getCharacters().Count != accountCharacters.Items.Count)
            {
                foreach (Character character in application.getCharacters())
                {
                    accountCharacters.Items.Add(character.Name);
                }
            }
            if (application.getAccount() != null)
            {
                accountName.Text = application.getAccount().Name;
            }
            try {
                foreach (Guild guild in application.getGuilds())
                {
                    guilds.Items.Add(guild.Name);
                }
            }catch(Exception ex)
            {
                Console.WriteLine("exception in buildUI");
                Console.WriteLine(ex.Message);
            }
            if (accountCharacters.SelectedIndex < 0)
            {
                if (accountCharacters.Items.Count > 0)
                {
                    accountCharacters.SetSelected(0, true);
                }
            }
            if(selectedCharacter != null)
            {
                updateSelectedCharacter();
            }
        }

        private void character_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountCharacters.SelectedIndex >= 0)
            {
                if (accountCharacters.SelectedIndex <= application.getCharacters().Count)
                {
                    selectedCharacter = application.getCharacters()[accountCharacters.SelectedIndex];
                    selectCharacter();
                }
            }
        }


        private void selectCharacter()
        {
            selectedCharacterName.Text = selectedCharacter.Name;

            if (selectedCharacter.Equipment != null)
            {
                foreach (Object label in this.Controls)
                {
                    if (label is Label)
                    {
                        if (((Label)label).Name.Contains("EquipmentLabel"))
                        {
                            this.Controls.Remove(((Label)label));
                        }
                    }
                }
                foreach (Object pictureBox in this.Controls)
                {
                    if (pictureBox is PictureBox)
                    {
                        PictureBox image = (PictureBox)pictureBox;
                        if (image.Name.Contains("ItemPicture"))
                        {
                            this.Controls.Remove(image);
                        }
                    }
                }
                int count = 0;
                int row = 0;
                foreach (Equipment equipment in selectedCharacter.Equipment)
                {
                    Label label = new Label();
                    label.Location = new Point(200 + row, 100 + count);
                    label.Size = new Size(150, 20);
                    label.Text = equipment.Slot;
                    label.Name = "EquipmentLabel" + equipment.Id;
                    this.Controls.Add(label);
                  
                    PictureBox picture = new PictureBox();
                    picture.Location = new Point(300 + row, 100 + count);
                    picture.Size = new Size(64, 64);
                    picture.Text = equipment.Slot;
                    picture.Name = "ItemPicture" + equipment.Id;
                    this.Controls.Add(picture);

                    row += 210;
                    if (row > 630)
                    {
                        count += 70;
                        row = 0;
                    }

                }
            }


        }

        private void updateSelectedCharacter()
        {
            foreach (Object pictureBox in this.Controls)
            {
                if (pictureBox is PictureBox)
                {
                   PictureBox image = (PictureBox)pictureBox;
                   Int32 itemId = Int32.Parse(image.Name.ToString().Replace("ItemPicture", ""));
                   Item item = application.getItemById(itemId);
                   if (item != null)
                   {
                       ItemImage itemImage = application.getItemImageByUrl(item.Icon);
                       if (image.BackgroundImage == null)
                       {
                            if (itemImage != null)
                            {
                                image.BackgroundImage = itemImage.image;
                            }else
                            {
                                application.refreshItemImage(item.Icon);
                            }
                       }
                    }else
                    {
                        application.refreshItem(itemId);
                    }
                }
            }
        }
    }
}
