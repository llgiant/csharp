using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app055_FormUI_SQLDataAccess
{
    public partial class DashBoard : Form
    {
        private List<Person> _people = new List<Person>();
        public DashBoard()
        {
            InitializeComponent();
            UpdateBinding();
        }
        private void UpdateBinding()
        {
            peopleFoundListBox.DataSource = _people;
            peopleFoundListBox.DisplayMember = "FullInfo";
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            _people = db.GetPeople(lastNameText.Text);
            UpdateBinding();
        }
        private void insertRecordButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            db.InsertPerson(firstNameInsText.Text, lastNameInsText.Text, secondNameInsText.Text, genderInsText.Text, phoneNumberInsText.Text);
            //setting all text fields to be empty
            firstNameInsText.Text = "";
            lastNameInsText.Text = "";
            secondNameInsText.Text = "";
            genderInsText.Text = "";
            phoneNumberInsText.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void lastNameText_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void phoneNumberInsLabel_Click(object sender, EventArgs e) { }
        private void phoneNumberInsText_TextChanged(object sender, EventArgs e) { }
    }
}
