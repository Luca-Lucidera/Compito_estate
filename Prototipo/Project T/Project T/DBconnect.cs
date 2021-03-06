using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Project_T
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            
            server = "sql11.freemysqlhosting.net";
            database = "sql11432119";
            uid = "sql11432119";
            password = "czrauTQEQy";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tata";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //metodi per gestire la tabella della tata
        public bool loginTata(string email, string password)
        {
            string query = "SELECT email, psw FROM tata";
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader["email"].ToString() == email
                        && dataReader["psw"].ToString() == password)
                    {
                        CloseConnection();
                        return true;
                    }
                }
                CloseConnection();
                return false;
            }
            CloseConnection();
            return false;
        }
        public bool registrati(string nome, string cognome, string email, string password, string zona_operativa, string image_path)
        {
            //La registrazione viene eseguita solo se nel database non è già presente
            if (!loginTata(email, password))
            {
                if (this.OpenConnection() == true)
                {
                    byte[] immagineBinaria = ImmagineABinario(image_path);
                    string query = String.Format("INSERT INTO tata(nome,cognome,email,psw,zona_operativa,occupata,image_path) VALUE('{0}','{1}','{2}','{3}','{4}',{5},@image_path)", nome, cognome, email, password, zona_operativa, false);
                    //string query ="INSERT INTO files(file_data) VALUE(@file_data)" ;

                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.Add("@image_path", MySqlDbType.Blob);
                    cmd.Parameters["@image_path"].Value = immagineBinaria;
                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                    return true;
                }
                return false;
            }
            return false;
        }
        public int getIdByEmail(string email)
        {

            if (this.OpenConnection() == true)
            {
                int id = -1;
                string query = String.Format("SELECT id FROM tata WHERE email='{0}'", email);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();//se devo prendere un solo valore non devo fare vari cicli per il dataReader
                id = Convert.ToInt32(dataReader["id"]);
                this.CloseConnection();
                dataReader.Close();
                return id;
            }
            return -1;
        }

        public int OccupataByEmail(string email)
        {

            if (this.OpenConnection() == true)
            {
                int occupata = 0;
                string query = String.Format("SELECT occupata FROM tata WHERE email='{0}'", email);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();//se devo prendere un solo valore non devo fare vari cicli per il dataReader
                occupata = Convert.ToInt32(dataReader["occupata"]);
                this.CloseConnection();
                dataReader.Close();
                return occupata;
            }
            return -1;
        }
        public List<string> GetTata(string email)
        {
            if (this.OpenConnection() == true)
            {
                string query = String.Format("SELECT * FROM tata where email='{0}'", email);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                List<string> tata = new List<string>();
                tata.Add(dataReader["id"].ToString());
                tata.Add(dataReader["nome"].ToString());
                tata.Add(dataReader["cognome"].ToString());
                tata.Add(dataReader["email"].ToString());
                tata.Add(dataReader["psw"].ToString());
                tata.Add(dataReader["zona_operativa"].ToString());
                tata.Add(dataReader["occupata"].ToString());
                tata.Add(dataReader["image_path"].ToString());
                dataReader.Close();
                this.CloseConnection();
                return tata;
            }
            return null;
        }
        public bool CambiaMail(string email, int id)
        {
            if (this.OpenConnection() == true)
            {
                string query = String.Format("UPDATE tata SET email = '{0}' WHERE id = {1}", email, id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
                return true;
            }
            return false;
        }

        public bool CambiaOccupazione(int id)
        {
            if (OpenConnection() == true)
            {
                string query = String.Format("SELECT occupata FROM tata WHERE id = {0}", id);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();//se devo prendere un solo valore non devo fare vari cicli per il dataReader
                bool occupata = Convert.ToBoolean(dataReader["occupata"]);
                dataReader.Close();
                if (occupata)
                {
                    query = String.Format("UPDATE tata SET occupata = false WHERE id = {0}", id);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    query = String.Format("UPDATE tata SET occupata = true WHERE id = {0}", id);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
                return true;
            }
            return false;
        }

        public bool cambiaZonaOperativa(string zona_operativa, int id)
        {
            if (OpenConnection() == true)
            {
                string query = String.Format("UPDATE tata SET zona_operativa = '{0}' WHERE id = {1}", zona_operativa, id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            return false;
        }

        public bool CambiaPassword(string password, int id)
        {
            if (OpenConnection() == true)
            {
                string query = String.Format("UPDATE tata SET psw = '{0}' WHERE id = {1}", password, id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            return false;
        }

        public string getEmailById(int id)
        {
            if (this.OpenConnection() == true)
            {
                string email = "";
                string query = String.Format("SELECT email FROM tata WHERE id='{0}'", id);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();//se devo prendere un solo valore non devo fare vari cicli per il dataReader
                email = Convert.ToString(dataReader["email"]);
                this.CloseConnection();
                dataReader.Close();
                return email;
            }
            return "-1";
        }

        //metodi per gesitere la tabella degli utenti
        public bool loginUtente(string email, string password)
        {
            string query = "SELECT email, psw FROM utenti_registrati";
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader["email"].ToString() == email
                        && dataReader["psw"].ToString() == password)
                    {
                        CloseConnection();
                        return true;
                    }
                }
                CloseConnection();
                return false;
            }
            CloseConnection();
            return false;
        }
        public bool registraUtente(string nome, string cognome, string email, string password, int nTelefono)
        {

            if (!loginUtente(email, password))
            {
                if (this.OpenConnection() == true)
                {
                    string query = String.Format("INSERT INTO utenti_registrati(nome,cognome,email,psw,telefono) VALUE('{0}','{1}','{2}','{3}','{4}')", nome, cognome, email, password, nTelefono);
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                    return true;
                }
                return false;
            }
            return false;
        }
        public List<string>[] Cerca(string zona)
        {
            if (OpenConnection() == true)
            {
                string query = String.Format("SELECT nome,cognome,email,zona_operativa FROM tata WHERE zona_operativa = '{0}' AND OCCUPATA = 0", zona);
                List<string>[] tabella = new List<string>[4];//4 colonne
                tabella[0] = new List<string>();
                tabella[1] = new List<string>();
                tabella[2] = new List<string>();
                tabella[3] = new List<string>();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    tabella[0].Add(dataReader["nome"] + "");
                    tabella[1].Add(dataReader["cognome"] + "");
                    tabella[2].Add(dataReader["email"] + "");
                    tabella[3].Add(dataReader["zona_operativa"] + "");
                }
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return tabella;
            }
            return null;
        }
        

        public byte[] ImmagineABinario(string image_path)
        {
            FileStream fs;
            BinaryReader br;
            string FileName = image_path;
            byte[] ImageData;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return ImageData;
        }
        public Bitmap PrendiFotoDalBD(string email)
        {

            if (OpenConnection() == true)
            {
                string query = String.Format("select image_path from tata where email='{0}'",email);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                { 

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["image_path"]);

                    Bitmap bm = new Bitmap(ms);
                    return bm;
                }
            }
            return null;
            
            
        }
    }

}
