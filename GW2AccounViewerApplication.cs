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

namespace GW2AccountViewer
{
    public class GW2AccounViewerApplication
    {
        protected List<Character> mCharacters;

        protected List<Guild> mGuilds;

        protected Account mAccount;

        public event EventHandler dataSetChanged;

        protected OleDbConnection connection;

        protected OleDbCommand command = new OleDbCommand();

        protected virtual void callDataChangeCallback(EventArgs e)
        {
            EventHandler handler = dataSetChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public class DataSetChangedEventArgs : EventArgs
        {
            public int Threshold { get; set; }
        }


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

        public GW2AccounViewerApplication()
        {
            mCharacters = new List<Character>();
            mGuilds = new List<Guild>();
            load();
        }

        public void openConnection(){
            string connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= GW2AccountViewer.mdb";
            connection = new OleDbConnection(connetionString);
            try{
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }

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
                Console.WriteLine("execption in write");
                Console.WriteLine(ex.Message);
            }
        }

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
                Console.WriteLine("execption in write");
                Console.WriteLine(ex.Message);
            }
        }

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
                Console.WriteLine("execption in write");
                Console.WriteLine(ex.Message);
            }
        }

        public void saveApiKey(String key)
        {
            Properties.Settings.Default.ApiKey = key;
            Properties.Settings.Default.Save();
        }

        public String loadApiKey()
        {
            return Properties.Settings.Default.ApiKey;
        }

        public HttpWebRequest post(String url, AsyncCallback async)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            request.BeginGetResponse(async, request);
            return request;
        }

        public void refreshCharacters()
        {
            post("https://api.guildwars2.com/v2/characters?page=0&page_size=20&access_token=AA3ECC99-4BFB-9E49-B0E2-F96897A262BCF867D226-4054-4318-850F-0B667FF4CDFB", new AsyncCallback(parseCharacters));
        }

        public void refreshGuild(String guildId)
        {
            post("https://api.guildwars2.com/v1/guild_details.json?guild_id=" + guildId, new AsyncCallback(parseGuild));
        }

        public void refreshAccount()
        {
            post("https://api.guildwars2.com/v2/account?page=0&page_size=20&access_token=AA3ECC99-4BFB-9E49-B0E2-F96897A262BCF867D226-4054-4318-850F-0B667FF4CDFB", new AsyncCallback(parseAccount));
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
                Console.WriteLine("execption in check");
                Console.WriteLine(ex.Message);
            }
            mGuilds.Add(currentGuild);
            DataSetChangedEventArgs args = new DataSetChangedEventArgs();
            callDataChangeCallback(args);
            save();
        }

        public void save()
        {
            openConnection();
            if (mCharacters != null && mCharacters.Count > 0)
            {
                delete("Characters");
                foreach (Character character in mCharacters)
                {
                    writeCharacter(character.Name, character.GuildId);
                }
            }
            if (mGuilds != null && mGuilds.Count > 0)
            {
                delete("Guilds");
                foreach (Guild guild in mGuilds)
                {
                    writeGuild(guild.Name, guild.Id, guild.Tag);
                }
            }
            if (mAccount != null)
            {
                delete("Account");
                writeAccount(mAccount.Name, mAccount.Guilds);
            }
            closeConnection();
        }

        public void load()
        {
            openConnection();

            queryCharacters();

            queryGuilds();

            queryAccount();

            closeConnection();
        }

        public List<Character> getCharacters()
        {
            return mCharacters;
        }

        public List<Guild> getGuilds()
        {
            return mGuilds;
        }

        public Account getAccount()
        {
            return mAccount;
        }

    }
}
