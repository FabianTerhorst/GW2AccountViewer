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
            application.refreshCurrencies();
            buildUI();
        }

        //callback methode
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

        //oberfläche nach callback neubauen
        public void buildUI()
        {
            //nur charactere liste leeren wenn character sich geändert haben oder exestieren
            if (application.getCharacters().Count != 0 && application.getCharacters().Count != accountCharacters.Items.Count)
            {
                accountCharacters.Items.Clear();
            }
            //nur account wallet leeren wenn diese vorhanden sind
            if(application.getCurrencies().Count != 0)
            {
                wallet.Items.Clear();
            }
            //nur gilden liste leeren wenn gilden vorhanden sind
            if (application.getGuilds().Count != 0)
            {
                guilds.Items.Clear();
            }
            //account welt namen anzeigen
            World accountWorld = application.getAccountWorld();
            if (accountWorld != null)
            {
                world_name.Text = accountWorld.Name;
            }
            {
                guilds.Items.Clear();
            }
            //charactere liste nur füllen wenn sich charactere geändert haben
            if (application.getCharacters().Count != accountCharacters.Items.Count)
            {
                foreach (Character character in application.getCharacters())
                {
                    accountCharacters.Items.Add(character.Name);
                }
            }
            //account namen anzeigen wenn dieser vorhanden ist
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
            //account wallet füllen wenn dieser vorhanden ist
            if (application.getCurrencies() != null)
            {
                try
                {
                    foreach (Currency currency in application.getCurrencies())
                    {
                        wallet.Items.Add(currency.Name + " " + currency.Value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("exception in buildUI");
                    Console.WriteLine(ex.Message);
                }
            }

            //nur default selektieren wenn keiner selektiert ist
            if (accountCharacters.SelectedIndex < 0)
            {
                //nur wenn ein character vorhanden ist kann der erste default selektiert werden
                if (accountCharacters.Items.Count > 0)
                {
                    accountCharacters.SetSelected(0, true);
                }
            }
            //wenn ein character selektiert ist nach callback das equipment updaten
            if(selectedCharacter != null)
            {
                updateSelectedCharacter();
            }
        }

        //listbox selektion hat sich geändert
        private void character_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checken ob selektion wirklich stattgefunden hat
            if (accountCharacters.SelectedIndex >= 0)
            {
                //checken ob ein character mit diesen selektierten index exestieren kann
                if (accountCharacters.SelectedIndex <= application.getCharacters().Count)
                {
                    selectedCharacter = application.getCharacters()[accountCharacters.SelectedIndex];
                    selectCharacter();
                    updateSelectedCharacter();
                }
            }
        }

        //nach character selektierung die oberfläche ändern 
        private void selectCharacter()
        {
            selectedCharacterName.Text = selectedCharacter.Name;

            if (selectedCharacter.Equipment != null)
            {
                //leere benutzeroberfläche von früheren character die labels
                foreach (Label lb in this.Controls.OfType<Label>().ToArray())
                {
                    if (lb.Name.Contains("EquipmentLabel"))
                    {
                        lb.Dispose();
                        this.Controls.Remove(lb);
                    }
                }

                //leere benutzeroberfläche von früheren character die picture boxen
                foreach (PictureBox pb in this.Controls.OfType<PictureBox>().ToArray())
                {
                    if (pb.Name.Contains("ItemPicture"))
                    {
                        pb.Dispose();
                        this.Controls.Remove(pb);
                    }
                }

                int count = 0;
                int row = 0;

                foreach (Equipment equipment in selectedCharacter.Equipment)
                {
                    Label label = new Label();
                    label.Location = new Point(350 + row, 100 + count);
                    label.Size = new Size(100, 20);
                    label.Text = equipment.Slot;
                    label.Name = "EquipmentLabel" + equipment.Id;
                    this.Controls.Add(label);

                    PictureBox picture = new PictureBox();
                    picture.Location = new Point(450 + row, 100 + count);
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

        //nach callback die selektierte characteroberfläche ändern
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
