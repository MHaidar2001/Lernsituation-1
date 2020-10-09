using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaft
{
    public partial class Login : System.Web.UI.Page
    {
        private controller _verwalter;
        public controller Verwalter { get => _verwalter; set => _verwalter = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn = new MySqlConnection();
            string MyConnectionString = "Server=localhost;Port=3307;Database=prodb; Uid=user;Password=user";
            string sql = "SELECT COUNT( * )FROM `personen`WHERE `BenutzerName` = '"+TextBox1.Text+"'AND `Passwort` = '"+TextBox2.Text+"'";

            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch (MySqlException)
            {
                //Datenbank nicht verfügbar

                Label3.CssClass = "alert alert-danger";
                Label3.Text = "";
                Label3.Text = "Datenbank nicht erreichbar";
                
                return;
            }

            MySqlCommand command = new MySqlCommand(sql, Conn);

            string index = command.ExecuteScalar().ToString();

            if(index=="1")
            {
                Session["user"] = TextBox1.Text;
                this.Session["Verwalter"] = new controller();
                Verwalter = (controller)this.Session["Verwalter"];
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Label4.CssClass = "alert alert-danger";
                Label4.Text = "Ungültige Anmeldedaten. Versuchen Sie es noch einmal!";
            }

        }
        
    }
}