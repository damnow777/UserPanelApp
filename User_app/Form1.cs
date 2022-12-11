using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace User_app
{
    public partial class Form1 : Form
    {
        public static int? id;
        public static string name;
        public static string lastname;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkId();         
        }

        private void checkId()
        {
           
                id = int.Parse(textBox1.Text);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000");
                HttpResponseMessage response = client.GetAsync($"api/user/{id}").Result;
                var user = response.Content.ReadAsAsync<User>().Result;
                name = user.Name;
                lastname = user.Lastname;
                if (user is null)
                {
                    MessageBox.Show("Użytkownik nie istnieje");
                    textBox1.Text = "";
                }
                else
                {
                    Zalogowano zalogowano = new Zalogowano();
                    zalogowano.Show();
                    this.Hide();

                }
                   
        }

      
    }
}
