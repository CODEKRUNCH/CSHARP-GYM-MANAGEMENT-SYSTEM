using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saeedprj
{
    public partial class Coachmanage : Form
    {
      
        public Coachmanage()
        {   InitializeComponent();
          
            
            
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(namebox.Text) || string.IsNullOrWhiteSpace(genderbox.Text)  || string.IsNullOrWhiteSpace(phonebox.Text) || string.IsNullOrWhiteSpace(expbox.Text) || string.IsNullOrWhiteSpace(addressbox.Text) || string.IsNullOrWhiteSpace(passbox.Text))
            {
                MessageBox.Show("Please fill completely" , "Error");
            }
            else
            {
                try
                {
                    string name = namebox.Text;
                    string gender = genderbox.SelectedItem.ToString();
                    string phoneNumber = phonebox.Text;
                    string phone = phonebox.Text;
                    int experience = Convert.ToInt32(expbox.Text);
                    string address = addressbox.Text;
                    string pass = passbox.Text;
                    string cnic=cnicbox.Text;
                   

                    string query = "INSERT INTO coachdetails (chname, chgender, chcnic, chphone, chexperience, chaddress, chpassword) VALUES (@chname, @chgender, @chdateofbirth, @chphone, @chexperience, @chaddress, @chpassword)";

                    using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HU962IE;Initial Catalog=gymapp;Integrated Security=True;Trust Server Certificate=True"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@chname", name);
                            cmd.Parameters.AddWithValue("@chgender", gender);
                            cmd.Parameters.AddWithValue("@chcnic", cnic);
                            cmd.Parameters.AddWithValue("@chphone", phone);
                            cmd.Parameters.AddWithValue("@chexperience", experience);
                            cmd.Parameters.AddWithValue("@chaddress", address);
                            cmd.Parameters.AddWithValue("@chpassword", pass);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Coach Added!", "Save Successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
            }
        }


        private void dobbox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Coachmanage_Load(object sender, EventArgs e)
        {

        }
    }
}
