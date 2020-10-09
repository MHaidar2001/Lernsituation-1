using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaft
{
    public partial class Tabelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Mannschaftenladen();

            }
            int id = Convert.ToInt32(EditID.ToString());

            if (id > 0)
            {
                tbl();
                ueberschrift();

            }
        }

        public void ueberschrift()
        {
            tblLabel.Text = "";

            string sqlstring = "SELECT `Sportart` , `Name` FROM `turnier` WHERE `ID` = " + EditID;


            MySqlConnection Conn = new MySqlConnection();
            string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch (MySqlException)
            {
                //Datenbank nicht verfügbar

                Label1.Text = "Datenbank nicht erreichbar";

                return;
            }
            MySqlCommand command = new MySqlCommand(sqlstring, Conn);

            //Abfrage ausführen
            MySqlDataReader rdr = command.ExecuteReader();

            rdr.Read();


            tblLabel.Text = "Tabelle für das " + rdr.GetValue(0).ToString() + " - Turnier '" + rdr.GetValue(1).ToString() + "'";
        }

        public void tbl()
        {
            string sqlstring = "SELECT  t.name, m.`erzielteTore` , m.`gegenTore` , m.`Punkte` FROM `mannschaft_has_turnier` m JOIN mannschaft t ON t.id = m.`Mannschaft_ID` WHERE `Turnier_ID` = "+EditID+" ORDER BY `Punkte` DESC";
            MySqlConnection Conn = new MySqlConnection();
            string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch (MySqlException)
            {
                //Datenbank nicht verfügbar

                Label1.Text = "Datenbank nicht erreichbar";

                return;
            }


            MySqlCommand command = new MySqlCommand(sqlstring, Conn);

            //Abfrage ausführen
            MySqlDataReader rdr = command.ExecuteReader();

            TableRow row = new TableRow();
            TableCell c1 = new TableCell();


            while (rdr.Read())
            {
                row = new TableRow();
                int spaltenindex = 0;
                c1 = new TableCell();
                c1.Text = Table2.Rows.Count.ToString();
                row.Cells.Add(c1);
                for (spaltenindex = 0; spaltenindex < rdr.FieldCount; spaltenindex++)
                {
                    c1 = new TableCell();
                    c1.Text = rdr.GetValue(spaltenindex).ToString();
                    row.Cells.Add(c1);
                }

                this.Table2.Rows.Add(row);
            }

            
        }

        public void Mannschaftenladen()
        {
            if (!IsPostBack)
            {
                MsListen.Items.Clear();

            }
            string sqlstring = "SELECT * FROM `turnier`";
            MySqlConnection Conn = new MySqlConnection();
            string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch (MySqlException)
            {
                //Datenbank nicht verfügbar

                Label1.Text = "Datenbank nicht erreichbar";

                return;
            }

            MySqlCommand command = new MySqlCommand(sqlstring, Conn);


            //Abfrage ausführen
            MySqlDataReader rdr = command.ExecuteReader();



            while (rdr.Read())
            {


                MsListen.Items.Add(rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString() + ", " + rdr.GetValue(2).ToString());



            }

            rdr.Close();
            Conn.Close();


        }
        static string EditID = "0";
        protected void MSbtn_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < MsListen.Items.Count; index++)
            {
                if (MsListen.Items[index].Selected)
                {
                    string sqlstring = "SELECT * FROM `turnier`";
                    MySqlConnection Conn = new MySqlConnection();
                    string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn = new MySqlConnection();
                        Conn.ConnectionString = MyConnectionString;
                        Conn.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }

                    MySqlCommand command = new MySqlCommand(sqlstring, Conn);


                    //Abfrage ausführen
                    MySqlDataReader rdr = command.ExecuteReader();



                    for (int i = 0; i < index + 1; i++)
                    {
                        rdr.Read();

                        EditID = rdr.GetValue(0).ToString();
                    }
                    break;


                    rdr.Close();

                }

            }
            Response.Redirect("Tabelle.aspx");
        }
    }
}