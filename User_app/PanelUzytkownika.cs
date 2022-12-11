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
    public partial class PanelUzytkownika : Form
    {
        public PanelUzytkownika()
        {
            InitializeComponent();
            label1.Text = Form1.name + " " + Form1.lastname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowUsers show = new ShowUsers();
            show.Show();
            this.Hide();
        }

        //private void showAllUser()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:5000");
        //    HttpResponseMessage response = client.GetAsync("api/user").Result;


        //    var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
        //    dataGridView1.DataSource = users;
        //}
        //private void deleteUser()
        //{
        //    var id = int.Parse(textBox1.Text);
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:5000");
        //    HttpResponseMessage response = client.DeleteAsync($"api/user/{id}").Result;

        //    var user = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
        //    dataGridView1.DataSource = user;
        //}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddUser addUsr = new AddUser();
            addUsr.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var email = new SendEmail();
            email.Show();
            this.Hide();
        }

    }
}
