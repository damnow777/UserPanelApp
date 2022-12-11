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

namespace User_app
{
    public partial class Zalogowano : Form
    {
        public Zalogowano()
        {
            InitializeComponent();

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var id = Form1.id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            HttpResponseMessage response = client.GetAsync($"api/user/{id}").Result;

            var user = response.Content.ReadAsAsync<User>().Result;

          

            if(user is null || user.Name != textBox1.Text || user.Lastname != textBox2.Text)
            {
                MessageBox.Show("Błędne dane logowania");
            }
            else
            {
                PanelUzytkownika panel = new PanelUzytkownika();
                panel.Show();
                this.Close();
            }


        }
    }
}
