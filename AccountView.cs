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
            if (application.getCharacters().Count != 0)
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
            foreach (Character character in application.getCharacters()){
                accountCharacters.Items.Add(character.Name);
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
            if (accountCharacters.Items.Count > 0)
            {
                accountCharacters.SetSelected(0, true);
            }
        }

        private void character_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountCharacters.SelectedIndex >= 0)
            {
                if (accountCharacters.SelectedIndex <= application.getCharacters().Count)
                {
                    updateSelectedCharacter(application.getCharacters()[accountCharacters.SelectedIndex]);
                }
            }
        }

        private void updateSelectedCharacter(Character character)
        {
            selectedCharacterName.Text = character.Name;

            if(character.Equipment != null)
            {
                foreach(Object label in this.Controls)
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
                        if (((PictureBox)pictureBox).Name.Contains("ItemPicture"))
                        {
                            this.Controls.Remove(((PictureBox)pictureBox));
                        }
                    }
                }
                int count = 0;
                foreach (Equipment equipment in character.Equipment)
                {
                    Label label = new Label();
                    label.Location = new Point(200, 100 + count);
                    label.Size = new Size(150, 20);
                    label.Text = equipment.Slot;
                    label.Name = "EquipmentLabel" + count;
                    this.Controls.Add(label);
                    Item item = application.getItemById(equipment.Id);
                    if(item == null)
                    {
                        application.refreshItem(equipment.Id);
                    }
                    else
                    {
                        PictureBox picture = new PictureBox();
                        picture.Location = new Point(300, 100 + count);
                        picture.Size = new Size(150, 150);
                        picture.Text = equipment.Slot;
                        picture.Name = "ItemPicture" + count;
                        ItemImage itemImage = application.getItemImageByUrl(item.Icon);
                        if (itemImage != null)
                        {
                            picture.BackgroundImage = itemImage.image;
                        }
                        else
                        {
                            application.refreshItemImage(item.Icon);
                        }

                        this.Controls.Add(picture);
                    }
                    count += 170;
                }
            }
            

        }
    }
}
