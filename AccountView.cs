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
        }
    }
}
