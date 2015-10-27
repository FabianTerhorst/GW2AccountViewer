using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using GW2CSharp.V2.Unauthenticated.Currencies;
using GW2CSharp.V2.Unauthenticated.Currencies.Enums;

using GW2CSharp.V2.Authenticated.Pvp;
using GW2CSharp.V2.Authenticated.Pvp.Stats;
using GW2CSharp.V2.Authenticated.Pvp.Stats.Enums;

using GW2CSharp.V2.Authenticated.TokenInfo;

using GW2CSharp;
using GW2CSharp.Enums;

using System.Data.OleDb;
using System.Drawing;

namespace GW2AccountViewer
{
    public class GW2AccounViewerApplication
    {

        //charactere
        protected List<Character> mCharacters;

        //gilden
        protected List<Guild> mGuilds;

        //welten
        protected List<World> mWorlds;

        //Währung
        protected List<Currency> mCurrencies;

        //Account Währung
        protected List<Currency> mAccountCurrencies;

        //accounts
        protected Account mAccount;

        //items die geladen worden sind
        protected List<Item> mItems;

        //images die geladen worden sind
        protected List<ItemImage> mImages;

        //items die derzeit gerefreshed werden
        protected List<Int32> mRefreshingItems;

        //images die derzeit gerefreshed werden
        protected List<String> mRefreshingImages;

        //callback
        public event EventHandler dataSetChanged;

        //datenbank connection
        protected OleDbConnection connection;

        //datenbank command
        protected OleDbCommand command = new OleDbCommand();

        //callback auslösen
        protected virtual void callDataChangeCallback(EventArgs e)
        {
            EventHandler handler = dataSetChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //callback arguments
        public class DataSetChangedEventArgs : EventArgs
        {
            public int Threshold { get; set; }
        }

        //singleton
        private static readonly GW2AccounViewerApplication instance = new GW2AccounViewerApplication();

         static GW2AccounViewerApplication()
        {
        }

        public static GW2AccounViewerApplication Instance
        {
            get
            {
                return instance;
            }
        }

        //application initialiseren
        public GW2AccounViewerApplication()
        {
            openConnection();
            mCharacters = new List<Character>();
            mGuilds = new List<Guild>();
            mWorlds = new List<World>();
            mItems = new List<Item>();
            mImages = new List<ItemImage>();
            mRefreshingImages = new List<String>();
            mRefreshingItems = new List<Int32>();
            mCurrencies = new List<Currency>();
            mAccountCurrencies = new List<Currency>();
            load();
        }

        //datenbank verbindung öffnen
        public void openConnection(){
            string connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= GW2AccountViewer.mdb";
            connection = new OleDbConnection(connetionString);
            try{
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in connection create");
                Console.WriteLine(ex.Message);
            }
        }

        //datenbank verbindung schließen
        public void closeConnection()
        {
            try {
                connection.Close();
            }catch(Exception ex)
            {
                Console.WriteLine("Connection wird noch verwendet");
                Console.WriteLine(ex.Message);
            }
        }

        //character daten aus datenbank laden
        public void queryCharacters()
        {
            OleDbCommand command;
            try
            {
                command = new OleDbCommand("Select * From Characters", connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    mCharacters.Clear();
                    while (reader.Read())
                    {
                        Character character = new Character();
                        character.Id = reader.GetInt32(0);
                        character.Name = reader.GetString(1);
                        character.GuildId = reader.GetString(2);
                        mCharacters.Add(character);

                    }
                    save();
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //welt daten aus datenbank laden
        public void queryWorlds()
        {
            OleDbCommand command;
            try
            {
                command = new OleDbCommand("Select * From Worlds", connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    mWorlds.Clear();
                    while (reader.Read())
                    {
                        World world = new World();
                        world.Id = Int32.Parse(reader["Id"].ToString());
                        world.Name = reader["Name"].ToString();
                        world.Population = reader["Population"].ToString();
                        mWorlds.Add(world);

                    }
                    save();
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //gilden daten aus datenbank laden
        public void queryGuilds()
        {
            OleDbCommand command;
            try
            {
                command = new OleDbCommand("Select * From Guilds", connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    mCharacters.Clear();
                    while (reader.Read())
                    {
                        Guild guild = new Guild();
                        guild.Id = reader.GetString(0);
                        guild.Name = reader.GetString(1);
                        guild.Tag = reader.GetString(2);
                        mGuilds.Add(guild);

                    }
                    save();
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //account daten aus datenbank laden
        public void queryAccount()
        {
            OleDbCommand command;
            try
            {
                command = new OleDbCommand("Select * From Account", connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    mCharacters.Clear();
                    while (reader.Read())
                    {

                       String guildIds = reader.GetString(1);

                       string[] guildIdsArray = guildIds.Split(new[] {";"}, StringSplitOptions.None);

                        List<String> guildIdsList = new List<String>();

                        foreach(String guildId in guildIdsArray){
                            guildIdsList.Add(guildId);
                        }

                        mAccount = new Account();
                        mAccount.Name = reader.GetString(0);
                        mAccount.Guilds = guildIdsList;
                    }
                    save();
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //character daten in datenbank schreiben
        public void writeCharacter(String name, String guildId)
        {
            try
            {
                var cmd = new OleDbCommand("INSERT INTO Characters (Name,GuildId) VALUES (@x,@y)");
                cmd.Parameters.AddRange(new[] {
                new OleDbParameter("@x", name),
                new OleDbParameter("@y", guildId),
                });
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in write");
                Console.WriteLine(ex.Message);
            }
        }

        //welt daten in datenbank schreiben
        public void writeWorld(Int32 id, String name, String population)
        {
            try
            {
                var cmd = new OleDbCommand("INSERT INTO Worlds (Id,Name,Population) VALUES (@x,@y,@z)");
                cmd.Parameters.AddRange(new[] {
                new OleDbParameter("@x", id),
                new OleDbParameter("@y", name),
                new OleDbParameter("@z", population),
                });
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in write");
                Console.WriteLine(ex.Message);
            }
        }

        //gilden daten in datenbank schreiben
        public void writeGuild(String name, String guildId, string guildTag)
        {
            try
            {
                var cmd = new OleDbCommand("INSERT INTO Guilds (Name,GuildId,Tag) VALUES (@x,@y,@z)");
                cmd.Parameters.AddRange(new[] {
                new OleDbParameter("@x", name),
                new OleDbParameter("@y", guildId),
                new OleDbParameter("@y", guildTag),
                });
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in write");
                Console.WriteLine(ex.Message);
            }
        }

        //account daten in datenbank schreiben
        public void writeAccount(String name, List<String> guilds)
        {

            String guildString = "";

            foreach (String guildId in guilds)
            {
                guildString += guildId + ";";
            }

            try
            {
                var cmd = new OleDbCommand("INSERT INTO Account (Name,Guilds) VALUES (@x,@y)");
                cmd.Parameters.AddRange(new[] {
                new OleDbParameter("@x", name),
                new OleDbParameter("@y", guildString),
                });
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("execption in write");
                Console.WriteLine(ex.Message);
            }
        }

        //tabellendaten löschen
        public void delete(String table)
        {
            try
            {
                var cmd = new OleDbCommand("DELETE * FROM " + table);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception in delete");
                Console.WriteLine(ex.Message);
            }
        }

        //api key speichern
        public void saveApiKey(String key)
        {
            Properties.Settings.Default.ApiKey = key;
            Properties.Settings.Default.Save();
        }

        //api key laden
        public String loadApiKey()
        {
            return Properties.Settings.Default.ApiKey;
        }

        //http post/get 
        public HttpWebRequest post(String url, AsyncCallback async)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            request.BeginGetResponse(async, request);
            return request;
        }

        //bild synchron von url laden
        public Image GetImageFromURL(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebReponse.GetResponseStream();
            return Image.FromStream(stream);
        }

        //item aktualisieren
        public void refreshItem(Int32 id)
        {
            //item zur liste der aktualiserenden items hinzufügen damit kein item gleichzeitig geladen wird
            if (!mRefreshingItems.Contains(id))
            {
                mRefreshingItems.Add(id);
                post("https://api.guildwars2.com/v2/items/" + id, new AsyncCallback(parseItem));
            }else
            {
                Console.WriteLine("item refresh is in progress");
            }
        }

        //bild von url aktualisieren
        public void refreshItemImage(String url)
        {
            //image zur liste der aktualiserenden images hinzufügen damit kein image gleichzeitig geladen wird
            if (!mRefreshingImages.Contains(url))
            {
                mRefreshingImages.Add(url);
                post(url, new AsyncCallback(addImage));
            }else
            {
                Console.WriteLine("image refresh is in progress");
            }
        }

        //Alle Charactere aktualisieren
        public void refreshCharacters()
        {
            post("https://api.guildwars2.com/v2/characters?page=0&page_size=20&access_token=AA3ECC99-4BFB-9E49-B0E2-F96897A262BCF867D226-4054-4318-850F-0B667FF4CDFB", new AsyncCallback(parseCharacters));
        }

        //Informationen zu einer bestimmten Gilde aktualisieren
        public void refreshGuild(String guildId)
        {
            post("https://api.guildwars2.com/v1/guild_details.json?guild_id=" + guildId, new AsyncCallback(parseGuild));
        }

        //Accountdaten aktualisieren
        public void refreshAccount()
        {
            post("https://api.guildwars2.com/v2/account?page=0&page_size=20&access_token=AA3ECC99-4BFB-9E49-B0E2-F96897A262BCF867D226-4054-4318-850F-0B667FF4CDFB", new AsyncCallback(parseAccount));
        }

        //Accountdaten aktualisieren
        public void refreshAccountWallet()
        {
            post("https://api.guildwars2.com/v2/account/wallet?page=0&page_size=20&access_token=AA3ECC99-4BFB-9E49-B0E2-F96897A262BCF867D226-4054-4318-850F-0B667FF4CDFB", new AsyncCallback(parseAccountWallet));
        }

        //Weltenliste aktualisieren
        public void refreshWorlds()
        {
            post("https://api.guildwars2.com/v2/worlds?ids=all", new AsyncCallback(parseWorlds));
        }

        //Alle Charactere aktualisieren
        public void refreshCurrencies()
        {
            post("https://api.guildwars2.com/v2/currencies?ids=all", new AsyncCallback(parseCurrencies));
        }

        public void refreshGuilds()
        {
            if (mAccount != null && mAccount.Guilds != null)
            {
                foreach (String guildId in mAccount.Guilds)
                {
                    refreshGuild(guildId);
                }
            }
        }

        //image aus inputstream und in Objectliste hinzufügen
        void addImage(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();     
            ItemImage itemImage = new ItemImage();
            itemImage.image = Image.FromStream(dataStream);
            String responseUrl = response.ResponseUri.ToString();
            itemImage.url = responseUrl;
            mImages.Add(itemImage);
            //image wieder aus der liste der refreshenden images entfernen da es gerefreshed wurde
            foreach (String url in mRefreshingImages)
            {
                if (url == responseUrl)
                {
                    mRefreshingImages.Remove(url);
                    break;
                }
            }
            response.Close();
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
            save();
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseCharacters(IAsyncResult result)
        {
                WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                response.Close();
                mCharacters = JsonConvert.DeserializeObject<List<Character>>(responseFromServer);
                DataSetChangedEventArgs args = new DataSetChangedEventArgs();
                callDataChangeCallback(args);
                save();
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseCurrencies(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            mCurrencies = JsonConvert.DeserializeObject<List<Currency>>(responseFromServer);
            refreshAccountWallet();
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseAccountWallet(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            List<CurrencyValue> currencyValues = JsonConvert.DeserializeObject<List<CurrencyValue>>(responseFromServer);
            for (int i = 0; i < currencyValues.Count; i++)
            {
                foreach (Currency currency in mCurrencies)
                {
                    if(currency.Id == currencyValues[i].Id)
                    {
                        currency.Value = currencyValues[i].Value;
                        mAccountCurrencies.Add(currency);
                    }
                }
            }
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseWorlds(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            mWorlds = JsonConvert.DeserializeObject<List<World>>(responseFromServer);
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
            save();
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseAccount(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            mAccount = JsonConvert.DeserializeObject<Account>(responseFromServer);
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
            save();
            refreshGuilds();
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseItem(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            Item item = JsonConvert.DeserializeObject<Item>(responseFromServer);
            mItems.Add(item);
            //item wieder aus der liste der refreshenden items entfernen da es gerefreshed wurde
            foreach (Int32 itemId in mRefreshingItems)
            {
                if (itemId == item.Id)
                {
                    mRefreshingItems.Remove(itemId);
                    break;
                }
            }
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
            save();
        }

        //Json aus http request serialisieren und zur Objektliste hinzufügen und speichern
        void parseGuild(IAsyncResult result)
        {
            WebResponse response = ((WebRequest)result.AsyncState).EndGetResponse(result);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            Guild currentGuild = JsonConvert.DeserializeObject<Guild>(responseFromServer);
            try {
                foreach (Guild guild in mGuilds) {
                    if (guild.Id.Equals(currentGuild.Id)) {
                        mGuilds.Remove(guild);
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine("exception in check");
                Console.WriteLine(ex.Message);
            }
            mGuilds.Add(currentGuild);
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
            save();
        }

        //speichert aller objecte aus der Singleton Application in die Datenbank
        public void save()
        {
            openConnection();
            if (mCharacters != null && mCharacters.Count > 0)
            {
                delete("Characters");
                try
                {
                    foreach (Character character in mCharacters)
                    {
                        writeCharacter(character.Name, character.GuildId);
                    }
                }catch(Exception ex)
                {

                }
            }
            if (mGuilds != null && mGuilds.Count > 0)
            {
                delete("Guilds");
                try
                {
                    foreach (Guild guild in mGuilds)
                    {
                        writeGuild(guild.Name, guild.Id, guild.Tag);
                    }

                }catch(Exception ex)
                {

                }
                
            }
            if (mAccount != null)
            {
                delete("Account");
                writeAccount(mAccount.Name, mAccount.Guilds);
            }

            if (mWorlds != null && mWorlds.Count > 0)
            {
                delete("Worlds");
                try {
                    foreach (World world in mWorlds)
                    {
                        writeWorld(world.Id, world.Name, world.Population);
                    }
                }catch(Exception ex)
                {

                }
            }

            //closeConnection();
        }

        //lädt die objecte aus der Datenbank in die Sigleton Application
        public void load()
        {
            openConnection();

            queryCharacters();

            queryGuilds();

            queryAccount();

            queryWorlds();

            //closeConnection();
        }

        public List<Character> getCharacters()
        {
            return mCharacters;
        }

        public List<Guild> getGuilds()
        {
            return mGuilds;
        }

        public World getAccountWorld()
        {
            if(mAccount != null)
            {
                try {
                    foreach (World world in mWorlds)
                    {
                        if (world.Id == mAccount.World)
                        {
                            return world;
                        }
                    }
                }catch(Exception ex)
                {

                }
            }

            return null;
        }

        public Account getAccount()
        {
            return mAccount;
        }

        public Item getItemById(Int32 id)
        {
            try {
                foreach (Item item in mItems)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }
            }catch(Exception ex)
            {

            }
            return null;
        }

        public ItemImage getItemImageByUrl(String url)
        {
            try {
                foreach (ItemImage itemImage in mImages)
                {
                    if (itemImage.url == url)
                    {
                        return itemImage;
                    }
                }
            }catch(Exception ex)
            {

            }
            return null;
        }

        public List<Currency> getCurrencies()
        {
            return mAccountCurrencies;
        }

    }
}
