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
        //private readonly SynchronizationContext synchronizationContext;

        public AccountView()
        {
            InitializeComponent();
            //synchronizationContext = SynchronizationContext.Current;
            application = GW2AccounViewerApplication.Instance;
            application.dataSetChanged += dataSetChanged;
            application.refreshCharacters();
            application.refreshAccount();
            buildUI();
        }

        public void dataSetChanged(object sender, EventArgs e)
        {
            base.Invoke((Action)delegate {buildUI(); }); 
        }

        public void buildUI()
        {
            if (application.getCharacters().Count != 0)
            {
                characters.Clear();
            }
            if (application.getGuilds().Count != 0)
            {
                guilds.Items.Clear();
            }
            foreach(Character character in application.getCharacters()){
                string[] arr = new string[4];
                ListViewItem itm;
                arr[0] = character.Name;
                itm = new ListViewItem(arr);
                characters.Items.Add(itm);
            }
            if (application.getAccount() != null)
            {
                accountName.Text = application.getAccount().Name;

                foreach (String guildId in application.getAccount().Guilds)
                {
                    guilds.Items.Add(guildId);
                }
            }
        }
    }
}
