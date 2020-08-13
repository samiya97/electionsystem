using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometric_election_system
{
    public partial class FingerPrint : Form
    {
        public FingerPrint()
        {
            InitializeComponent();
        }
        string fname1 = "";
        SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
        SqlCommand cmd;
        private void FingerPrintUploader_Click(object sender, EventArgs e)
        {

            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                fname1 = openFileDialog1.FileName.ToString();
            }
            Image img = Image.FromFile(fname1);
            Thumbprintpic.Image = img;
            FPNext.Visible = true;
        }

        private void FPNext_Click(object sender, EventArgs e)
        {
            string email = MyHome.email;
            string sql = "Select fingerprint,identity_number from registration where email = '" + email + "'";
            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            Bitmap img1, img2;
            string img1_ref, img2_ref;
            byte[] img = null;
            int count1 = 0, count2 = 0;
            bool flag = true;
            MemoryStream ms;
            reader.Read();
            if (reader.HasRows)
            {
                img = (byte[])(reader[0]);
                MyHome.Identity = reader[1].ToString() ;
                ms = new MemoryStream(img);
                img1 = new Bitmap(Image.FromStream(ms));
                img2 = new Bitmap(fname1);

                if (img1.Width == img2.Width && img1.Height == img2.Height)
                {
                    for (int i = 0; i < img1.Width; i++)
                    {
                        for (int j = 0; j < img1.Height; j++)
                        {
                            img1_ref = img1.GetPixel(i, j).ToString();
                            img2_ref = img2.GetPixel(i, j).ToString();
                            if (img1_ref != img2_ref)
                            {
                                count2++;
                                flag = false;
                                break;
                            }
                            count1++;
                        }
                    }
                    if (flag == false)
                    {
                        cnn.Close();
                        flag = true;
                        MessageBox.Show("Sorry, finger print is not matching with Nadra database, Try Again!");
                        fname1 = "";
                    }

                    else
                    {
                        User_panel u = new User_panel();
                        u.Show();
                        this.Hide();
                        cnn.Close();
                    }
                }
            }
        }
    }
}
