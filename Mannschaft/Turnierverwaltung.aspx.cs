using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


namespace Mannschaft
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        private controller _verwalter;
        public controller Verwalter { get => _verwalter; set => _verwalter = value; }


        protected void Page_Init(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {

                Verwalter = (controller)this.Session["Verwalter"];
            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                neuespieler();

            }

            tblladen();

            string rechte = (string)Session["user"];
            if (rechte == "Admin" || rechte == "admin")
            {

                eingabefelder();
                Button9.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;


            }
            else
            {


                datentbl.Visible = false;
                Button1.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                DropDownList1.Visible = false;
                Label1.Visible = false;
                DatenladenSQL.Visible = false;

                Button9.Visible = false;



            }





        }

        private void neuespieler()
        {
            Button1.Visible = true;

            string sqlstring = "SELECT * FROM `mannschaft`";
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


                DatenladenSQL.Items.Add("  " + rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString() + ", " + rdr.GetValue(2).ToString());




            }
        }

        private void tblladen()
        {



            string sqlstring = " SELECT * FROM `turnier` ";
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
                for (int spaltenindex = 0; spaltenindex < rdr.FieldCount; spaltenindex++)
                {
                    c1 = new TableCell();
                    c1.Text = rdr.GetValue(spaltenindex).ToString();
                    row.Cells.Add(c1);
                }
                this.Table5.Rows.Add(row);
            }

            rdr.Close();


            DropDownList Mitglieder = new DropDownList();


            for (int index = 0; index < Table5.Rows.Count - 1; index++)
            {
                string id = Table5.Rows[index + 1].Cells[0].Text;

                string Abfrage1 = "SELECT k.id, k.name, k.sportart FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier t ON t.id = m.`Turnier_ID` WHERE `Turnier_ID` = "+id;
                command = new MySqlCommand(Abfrage1, Conn);

                Mitglieder = new DropDownList();
                Mitglieder.ForeColor = Color.Black;


                TableCell newCell = new TableCell();
                //Abfrage ausführen
                rdr = command.ExecuteReader();

                newCell.Controls.Add(Mitglieder);
                Table5.Rows[index + 1].Cells.Add(newCell);

                Mitglieder.Items.Clear();

                while (rdr.Read())
                {


                    Mitglieder.Items.Add(rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString() + ", " + rdr.GetValue(2).ToString());




                }
                rdr.Close();
                if (Mitglieder.Items.Count == 0)
                {
                    Mitglieder.Items.Add("bisher keine Mitglieder");
                }
                else
                {

                }

            }

            Button bt = new Button();

            for (int i = 0; i < Table5.Rows.Count - 1; i++)
            {
                c1 = new TableCell();

                bt = new Button();
                int zahl = i+1;
                
                bt.ID = zahl.ToString();
                bt.Click += bearbeitenDB;

                c1.Controls.Add(bt);
                row.Cells.Add(c1);
                bt.Text = "bearbeiten";
                bt.BackColor = Color.Green;
                this.Table5.Rows[i + 1].Controls.Add(c1);
            }


            for (int i = 0; i < Table5.Rows.Count - 1; i++)
            {
                c1 = new TableCell();
                bt = new Button();
                c1.Controls.Add(bt);
                bt.Text = "Löschen";
                bt.Click += loeschenDb;
                bt.BackColor = Color.Red;

                int zahl = 0;
                zahl = Table5.Rows.Count + i + 1;
                bt.ID = zahl.ToString();



                this.Table5.Rows[i + 1].Controls.Add(c1);
            }


            Conn.Close();



        }

        public void eingabefelder()
        {


        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Items[0].Selected)
            {
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();

                TableRow neuerow = new TableRow();
                c1.Text = tx1.Text;
                c2.Text = "Fußball";



                string sql = "INSERT INTO `turnier`(`ID`, `Name`, `Sportart`) VALUES (Null,'"+c1.Text+"','"+c2.Text+"')";

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
                Conn.Close();


                for (int index = 0; index < DatenladenSQL.Items.Count; index++)
                {

                    string sqlstring = "SELECT `ID` FROM `mannschaft` ";
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();

                        for (int spaltenindex = 0; spaltenindex < rdr.FieldCount; spaltenindex++)
                        {

                            Pid = rdr.GetValue(0).ToString();



                        }
                    }
                    rdr.Close();


                    if (DatenladenSQL.Items[index].Selected)
                    {
                        string abfrage = "SELECT max(id) FROM `turnier`";
                        command1 = new MySqlCommand(abfrage, Conn1);
                        rdr = command1.ExecuteReader();
                        rdr.Read();
                        string Mid = rdr.GetValue(0).ToString();

                        rdr.Close();

                        string NewPersonTeam = "INSERT INTO `mannschaft_has_turnier`(`ID`, `Mannschaft_ID`, `Turnier_ID`) VALUES (null,'"+Pid+"','"+Mid+"')";
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }
                //INSERT INTO `prodb`.`mannschaft_has_personen` (`ID`, `Mannschaft_ID`, `Personen_ID`) VALUES (NULL, '1', '1');






            }
            else if (DropDownList1.Items[1].Selected)
            {
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();

                TableRow neuerow = new TableRow();
                c1.Text = tx1.Text;
                c2.Text = "Handball";



                string sql = "INSERT INTO `turnier`(`ID`, `Name`, `Sportart`) VALUES (Null,'" + c1.Text + "','" + c2.Text + "')";

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
                Conn.Close();


                for (int index = 0; index < DatenladenSQL.Items.Count; index++)
                {

                    string sqlstring = "SELECT `ID` FROM `mannschaft` ";
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();

                        for (int spaltenindex = 0; spaltenindex < rdr.FieldCount; spaltenindex++)
                        {

                            Pid = rdr.GetValue(0).ToString();



                        }
                    }
                    rdr.Close();


                    if (DatenladenSQL.Items[index].Selected)
                    {
                        string abfrage = "SELECT max(id) FROM `turnier`";
                        command1 = new MySqlCommand(abfrage, Conn1);
                        rdr = command1.ExecuteReader();
                        rdr.Read();
                        string Mid = rdr.GetValue(0).ToString();

                        rdr.Close();

                        string NewPersonTeam = "INSERT INTO `mannschaft_has_turnier`(`ID`, `Mannschaft_ID`, `Turnier_ID`) VALUES (null,'" + Pid + "','" + Mid + "')";
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }


            }
            else if (DropDownList1.Items[2].Selected)
            {
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();

                TableRow neuerow = new TableRow();
                c1.Text = tx1.Text;
                c2.Text = "Tennis";



                string sql = "INSERT INTO `turnier`(`ID`, `Name`, `Sportart`) VALUES (Null,'" + c1.Text + "','" + c2.Text + "')";

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
                Conn.Close();


                for (int index = 0; index < DatenladenSQL.Items.Count; index++)
                {

                    string sqlstring = "SELECT `ID` FROM `mannschaft` ";
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();

                        for (int spaltenindex = 0; spaltenindex < rdr.FieldCount; spaltenindex++)
                        {

                            Pid = rdr.GetValue(0).ToString();



                        }
                    }
                    rdr.Close();


                    if (DatenladenSQL.Items[index].Selected)
                    {
                        string abfrage = "SELECT max(id) FROM `turnier`";
                        command1 = new MySqlCommand(abfrage, Conn1);
                        rdr = command1.ExecuteReader();
                        rdr.Read();
                        string Mid = rdr.GetValue(0).ToString();

                        rdr.Close();

                        string NewPersonTeam = "INSERT INTO `mannschaft_has_turnier`(`ID`, `Mannschaft_ID`, `Turnier_ID`) VALUES (null,'" + Pid + "','" + Mid + "')";
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }


            }
            else
            {

            }
            Response.Redirect("Turnierverwaltung.aspx");



        }

        protected void loeschenDb(object sender, EventArgs e)
        {

            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            indexbe = indexbe - Table5.Rows.Count;

            int id = Convert.ToInt32(Table5.Rows[indexbe].Cells[0].Text);
            string sqlstring = "DELETE FROM `mannschaft_has_turnier` WHERE `Turnier_ID`= " + id;
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
            sqlstring = "DELETE FROM `turnier` WHERE id= " + id;
            command = new MySqlCommand(sqlstring, Conn);
            this.Label1.Text = "";
            //Abfrage ausführen
            anzahl = command.ExecuteNonQuery();

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
            Response.Redirect("Turnierverwaltung.aspx");
        }





        /// <summary>
        /// Bearbeiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static int IDEDIT = 0;
        protected void bearbeitenDB(object sender, EventArgs e)
        {
            Label4.Visible = true;
            Label5.Visible = true;
            Button9.Visible = true;
            Button1.Visible = false;
            DatenladenSQL.Visible = false;
            Label2.Visible = true;
            Label3.Visible = true;

            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);

            int id = Convert.ToInt32(Table5.Rows[indexbe].Cells[0].Text);
            IDEDIT = id;
            string sqlstring = "SELECT k.id, k.Name, k.`Sportart`  FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier  p ON p.id = m.`turnier_ID` WHERE `turnier_ID` = " + id;
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

            aenderung.Items.Clear();

            while (rdr.Read())
            {

                aenderung.Items.Add("  " + rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString() + ", " + rdr.GetValue(2).ToString() );


            }

            rdr.Close();

            sqlstring = "SELECT `Name` FROM `turnier` WHERE id =" + id;
            command = new MySqlCommand(sqlstring, Conn);

            //Abfrage ausführen
            rdr = command.ExecuteReader();
            rdr.Read();
            tx1.Text = rdr.GetValue(0).ToString();
            tx1.ForeColor = Color.Black;
            rdr.Close();

            sqlstring = "SELECT * FROM `Mannschaft` WHERE id NOT IN( SELECT k.id FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier p ON p.id = m.`Turnier_ID` WHERE `Turnier_ID` = "+id+")";
            command = new MySqlCommand(sqlstring, Conn);

            //Abfrage ausführen
            rdr = command.ExecuteReader();

            verfuegbarePersonen.Items.Clear();

            while (rdr.Read())
            {

                verfuegbarePersonen.Items.Add("  " + rdr.GetValue(0).ToString() + ", " + rdr.GetValue(1).ToString() + ", " + rdr.GetValue(2).ToString() );


            }








            Conn.Close();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AktulieserenDB(object sender, EventArgs e)
        {
            if (DropDownList1.Items[0].Selected)
            {
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();

                TableRow neuerow = new TableRow();
                c1.Text = tx1.Text;
                c2.Text = "Fußball";



                string sql = "UPDATE `turnier` SET `Name`='"+c1.Text+"',`Sportart`='"+c2.Text+"' WHERE id="+IDEDIT;

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
                Conn.Close();


                for (int index = 0; index < verfuegbarePersonen.Items.Count; index++)
                {

                    string sqlstring = "SELECT * FROM `Mannschaft` WHERE id NOT IN( SELECT p.id FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier p ON p.id = m.`Turnier_ID` WHERE `Turnier_ID` = " + IDEDIT + ")";
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();


                        Pid = rdr.GetValue(0).ToString();




                    }
                    rdr.Close();


                    if (verfuegbarePersonen.Items[index].Selected)
                    {


                        string NewPersonTeam = "INSERT INTO `prodb`.`mannschaft_has_turnier` (`ID`, `Mannschaft_ID`, `Turnier_ID`) VALUES (NULL, '" + Pid + "', '" + IDEDIT + "')";
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }

                for (int index = 0; index < aenderung.Items.Count; index++)
                {

                    string sqlstring = "SELECT k.id, k.Name, k.`Sportart`  FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier  p ON p.id = m.`turnier_ID` WHERE `turnier_ID` = " + IDEDIT;
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();


                        Pid = rdr.GetValue(0).ToString();




                    }
                    rdr.Close();


                    if (aenderung.Items[index].Selected)
                    {


                        string NewPersonTeam = "DELETE FROM `mannschaft_has_turnier` WHERE `turnier_ID`=" + IDEDIT + " and `mannschaft_ID`=" + Pid;
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }
                //INSERT INTO `prodb`.`mannschaft_has_personen` (`ID`, `Mannschaft_ID`, `Personen_ID`) VALUES (NULL, '1', '1');






            }
            else if (DropDownList1.Items[1].Selected)
            {
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();

                TableRow neuerow = new TableRow();
                c1.Text = tx1.Text;
                c2.Text = "Handball";

                string sql = "UPDATE `turnier` SET `Name`='" + c1.Text + "',`Sportart`='" + c2.Text + "' WHERE id=" + IDEDIT;

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
                Conn.Close();


                for (int index = 0; index < verfuegbarePersonen.Items.Count; index++)
                {

                    string sqlstring = "SELECT * FROM `Mannschaft` WHERE id NOT IN( SELECT p.id FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier p ON p.id = m.`Turnier_ID` WHERE `Turnier_ID` = " + IDEDIT + ")";
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();


                        Pid = rdr.GetValue(0).ToString();




                    }
                    rdr.Close();


                    if (verfuegbarePersonen.Items[index].Selected)
                    {


                        string NewPersonTeam = "INSERT INTO `prodb`.`mannschaft_has_turnier` (`ID`, `Mannschaft_ID`, `Turnier_ID`) VALUES (NULL, '" + Pid + "', '" + IDEDIT + "')";
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }

                for (int index = 0; index < aenderung.Items.Count; index++)
                {

                    string sqlstring = "SELECT k.id, k.Name, k.`Sportart`  FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier  p ON p.id = m.`turnier_ID` WHERE `turnier_ID` = " + IDEDIT;
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();


                        Pid = rdr.GetValue(0).ToString();




                    }
                    rdr.Close();


                    if (aenderung.Items[index].Selected)
                    {


                        string NewPersonTeam = "DELETE FROM `mannschaft_has_turnier` WHERE `turnier_ID`=" + IDEDIT + " and `Personen_ID`=" + Pid;
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }





            }
            else if (DropDownList1.Items[2].Selected)
            {
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();
                TableRow neuerow = new TableRow();
                c1.Text = tx1.Text;
                c2.Text = "Tennis";

                string sql = "UPDATE `turnier` SET `Name`='" + c1.Text + "',`Sportart`='" + c2.Text + "' WHERE id=" + IDEDIT;

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
                Conn.Close();


                for (int index = 0; index < verfuegbarePersonen.Items.Count; index++)
                {

                    string sqlstring = "SELECT * FROM `Mannschaft` WHERE id NOT IN( SELECT p.id FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier p ON p.id = m.`Turnier_ID` WHERE `Turnier_ID` = " + IDEDIT + ")";
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();


                        Pid = rdr.GetValue(0).ToString();




                    }
                    rdr.Close();


                    if (verfuegbarePersonen.Items[index].Selected)
                    {


                        string NewPersonTeam = "INSERT INTO `prodb`.`mannschaft_has_turnier` (`ID`, `Mannschaft_ID`, `Turnier_ID`) VALUES (NULL, '" + Pid + "', '" + IDEDIT + "')";
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }

                for (int index = 0; index < aenderung.Items.Count; index++)
                {

                    string sqlstring = "SELECT k.id, k.Name, k.`Sportart`  FROM `mannschaft_has_turnier` m JOIN Mannschaft k ON k.id = m.Mannschaft_ID JOIN turnier  p ON p.id = m.`turnier_ID` WHERE `turnier_ID` = " + IDEDIT;
                    MySqlConnection Conn1 = new MySqlConnection();
                    string MyConnectionString1 = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";

                    try
                    {
                        Conn1 = new MySqlConnection();
                        Conn1.ConnectionString = MyConnectionString1;
                        Conn1.Open();
                    }
                    catch (MySqlException)
                    {
                        //Datenbank nicht verfügbar

                        Label1.Text = "Datenbank nicht erreichbar";

                        return;
                    }


                    MySqlCommand command1 = new MySqlCommand(sqlstring, Conn1);

                    //Abfrage ausführen
                    MySqlDataReader rdr = command1.ExecuteReader();

                    string Pid = "";
                    for (int index1 = 0; index1 < index + 1; index1++)
                    {
                        rdr.Read();


                        Pid = rdr.GetValue(0).ToString();




                    }
                    rdr.Close();


                    if (aenderung.Items[index].Selected)
                    {


                        string NewPersonTeam = "DELETE FROM `mannschaft_has_turnier` WHERE `turnier_ID`=" + IDEDIT + " and `Personen_ID`=" + Pid;
                        command1 = new MySqlCommand(NewPersonTeam, Conn1);

                        int anzahl1 = command1.ExecuteNonQuery();
                        if (anzahl1 > 0)
                        {
                            Label1.Text = "";
                            Label1.Text = "OK";
                        }
                        else
                        {

                            Label1.Text = "Fehlgeschlagen";
                        }
                        Conn.Close();



                    }



                }


            }
            else
            {

            }
            Response.Redirect("Turnierverwaltung.aspx");
        }
    }
}
    
