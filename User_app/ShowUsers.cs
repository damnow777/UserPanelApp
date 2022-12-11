﻿using System;
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
    public partial class ShowUsers : Form
    {
        public ShowUsers()
        {
            InitializeComponent();
            ShowAllUsers();


        }

        private void ShowAllUsers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            HttpResponseMessage response = client.GetAsync("api/user").Result;

            var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            dataGridView1.DataSource = users;
        }

        private void Delete()
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Wprowadź id użytkownika");
            }
            else
            {
                var id = int.Parse(textBox1.Text);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000");
                HttpResponseMessage response = client.DeleteAsync($"api/user/{id}").Result;

                var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                dataGridView1.DataSource = users;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowAllUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelUzytkownika panel = new PanelUzytkownika();
            panel.Show();
            this.Close();
        }
    }
}
