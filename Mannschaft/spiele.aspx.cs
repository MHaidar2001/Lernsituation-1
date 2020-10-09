using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaft
{
    public partial class spiele : System.Web.UI.Page
    {


        static string EditID = "0";


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Mannschaftenladen();
                
            }
            
            int id = Convert.ToInt32(EditID.ToString());
            if(id>0)
            {
              tbl();
                if (!IsPostBack)
                {
                    listeLaden();

                }
              ueberschrift();
               
            }
            Table3.Visible = false;
            aenderung.Visible = false;


        }

        public void ueberschrift()
        {
            tblLabel.Text = "";

            string sqlstring = "SELECT `Sportart` , `Name` FROM `turnier` WHERE `ID` = "+EditID;


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
            

                tblLabel.Text = "Vorhandene Spiele des "+ rdr.GetValue(0).ToString() + " - Turniers '"+ rdr.GetValue(1).ToString()+"'";
            
        }
        /// <summary>
        /// 
        /// </summary>
        public void listeLaden()
        {
            
            string sqlstring = "SELECT m.id, m.name FROM `mannschaft_has_turnier` t JOIN mannschaft m ON m.id = t.`Mannschaft_ID` WHERE `Turnier_ID` =" + EditID;
        

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


                M1List.Items.Add(rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString());
                M2List.Items.Add(rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString());

            }

            if (M1List.Items.Count == 0)
            {
                M1List.Items.Add("bisher keine Mannschaften");
                M2List.Items.Add("bisher keine Mannschaften");
                speichernbt.Visible = false;
            }

            
            Conn.Close();
            rdr.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public void tbl()
        {
            string sqlstring = "SELECT s.ID, m.name, z.name, `ToreM1` , `ToreM2` FROM `spiele` s JOIN mannschaft m ON m.id = s.`Mannschaft1_ID` JOIN mannschaft z ON z.id = s.`Mannschaft2_ID` WHERE `turnier_id` ="+EditID;
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
            Button bt = new Button();
            int index = 1;

            while (rdr.Read())
            {
                row = new TableRow();
                int spaltenindex = 0;
                for (spaltenindex = 0; spaltenindex < rdr.FieldCount; spaltenindex++)
                {
                    c1 = new TableCell();
                    c1.Text = rdr.GetValue(spaltenindex).ToString();
                    row.Cells.Add(c1);
                }
                //Bearbeiten
                bt = new Button();
                bt.ID = index.ToString();
                bt.Click += bearbeiten_Click;
                c1 = new TableCell();

                c1.Controls.Add(bt);
                row.Cells.Add(c1);
                bt.Text = "bearbeiten";
                bt.BackColor = Color.Green;



                this.Table2.Rows.Add(row);


                index++;
            }

            for (int i = 0; i < Table2.Rows.Count - 1; i++)
            {
                c1 = new TableCell();
                bt = new Button();
                c1.Controls.Add(bt);
                bt.Text = "Löschen";
                bt.Click += loeschen_Click;
                bt.BackColor = Color.Red;

                int zahl = 0;
                zahl = Table2.Rows.Count + i + 1;
                bt.ID = zahl.ToString();



                this.Table2.Rows[i + 1].Controls.Add(c1);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public void Mannschaftenladen()
        {
            if(!IsPostBack)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MSbtn_Click(object sender, EventArgs e)
        {
            Label3.Text = "";
            speichernbt.Visible = true;
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

                    

                    for(int i=0;i<index+1;i++)
                    {
                        rdr.Read();

                      EditID = rdr.GetValue(0).ToString();
                    }
                    break;


                    rdr.Close();
                    
                }
               
            }
            Response.Redirect("spiele.aspx");
        }

        protected void speichernbt_Click(object sender, EventArgs e)
        {
            Label3.Text = "";

            string M1ID = "";
            string M2ID = "";
            for (int index = 0; index < M1List.Items.Count; index++)
            {
                if (M1List.Items[index].Selected)
                {
                    string sqlstring = "SELECT m.id FROM `mannschaft_has_turnier` t JOIN mannschaft m ON m.id = t.`Mannschaft_ID` WHERE `Turnier_ID` =" + EditID;
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

                        M1ID = rdr.GetValue(0).ToString();
                    }
                }
            }

            for (int index = 0; index < M2List.Items.Count; index++)
            {
                if (M2List.Items[index].Selected)
                {
                    if (M2List.Items[index].Selected)
                    {
                        string sqlstring = "SELECT m.id FROM `mannschaft_has_turnier` t JOIN mannschaft m ON m.id = t.`Mannschaft_ID` WHERE `Turnier_ID` =" + EditID;
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

                            M2ID = rdr.GetValue(0).ToString();
                        }
                    }
                }
            }

            if(M1ID==M2ID)
            {
                Label3.Text = "fehler";
            }
            else
            {
                string sql = "INSERT INTO `prodb`.`spiele` (`ID`, `Mannschaft1_ID`, `Mannschaft2_ID`, `ToreM1`, `ToreM2`, `turnier_id`) VALUES (NULL, '"+M1ID+"', '"+M2ID+"', NULL, NULL, '"+EditID+"');";


                MySqlConnection Conn = new MySqlConnection();

                string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                try
                {
                    Conn = new MySqlConnection();
                    Conn.ConnectionString = MyConnectionString;
                    Conn.Open();
                }
                catch
                {
                    Label1.Text += "Datenbank nicht erreichbar!";
                    return;
                }

                MySqlCommand command = new MySqlCommand(sql, Conn);

                int anzahl = command.ExecuteNonQuery();
                if (anzahl > 0)
                {
                    Label1.Text = "";
                    Label1.Text = "OK";
                }
                else
                {

                    Label3.Text = "Fehlgeschlagen";
                }

                Conn.Close();
                Response.Redirect("spiele.aspx");
            }

        }
        static int mID = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static int beid=0;
        static int indexbe1= 0;
        protected void bearbeiten_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);

            int id = Convert.ToInt32(Table2.Rows[indexbe].Cells[0].Text);
            beid = id;
            mID = Convert.ToInt32(id.ToString());
            Table1.Visible = false;
            Table3.Visible = true;
            speichernbt.Visible = false;
            aenderung.Visible = true;

            string sqlstring = "SELECT m.name, t.name,`ToreM1` , `ToreM2` FROM `spiele` s JOIN mannschaft m ON m.id = s.`Mannschaft1_ID` JOIN mannschaft t ON t.id = s.`Mannschaft2_iD` WHERE s.`ID` = " + id;
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

                M1lb.Text = rdr.GetValue(0).ToString();
                M2lb.Text = rdr.GetValue(1).ToString();
                M1box.Text = rdr.GetValue(2).ToString();
                M2box.Text = rdr.GetValue(3).ToString();
            }
            rdr.Close();
           
        }

        protected void loeschen_Click(object sender, EventArgs e)
        {
            // DELETE FROM `spiele` where `ID`= 1

            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            indexbe = indexbe - Table2.Rows.Count;

            int id = Convert.ToInt32(Table2.Rows[indexbe].Cells[0].Text);

            string sqlstring = "DELETE FROM `spiele` where `ID`= " + id;
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
                Label1.Text = "";
                Label1.Text += " Datenbank nicht erreichbar!";
                return;
            }
            MySqlCommand command = new MySqlCommand(sqlstring, Conn);
            this.Label1.Text = "";
            //Abfrage ausführen
            int anzahl = command.ExecuteNonQuery();

            if (anzahl > 0)
            {
                Label1.Text = "";

                this.Label1.Text += " OK";
            }
            else
            {
                this.Label1.Text += " ";

                this.Label1.Text += " Fehlgeschlagen";
            }


            //Verbindung schliessen
            Conn.Close();
            Response.Redirect("spiele.aspx");

        }

        protected void aenderung_Click(object sender, EventArgs e)
        {
            
            string sql = "UPDATE `spiele` SET `ToreM1`='"+M1box.Text+"',`ToreM2`='"+M2box.Text+"' WHERE `ID`="+mID;

            MySqlConnection Conn = new MySqlConnection();

            string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch
            {
                Label1.Text += "Datenbank nicht erreichbar!";
                return;
            }

            MySqlCommand command = new MySqlCommand(sql, Conn);

            int anzahl = command.ExecuteNonQuery();
            if (anzahl > 0)
            {
                Label1.Text = "";
                Label1.Text = "OK";
            }
            else
            {

                Label1.Text = "Fehlgeschlagen";
            }




            if (Table2.Rows[indexbe1].Cells[3].Text != "")
            {
                int m1id = 0;
                int m2id = 0;
                sql = "SELECT `Mannschaft1_ID`,`Mannschaft2_ID` FROM `spiele` WHERE id=" + beid;


                command = new MySqlCommand(sql, Conn);

                //Abfrage ausführen
                MySqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {

                    m1id = Convert.ToInt32(rdr.GetValue(0).ToString());
                    m2id = Convert.ToInt32(rdr.GetValue(1).ToString());

                }
                rdr.Close();

                int m1 = Convert.ToInt32(M1box.Text);
                int m2 = Convert.ToInt32(M2box.Text);
                int punktestand1 = 0;
                int punktestand2 = 0;

                sql = "SELECT `Punkte` FROM `mannschaft_has_turnier` WHERE `Mannschaft_ID`=" + m1id;


                command = new MySqlCommand(sql, Conn);

                //Abfrage ausführen
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    punktestand1 = Convert.ToInt32(rdr.GetValue(0).ToString());
                }
                rdr.Close();

                sql = "SELECT `Punkte` FROM `mannschaft_has_turnier` WHERE `Mannschaft_ID`=" + m2id;


                command = new MySqlCommand(sql, Conn);

                //Abfrage ausführen
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    punktestand2 = Convert.ToInt32(rdr.GetValue(0).ToString());
                }
                rdr.Close();

                if (m1 > m2)
                {
                    int wert = punktestand1 + 3;
                    sql = "UPDATE `mannschaft_has_turnier` SET `Punkte` = "+wert+" WHERE `Mannschaft_ID` = "+m1id+" AND `Turnier_ID` = "+EditID;

                    command = new MySqlCommand(sql, Conn);

                     anzahl = command.ExecuteNonQuery();
                    if (anzahl > 0)
                    {
                        Label1.Text = "";
                        Label1.Text = "OK";
                    }
                    else
                    {

                        Label1.Text = "Fehlgeschlagen";
                    }

                    wert = punktestand2 ;
                    sql = "UPDATE `mannschaft_has_turnier` SET `Punkte` = " + wert + " WHERE `Mannschaft_ID` = " + m2id + " AND `Turnier_ID` = " + EditID;

                    command = new MySqlCommand(sql, Conn);

                    anzahl = command.ExecuteNonQuery();
                    if (anzahl > 0)
                    {
                        Label1.Text = "";
                        Label1.Text = "OK";
                    }
                    else
                    {

                        Label1.Text = "Fehlgeschlagen";
                    }
                
                }
                else if(m1<m2)
                {
                    int wert = punktestand1 ;
                    sql = "UPDATE `mannschaft_has_turnier` SET `Punkte` = " + wert + " WHERE `Mannschaft_ID` = " + m1id + " AND `Turnier_ID` = " + EditID;

                    command = new MySqlCommand(sql, Conn);

                    anzahl = command.ExecuteNonQuery();
                    if (anzahl > 0)
                    {
                        Label1.Text = "";
                        Label1.Text = "OK";
                    }
                    else
                    {

                        Label1.Text = "Fehlgeschlagen";
                    }

                    wert = punktestand2 + 3;
                    sql = "UPDATE `mannschaft_has_turnier` SET `Punkte` = " + wert + " WHERE `Mannschaft_ID` = " + m2id + " AND `Turnier_ID` = " + EditID;

                    command = new MySqlCommand(sql, Conn);

                    anzahl = command.ExecuteNonQuery();
                    if (anzahl > 0)
                    {
                        Label1.Text = "";
                        Label1.Text = "OK";
                    }
                    else
                    {

                        Label1.Text = "Fehlgeschlagen";
                    }
                }
                else if (m1 == m2)
                {
                    int wert = punktestand1+1;
                    sql = "UPDATE `mannschaft_has_turnier` SET `Punkte` = " + wert + " WHERE `Mannschaft_ID` = " + m1id + " AND `Turnier_ID` = " + EditID;

                    command = new MySqlCommand(sql, Conn);

                    anzahl = command.ExecuteNonQuery();
                    if (anzahl > 0)
                    {
                        Label1.Text = "";
                        Label1.Text = "OK";
                    }
                    else
                    {

                        Label1.Text = "Fehlgeschlagen";
                    }

                    wert = punktestand2 +1;
                    sql = "UPDATE `mannschaft_has_turnier` SET `Punkte` = " + wert + " WHERE `Mannschaft_ID` = " + m2id + " AND `Turnier_ID` = " + EditID;

                    command = new MySqlCommand(sql, Conn);

                    anzahl = command.ExecuteNonQuery();
                    if (anzahl > 0)
                    {
                        Label1.Text = "";
                        Label1.Text = "OK";
                    }
                    else
                    {

                        Label1.Text = "Fehlgeschlagen";
                    }
                }

            }
            else
            {

            }
            Conn.Close();
            Response.Redirect("spiele.aspx");


        }
    }
}