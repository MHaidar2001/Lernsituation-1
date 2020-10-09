using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaft
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private controller _verwalter;
        public controller Verwalter { get => _verwalter; set => _verwalter = value; }
    
        protected void Page_Init(object sender,EventArgs e)
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



            string rechte = (string)Session["user"];
            if (rechte == "Admin" || rechte == "admin")
            {
                Button9.Visible = false;


            }
            else
            {
                RadioButtonList1.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                Label1.Visible = false;
                name.Visible = false;
                alter.Visible = false;

                Button9.Visible = false;


            }

            tbl();
            
           
        }

        public void tbl()
        {
            
                
                    string sqlstring = "SELECT * FROM `personen` WHERE `BenutzerName` != 'Admin'";
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
                for (spaltenindex = 0; spaltenindex < rdr.FieldCount - 2; spaltenindex++)
                {
                    c1 = new TableCell();
                    c1.Text = rdr.GetValue(spaltenindex).ToString();
                    row.Cells.Add(c1);
                }
                //Bearbeiten
                bt = new Button();
                bt.ID = index.ToString();
                bt.Click += Button4_Click1;
                  c1 = new TableCell();
               
                 c1.Controls.Add(bt);
                  row.Cells.Add(c1);
                bt.Text = "bearbeiten";
                bt.BackColor = Color.Green;



                this.Table1.Rows.Add(row);


                index++;
            }


            Conn.Close();
            rdr.Close();

            for (int i = 0; i < Table1.Rows.Count-1; i++)
            {
                c1 = new TableCell();
                bt = new Button();
                c1.Controls.Add(bt);
                bt.Text = "Löschen";
                bt.Click += Button3_Click;
                bt.BackColor = Color.Red;

                int zahl =0;
                zahl = Table1.Rows.Count + i+1;
                bt.ID = zahl.ToString();



                this.Table1.Rows[i+1].Controls.Add(c1);
            }
           
        }

 

        static int auswahl = -1;


        protected void Button1_Click(object sender, EventArgs e)
        {
            Button2.Visible = true;
            if(RadioButtonList1.Items[0].Selected)
            {

                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox tx5 = new TextBox();
                tx5.CssClass = "";
                Label lab5 = new Label();

                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();
                tx5.TextMode = TextBoxMode.Number;
                lab5.Text = "  Gehalt: ";
                tx5.ID = "gehalt1";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();

                lab1.Text = "  Herkunft: ";
                tx1.ID = "her4";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;

                auswahl = 0;
                
            }
            else if (RadioButtonList1.Items[1].Selected)
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                //int v1, string name, int GD, string herkunft, string team
                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();
                tx5.TextMode = TextBoxMode.Number;
                lab5.Text = "  Gehalt: ";
                tx5.ID = "gehalt";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();

                lab1.Text = "  Herkunft: ";
                tx1.ID = "her3";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;


                auswahl = 1;
            }
            else if (RadioButtonList1.Items[2].Selected)
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                //string v1, string Sportart, string Status, string name, int GD, string herkunft, string team, string a
                TextBox tx1 = new TextBox();
                Label lab1 = new Label();



                TextBox tx3 = new TextBox();
                Label lab3 = new Label();

                TextBox tx4 = new TextBox();
                Label lab4 = new Label();

                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();

               



                newCell = new TableCell();
                tx3.TextMode = TextBoxMode.Number;
                lab3.Text = "  Anzahl Spiele: ";
                tx3.ID = "an3";
                newCell.Controls.Add(lab3);
                newCell.Controls.Add(tx3);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);



                newCell = new TableCell();
                lab4.Text = "  Gesundheitzustand: ";
                tx4.ID = "ge2";
                newCell.Controls.Add(lab4);
                newCell.Controls.Add(tx4);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);


                newCell = new TableCell();

                lab5.Text = "  Herkunft: ";
                tx5.ID = "her2";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;

                tx3.ForeColor = Color.Black;
                tx4.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;

                auswahl = 2;
            }
            else if (RadioButtonList1.Items[3].Selected)
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                //string Position, int ruekennummer, string Sportart, string Status, string name, int GD, string herkunft, string team, string a

                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TextBox tx2 = new TextBox();
                Label lab2 = new Label();

                TextBox tx3 = new TextBox();
                Label lab3 = new Label();

                TextBox tx4 = new TextBox();
                Label lab4 = new Label();

                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();

                lab1.Text = "Position: ";
                tx1.ID = "pos2";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx2.ID = "ruek1";
                lab2.Text = "  Rückennummer ";
                newCell.Controls.Add(lab2);
                newCell.Controls.Add(tx2);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx3.TextMode = TextBoxMode.Number;
                lab3.Text = "  Anzahl Spiele: ";
                tx3.ID = "an2";
                newCell.Controls.Add(lab3);
                newCell.Controls.Add(tx3);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);



                newCell = new TableCell();
                lab4.Text = "  Gesundheitzustand: ";
                tx4.ID = "ge1";
                newCell.Controls.Add(lab4);
                newCell.Controls.Add(tx4);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);


                newCell = new TableCell();

                lab5.Text = "  Herkunft: ";
                tx5.ID = "her1";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;
                tx2.ForeColor = Color.Black;
                tx3.ForeColor = Color.Black;
                tx4.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;

                auswahl = 3;

            }
            else if (RadioButtonList1.Items[4].Selected)
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TextBox tx2 = new TextBox();
                Label lab2 = new Label();

                TextBox tx3 = new TextBox();
                Label lab3 = new Label();

                TextBox tx4 = new TextBox();
                Label lab4 = new Label();

                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();

                lab1.Text = "Position: ";
                tx1.ID = "pos1";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx2.ID = "ruek";
                lab2.Text = "  Rückennummer ";
                newCell.Controls.Add(lab2);
                newCell.Controls.Add(tx2);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx3.TextMode = TextBoxMode.Number;
                lab3.Text = "  Anzahl Spiele: ";
                tx3.ID = "an1";
                newCell.Controls.Add(lab3);
                newCell.Controls.Add(tx3);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                lab4.Text = "  Gesundheitzustand: ";
                tx4.ID = "ge";
                newCell.Controls.Add(lab4);
                newCell.Controls.Add(tx4);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();

                lab5.Text = "  Herkunft: ";
                tx5.ID = "her";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                
                auswahl = 4;
              

                tx1.ForeColor = Color.Black;
                tx2.ForeColor = Color.Black; 
                tx3.ForeColor = Color.Black; 
                tx4.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;


                

            }
           
         }

        /// <summary>
        /// Einfügen Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Button2_Click(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();
            TableCell c4 = new TableCell();
            TableCell c5 = new TableCell();
            TableCell c6 = new TableCell();
            TableCell c7 = new TableCell();
            TableCell c8 = new TableCell();
            TableCell c9 = new TableCell();

            if (auswahl==0)//Physiotherapeut
            {
                //int v1, string name, int GD, string herkunft, string team
                
                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = this.Request.Form["ctl00$MainContent$gehalt1"];
                c2.Text = "Physiotherapeut";

                c3.Text = "";//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her4"]; //tx5.Text;
                c7.Text = "";//tx3.Text;
                c8.Text = "";//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                
                int i1 = Convert.ToInt32(c1.Text);
                //TextBox2.Text = i.ToString();

                Physiotherapeut Physiotherapeut1 = new Physiotherapeut(i1, c4.Text, i, c6.Text,4, "", "Physiotherapeut");
                Verwalter.Personen.Add(Physiotherapeut1);

                string sql = "INSERT INTO `personen` (`ID`, `Name`, `Alter`, `Herkunft`, `Einsatzbereich`, `Anzahl Spiele`, `Position`, `Rückennummer`, `Gesundheitzustand`, `Gehalt`, `Sportart`, `BenutzerName`, `Passwort`) VALUES (Null,'" + TextBox3.Text + "','" + TextBox2.Text + "','" + c6.Text + "','Physiotherapeut',Null,Null ,Null,Null, '" + c1.Text + "', null,'" + TextBox3.Text + "', 'Test123')";



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

            }
            else if(auswahl==1)//Trainer
            {
                //int v1, string name, int GD, string herkunft, string team

                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();

               

                c1.Text = this.Request.Form["ctl00$MainContent$gehalt"];
                c2.Text = "Trainer";

                c3.Text = "";//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her3"]; //tx5.Text;                                                           
                c7.Text = "";//tx3.Text;
                c8.Text = "";//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                TableCell[] allCelles = {c9, c4, c5, c6, c2, c7, new TableCell(), c8, c3, new TableCell(),c1, new TableCell(), new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                int i1 = Convert.ToInt32(c1.Text);
                //TextBox2.Text = i.ToString();

                Trainer Trainer1 = new Trainer(i1, c4.Text, i, c6.Text,1,   "", "Trainer");
                Verwalter.Personen.Add(Trainer1);

                string sql = "INSERT INTO `personen` (`ID`, `Name`, `Alter`, `Herkunft`, `Einsatzbereich`, `Anzahl Spiele`, `Position`, `Rückennummer`, `Gesundheitzustand`, `Gehalt`, `Sportart`, `BenutzerName`, `Passwort`) VALUES (Null,'" + TextBox3.Text + "','" + TextBox2.Text + "','" + c6.Text + "','Trainer',Null,Null ,Null,Null, '" + c1.Text + "', null,'" + TextBox3.Text + "', 'Test123')";



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

                

            }
            else if (auswahl == 2)//TennisSpieler
            {
                //string v1, string Sportart, string Status, string name, int GD, string herkunft, string team, string a
                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = "";
                c2.Text = "TennisSpieler";

                c3.Text = this.Request.Form["ctl00$MainContent$ge2"];//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her2"]; //tx5.Text;
                c7.Text = this.Request.Form["ctl00$MainContent$an3"];//tx3.Text;
                c8.Text = "";//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                TableCell[] allCelles = { c9,c4, c5, c6, c2, c7, new TableCell(), c8, c3,c1, new TableCell(),new TableCell(),new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                TennisSpieler Spieler1 = new TennisSpieler(c1.Text, "Tennis", c3.Text, TextBox3.Text, i, c6.Text, 1,"","", c7.Text);
                Verwalter.Personen.Add(Spieler1);

                string sql = "INSERT INTO `personen` (`ID`, `Name`, `Alter`, `Herkunft`, `Einsatzbereich`, `Anzahl Spiele`, `Position`, `Rückennummer`, `Gesundheitzustand`, `Gehalt`, `Sportart`, `BenutzerName`, `Passwort`) VALUES (Null,'" + TextBox3.Text + "','" + TextBox2.Text + "','" + c6.Text + "','TennisSpieler','" + c7.Text + "',Null ,Null,'" + c3.Text + "', NULL, 'Tennis','" + TextBox3.Text + "', 'Test123')";


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

            }
            else if (auswahl == 3)//HandballSpieler
            {

                //string Position, int ruekennummer, string Sportart, string Status, string name, int GD, string herkunft, string team, string a
                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();

                

                c1.Text = this.Request.Form["ctl00$MainContent$pos2"];
                c2.Text = "HandballSpieler";

                c3.Text = this.Request.Form["ctl00$MainContent$ge1"];//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her1"]; //tx5.Text;
                c7.Text = this.Request.Form["ctl00$MainContent$an2"];//tx3.Text;
                c8.Text = this.Request.Form["ctl00$MainContent$ruek1"];//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                TableCell[] allCelles = { c9,c4, c5, c6, c2, c7, c1, c8, c3, new TableCell(), new TableCell(), new TableCell(), new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                HandballSpieler Spieler1 = new HandballSpieler(c1.Text, this.Request.Form["ctl00$MainContent$ruek1"], "Handball", c3.Text, TextBox3.Text, i, c6.Text,1, "","", c7.Text);


               Verwalter.Personen.Add(Spieler1);

                string sql = "INSERT INTO `personen` (`ID`, `Name`, `Alter`, `Herkunft`, `Einsatzbereich`, `Anzahl Spiele`, `Position`, `Rückennummer`, `Gesundheitzustand`, `Gehalt`, `Sportart`, `BenutzerName`, `Passwort`) VALUES (Null,'" + TextBox3.Text + "','" + TextBox2.Text + "','" + c6.Text + "','HandballSpieler','" + c7.Text + "','" + c1.Text + "' ,'" + c8.Text + "','" + c3.Text + "', NULL, 'Handball','" + TextBox3.Text + "', 'Test123')";



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



            }
            else if (auswahl == 4)//Fussballspieler
            {                
                int i = Convert.ToInt32(TextBox2.Text); 
                TextBox2.Text = i.ToString();
                
                

                c1.Text = this.Request.Form["ctl00$MainContent$pos1"];
                c2.Text = "Fussballspieler";

                c3.Text = this.Request.Form["ctl00$MainContent$ge"];//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her"]; //tx5.Text;
                c7.Text = this.Request.Form["ctl00$MainContent$an1"];//tx3.Text;
                c8.Text = this.Request.Form["ctl00$MainContent$ruek"];//tx2.Text;
                 int id = 0;
                c9.Text = id.ToString();
                for(int index=0; index < Verwalter.Personen.Count; index++)
                {
                  if(  Verwalter.Personen[index].ID==id)
                  {
                        id++;
                  }
                  else
                  {
                        
                        
                  }
                }


                TableCell[] allCelles = { c9,c4,c5,c6,c2,c7,c1,c8,c3,new TableCell(), new TableCell() , new TableCell() ,  new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                Fussballspieler Spieler1 = new Fussballspieler(c1.Text, c8.Text, "Fussball", c3.Text, TextBox3.Text, i, c6.Text, id,"", c7.Text);


                string sql = "INSERT INTO `personen` (`ID`, `Name`, `Alter`, `Herkunft`, `Einsatzbereich`, `Anzahl Spiele`, `Position`, `Rückennummer`, `Gesundheitzustand`, `Gehalt`, `Sportart`, `BenutzerName`, `Passwort`) VALUES (Null,'"+TextBox3.Text+ "','" + TextBox2.Text+ "','" + c6.Text+ "','Fußballspieler','" + c7.Text+"','"+c1.Text+"' ,'"+c8.Text+"','"+c3.Text+"', NULL, 'Fußball','"+TextBox3.Text+"', 'Test123')";

               

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
                if(anzahl>0)
                {
                    Label1.Text = "";
                    Label1.Text = "OK";
                }
                else
                {

                    Label1.Text = "Fehlgeschlagen";
                }

                Conn.Close();


                             
               Verwalter.Personen.Add(Spieler1);

               
            }
            Response.Redirect("Personenverwaltung.aspx");

        }



        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonAnlegen.aspx");
        }
        /// <summary>
        /// löschen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            indexbe = indexbe - Table1.Rows.Count;

            int id = Convert.ToInt32(Table1.Rows[indexbe].Cells[0].Text);

            string sqlstring = "DELETE FROM `Personen` WHERE `Personen`.`ID` = " + id;
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
            Response.Redirect("Personenverwaltung.aspx");
        }


        static string UPdateID="0";
        protected void Button4_Click1(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int indexbe = Convert.ToInt32(bt.ID);
            
            int id = Convert.ToInt32(Table1.Rows[indexbe].Cells[0].Text);

            string sqlstring = "SELECT * FROM `personen` WHERE `BenutzerName` != 'Admin' and ID="+id;
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

            string sele = "";
            while (rdr.Read())
            {
                int index = 4;
               
                sele = rdr.GetValue(index).ToString();
            }


            if (sele == "Physiotherapeut")
            {

                
                
                TextBox3.Text = "";
                TextBox tx5 = new TextBox();
                tx5.CssClass = "";
                Label lab5 = new Label();

                TextBox tx1 = new TextBox();
                

                Label lab1 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();
                tx5.TextMode = TextBoxMode.Number;
                lab5.Text = "  Gehalt: ";
                tx5.ID = "gehalt1";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();

                lab1.Text = "  Herkunft: ";
                tx1.ID = "her4";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;
                rdr.Read();

                //Herkunft
                int index1 = 3;

                tx1.Text = rdr.GetValue(index1).ToString();

                rdr.Read();
                //Name
                int index = 1;
                TextBox3.Text = rdr.GetValue(index).ToString();
                //alter
                rdr.Read();

                int index2 = 2;
                
                TextBox2.Text = rdr.GetValue(index2).ToString();
                
                //Gehalt
                rdr.Read();

                int index3 = 9;
                
                tx5.Text = rdr.GetValue(index3).ToString();

                //ID
                 rdr.Read();
                
                UPdateID = rdr.GetValue(0).ToString();

                Button2.Visible = false;
                Button9.Visible = true;



                auswahl = 0;
            }
            else if (sele== "Trainer")
            {
                
                //int v1, string name, int GD, string herkunft, string team
                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();
                tx5.TextMode = TextBoxMode.Number;
                lab5.Text = "  Gehalt: ";
                tx5.ID = "gehalt";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();

                lab1.Text = "  Herkunft: ";
                tx1.ID = "her3";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;


                //Herkunft
                int index1 = 3;

                tx1.Text = rdr.GetValue(index1).ToString();

                rdr.Read();
                //Name
                int index = 1;
                TextBox3.Text = rdr.GetValue(index).ToString();
                //alter
                rdr.Read();

                int index2 = 2;

                TextBox2.Text = rdr.GetValue(index2).ToString();

                //Gehalt
                rdr.Read();

                int index3 = 9;

                tx5.Text = rdr.GetValue(index3).ToString();

                //ID
                rdr.Read();

                UPdateID = rdr.GetValue(0).ToString();

                Button2.Visible = false;
                Button9.Visible = true;

                auswahl = 1;
            }
            else if (sele== "TennisSpieler")
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                //string v1, string Sportart, string Status, string name, int GD, string herkunft, string team, string a
                TextBox tx1 = new TextBox();
                Label lab1 = new Label();



                TextBox tx3 = new TextBox();
                Label lab3 = new Label();

                TextBox tx4 = new TextBox();
                Label lab4 = new Label();

                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();

               



                newCell = new TableCell();
                tx3.TextMode = TextBoxMode.Number;
                lab3.Text = "  Anzahl Spiele: ";
                tx3.ID = "an3";
                newCell.Controls.Add(lab3);
                newCell.Controls.Add(tx3);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);



                newCell = new TableCell();
                lab4.Text = "  Gesundheitzustand: ";
                tx4.ID = "ge2";
                newCell.Controls.Add(lab4);
                newCell.Controls.Add(tx4);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);


                newCell = new TableCell();

                lab5.Text = "  Herkunft: ";
                tx5.ID = "her2";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;

                tx3.ForeColor = Color.Black;
                tx4.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;

                //Herkunft
                int index1 = 3;

                tx5.Text = rdr.GetValue(index1).ToString();

                rdr.Read();
                //Name
                int index = 1;
                TextBox3.Text = rdr.GetValue(index).ToString();
                //alter
                rdr.Read();

                int index2 = 2;

                TextBox2.Text = rdr.GetValue(index2).ToString();

                //Anzahl Spiele
                rdr.Read();

                int index3 = 8;

                tx4.Text = rdr.GetValue(index3).ToString();
                //Anzahl Spiele
                rdr.Read();

                int index5 = 5;

                tx3.Text = rdr.GetValue(index5).ToString();

                //ID
                rdr.Read();
                UPdateID = rdr.GetValue(0).ToString();
                Button2.Visible = false;
                Button9.Visible = true;

                auswahl = 2;
            }
            else if (sele== "HandballSpieler")
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                //string Position, int ruekennummer, string Sportart, string Status, string name, int GD, string herkunft, string team, string a

                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TextBox tx2 = new TextBox();
                Label lab2 = new Label();

                TextBox tx3 = new TextBox();
                Label lab3 = new Label();

                TextBox tx4 = new TextBox();
                Label lab4 = new Label();

                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();

                lab1.Text = "Position: ";
                tx1.ID = "pos2";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx2.ID = "ruek1";
                lab2.Text = "  Rückennummer ";
                newCell.Controls.Add(lab2);
                newCell.Controls.Add(tx2);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx3.TextMode = TextBoxMode.Number;
                lab3.Text = "  Anzahl Spiele: ";
                tx3.ID = "an2";
                newCell.Controls.Add(lab3);
                newCell.Controls.Add(tx3);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);



                newCell = new TableCell();
                lab4.Text = "  Gesundheitzustand: ";
                tx4.ID = "ge1";
                newCell.Controls.Add(lab4);
                newCell.Controls.Add(tx4);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);


                newCell = new TableCell();

                lab5.Text = "  Herkunft: ";
                tx5.ID = "her1";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                tx1.ForeColor = Color.Black;
                tx2.ForeColor = Color.Black;
                tx3.ForeColor = Color.Black;
                tx4.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;
                //Herkunft
                int index1 = 3;

                tx5.Text = rdr.GetValue(index1).ToString();

                rdr.Read();
                //Name
                int index = 1;
                TextBox3.Text = rdr.GetValue(index).ToString();
                //alter
                rdr.Read();

                int index2 = 2;

                TextBox2.Text = rdr.GetValue(index2).ToString();

                //Gesundheitzustand
                rdr.Read();

                int index3 = 8;

                tx4.Text = rdr.GetValue(index3).ToString();
                //Anzahl Spiele
                rdr.Read();

                int index5 = 5;

                tx3.Text = rdr.GetValue(index5).ToString();
                 //Rückennummer
                rdr.Read();

                tx2.Text = rdr.GetValue(7).ToString(); 
                //Rückennummer
                rdr.Read();

                tx1.Text = rdr.GetValue(6).ToString();

                //ID
                rdr.Read();
                UPdateID = rdr.GetValue(0).ToString();
                Button2.Visible = false;
                Button9.Visible = true;

                auswahl = 3;

            }
            else if (sele== "Fußballspieler")
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox tx1 = new TextBox();
                Label lab1 = new Label();

                TextBox tx2 = new TextBox();
                Label lab2 = new Label();

                TextBox tx3 = new TextBox();
                Label lab3 = new Label();

                TextBox tx4 = new TextBox();
                Label lab4 = new Label();

                TextBox tx5 = new TextBox();
                Label lab5 = new Label();

                TableRow neuerow = new TableRow();

                TableCell newCell = new TableCell();

                lab1.Text = "Position: ";
                tx1.ID = "pos1";
                newCell.Controls.Add(lab1);
                newCell.Controls.Add(tx1);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx2.ID = "ruek";
                lab2.Text = "  Rückennummer ";
                newCell.Controls.Add(lab2);
                newCell.Controls.Add(tx2);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                tx3.TextMode = TextBoxMode.Number;
                lab3.Text = "  Anzahl Spiele: ";
                tx3.ID = "an1";
                newCell.Controls.Add(lab3);
                newCell.Controls.Add(tx3);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();
                lab4.Text = "  Gesundheitzustand: ";
                tx4.ID = "ge";
                newCell.Controls.Add(lab4);
                newCell.Controls.Add(tx4);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);

                newCell = new TableCell();

                lab5.Text = "  Herkunft: ";
                tx5.ID = "her";
                newCell.Controls.Add(lab5);
                newCell.Controls.Add(tx5);
                neuerow.Cells.Add(newCell);
                Table2.Rows.Add(neuerow);


                auswahl = 4;


                tx1.ForeColor = Color.Black;
                tx2.ForeColor = Color.Black;
                tx3.ForeColor = Color.Black;
                tx4.ForeColor = Color.Black;
                tx5.ForeColor = Color.Black;
                //Herkunft
                int index1 = 3;

                tx5.Text = rdr.GetValue(index1).ToString();

                rdr.Read();
                //Name
                int index = 1;
                TextBox3.Text = rdr.GetValue(index).ToString();
                //alter
                rdr.Read();

                int index2 = 2;

                TextBox2.Text = rdr.GetValue(index2).ToString();

                //Gesundheitzustand
                rdr.Read();

                int index3 = 8;

                tx4.Text = rdr.GetValue(index3).ToString();
                //Anzahl Spiele
                rdr.Read();

                int index5 = 5;

                tx3.Text = rdr.GetValue(index5).ToString();
                //Rückennummer
                rdr.Read();

                tx2.Text = rdr.GetValue(7).ToString();
                //Rückennummer
                rdr.Read();

                tx1.Text = rdr.GetValue(6).ToString();

                //ID
                rdr.Read();
                UPdateID = rdr.GetValue(0).ToString();
                Button2.Visible = false;
                Button9.Visible = true;



            }

            rdr.Close();
            //Verbindung schliessen
            Conn.Close();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button9_Click(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();
            TableCell c4 = new TableCell();
            TableCell c5 = new TableCell();
            TableCell c6 = new TableCell();
            TableCell c7 = new TableCell();
            TableCell c8 = new TableCell();
            TableCell c9 = new TableCell();

            if (auswahl == 0)//Physiotherapeut
            {
                //int v1, string name, int GD, string herkunft, string team

                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = this.Request.Form["ctl00$MainContent$gehalt1"];
                c2.Text = "Physiotherapeut";

                c3.Text = "";//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her4"]; //tx5.Text;
                c7.Text = "";//tx3.Text;
                c8.Text = "";//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();


                int i1 = Convert.ToInt32(c1.Text);
                //TextBox2.Text = i.ToString();

                Physiotherapeut Physiotherapeut1 = new Physiotherapeut(i1, c4.Text, i, c6.Text, 4, "", "Physiotherapeut");
                Verwalter.Personen.Add(Physiotherapeut1);

                string sql = "UPDATE `personen` SET `Name` = '"+TextBox3.Text+"',`Alter` = '"+TextBox2.Text+"',`Herkunft` = '"+c6.Text+"',`Gehalt` = '"+c1.Text+"' WHERE `ID` ="+UPdateID;



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

            }
            else if (auswahl == 1)//Trainer
            {
                //int v1, string name, int GD, string herkunft, string team

                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = this.Request.Form["ctl00$MainContent$gehalt"];
                c2.Text = "Trainer";

                c3.Text = "";//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her3"]; //tx5.Text;                                                           
                c7.Text = "";//tx3.Text;
                c8.Text = "";//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                TableCell[] allCelles = { c9, c4, c5, c6, c2, c7, new TableCell(), c8, c3, new TableCell(), c1, new TableCell(), new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                int i1 = Convert.ToInt32(c1.Text);
                //TextBox2.Text = i.ToString();

                Trainer Trainer1 = new Trainer(i1, c4.Text, i, c6.Text, 1, "", "Trainer");
                Verwalter.Personen.Add(Trainer1);

                string sql = "UPDATE `personen` SET `Name` = '" + TextBox3.Text + "',`Alter` = '" + TextBox2.Text + "',`Herkunft` = '" + c6.Text + "',`Gehalt` = '" + c1.Text + "' WHERE `ID` =" + UPdateID;



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



            }
            else if (auswahl == 2)//TennisSpieler
            {
                //string v1, string Sportart, string Status, string name, int GD, string herkunft, string team, string a
                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = "";
                c2.Text = "TennisSpieler";

                c3.Text = this.Request.Form["ctl00$MainContent$ge2"];//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her2"]; //tx5.Text;
                c7.Text = this.Request.Form["ctl00$MainContent$an3"];//tx3.Text;
                c8.Text = "";//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                TableCell[] allCelles = { c9, c4, c5, c6, c2, c7, new TableCell(), c8, c3, c1, new TableCell(), new TableCell(), new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                TennisSpieler Spieler1 = new TennisSpieler(c1.Text, "Tennis", c3.Text, TextBox3.Text, i, c6.Text, 1, "", "", c7.Text);
                Verwalter.Personen.Add(Spieler1);

                string sql = "UPDATE `personen` SET `Name`='"+TextBox3.Text+"',`Alter`='"+TextBox2.Text+"',`Herkunft`='"+c6.Text+"',`Anzahl Spiele`='"+c7.Text+"',`Gesundheitzustand`='"+c3.Text+"' WHERE ID="+UPdateID;


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

            }
            else if (auswahl == 3)//HandballSpieler
            {

                //string Position, int ruekennummer, string Sportart, string Status, string name, int GD, string herkunft, string team, string a
                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = this.Request.Form["ctl00$MainContent$pos2"];
                c2.Text = "HandballSpieler";

                c3.Text = this.Request.Form["ctl00$MainContent$ge1"];//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her1"]; //tx5.Text;
                c7.Text = this.Request.Form["ctl00$MainContent$an2"];//tx3.Text;
                c8.Text = this.Request.Form["ctl00$MainContent$ruek1"];//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();

                TableCell[] allCelles = { c9, c4, c5, c6, c2, c7, c1, c8, c3, new TableCell(), new TableCell(), new TableCell(), new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                HandballSpieler Spieler1 = new HandballSpieler(c1.Text, this.Request.Form["ctl00$MainContent$ruek1"], "Handball", c3.Text, TextBox3.Text, i, c6.Text, 1, "", "", c7.Text);


                Verwalter.Personen.Add(Spieler1);

                string sql = "UPDATE `personen` SET `Name`='" + TextBox3.Text + "',`Alter`='" + TextBox2.Text + "',`Herkunft`='" + c6.Text + "',`Anzahl Spiele`='" + c7.Text + "',`Position`='" + c1.Text + "',`Rückennummer`='" + c8.Text + "',`Gesundheitzustand`='" + c3.Text + "' WHERE ID=" + UPdateID;



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



            }
            else if (auswahl == 4)//Fussballspieler
            {
                int i = Convert.ToInt32(TextBox2.Text);
                TextBox2.Text = i.ToString();



                c1.Text = this.Request.Form["ctl00$MainContent$pos1"];
                c2.Text = "Fussballspieler";

                c3.Text = this.Request.Form["ctl00$MainContent$ge"];//tx4.Text;
                c4.Text = TextBox3.Text;
                c5.Text = TextBox2.Text;
                c6.Text = this.Request.Form["ctl00$MainContent$her"]; //tx5.Text;
                c7.Text = this.Request.Form["ctl00$MainContent$an1"];//tx3.Text;
                c8.Text = this.Request.Form["ctl00$MainContent$ruek"];//tx2.Text;
                int id = 0;
                c9.Text = id.ToString();
                for (int index = 0; index < Verwalter.Personen.Count; index++)
                {
                    if (Verwalter.Personen[index].ID == id)
                    {
                        id++;
                    }
                    else
                    {


                    }
                }


                TableCell[] allCelles = { c9, c4, c5, c6, c2, c7, c1, c8, c3, new TableCell(), new TableCell(), new TableCell(), new TableCell() };
                row.Cells.AddRange(allCelles);
                Table1.Rows.Add(row);
                Fussballspieler Spieler1 = new Fussballspieler(c1.Text, c8.Text, "Fussball", c3.Text, TextBox3.Text, i, c6.Text, id, "", c7.Text);


                string sql = "UPDATE `personen` SET `Name`='"+TextBox3.Text+"',`Alter`='"+TextBox2.Text+"',`Herkunft`='"+c6.Text+"',`Anzahl Spiele`='"+c7.Text+"',`Position`='"+c1.Text+"',`Rückennummer`='"+c8.Text+"',`Gesundheitzustand`='"+c3.Text+"' WHERE ID="+UPdateID;



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



                Verwalter.Personen.Add(Spieler1);


            }

            Response.Redirect("Personenverwaltung.aspx");
        }
    }
}