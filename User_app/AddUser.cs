using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace User_app
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelUzytkownika panel = new PanelUzytkownika();
            panel.Show();
            this.Close();
        }


        public void AddNewUser()
        {
            try
            {
                var user = new User()
                {
                    Name = textBox1.Text,
                    Lastname = textBox2.Text,
                    Number = int.Parse(textBox3.Text),
                    City = textBox4.Text,
                    Street = textBox5.Text,
                    PostalCode = textBox6.Text,

                };

                var userToSend = JsonConvert.SerializeObject(user);
                var payload = new StringContent(userToSend, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var endpoint = new Uri("http://localhost:5000/api/user");
                //client.BaseAddress = new Uri("http://localhost:5000");


                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;

                MessageBox.Show("Dodawanie użytkownika udane");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

            } catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania użytkownika");
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }
    }
}
