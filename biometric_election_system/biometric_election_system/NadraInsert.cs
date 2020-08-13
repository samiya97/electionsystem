using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometric_election_system
{
    public partial class NadraInsert : Form
    {
        SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
        SqlConnection cnn1 = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
       
        SqlCommand cmd;
        Regex namechk = new Regex(@"^[A-Z][a-zA-Z ]*$");

        Regex namechk1 = new Regex(@"^[A-Z][a-zA-Z ]*$");
       // Regex emailchk = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public NadraInsert()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            NadCity.Text = NadCity.Text.Replace(Environment.NewLine, "");
        }

        private void NadraInsert_Load(object sender, EventArgs e)
        {

        }

        OpenFileDialog open = new OpenFileDialog();
        string fpicture,fpicture1 = "";
        private void NadPhoto_Click(object sender, EventArgs e)
        {

            open.FileName = "";
            open.Title = "Images";
            open.Filter = "All Images|*.jpg; *.bmp; *.png";
            open.ShowDialog();
            if (open.FileName.ToString() != "")
            {
                fpicture = open.FileName.ToString();
            }
        }
        OpenFileDialog open1 = new OpenFileDialog();

        private void Add_Click(object sender, EventArgs e)
        {
            if (NadFn.Text == "")
            {
                namelbl.Text = "fill the feild";
            }
            else
            {
                namelbl.Text = "";
            }
            //
            if (NadFatN.Text == "")
            {
                fatherlbl.Text = "fill the feild";
            }
            else
            {
                fatherlbl.Text = "";
            }
            //
            if (cnic_txt.Text == "")
            {
                idlbl.Text = "fill the feild";
            }
            else
            {
                idlbl.Text = "";
            }
            //
            if (NadAdd.Text == "")
            {
                addresslbl.Text = "fill the feild";
            }
            else
            {
                addresslbl.Text = "";
            }
            //
            if (NadDate.Text == "")
            {
                doblbl.Text = "fill the feild";
            }
            else
            {
                doblbl.Text = "";
            }
            //
            if (NadFemale.Checked == true || NadMale.Checked == true)
            {
             //   genderlbl.Text = "check a option";
            }
            else
            {
                genderlbl.Text = "";
            }
            //
            if (fpicture != "" && fpicture1 != "")
            {
                photolbl.Text = "";
            }
            else
            {
                
                photolbl.Text = "upload the pictures";
            }
            //
            if (!(NadFn.Text == "") && !namechk.Match(NadFn.Text).Success)
            {

                namelbl.Text = "Invalid name first letter should be capital";
                //fatherlbl.Text = "Invalid name first letter should be capital";
            }
            else
            {
                namelbl.Text = "";
                
            }
            if (!(NadFatN.Text == "") && !namechk1.Match(NadFatN.Text).Success)
            {

                fatherlbl.Text = "Invalid name first letter should be capital";
                //fatherlbl.Text = "Invalid name first letter should be capital";
            }
            else
            {
                fatherlbl.Text = "";

            }
            if (NadPAdd.Text == "")
            {
                padddlbl.Text = "fill the feild";
            }
            else
            {
                padddlbl.Text = "";
            }
            if (NadCity.Text == "")
            {
                citylbl.Text = "fill the feild";
            }
            else
            {
                citylbl.Text = "";
            }

            // try
            // {
            if (fpicture != "" && fpicture1 != "")
            {
                string se = "Select identity_number from Nad where identity_number = '" + cnic_txt.Text + "'";
                cnn1.Open();
                cmd = new SqlCommand(se, cnn1);
                SqlDataReader read = cmd.ExecuteReader();
                read.Read();
                if (!read.HasRows)
                {

                    byte[] profile;
                    byte[] fp;
                    FileStream fs = new FileStream(fpicture, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    profile = br.ReadBytes((int)fs.Length);

                    FileStream fs1 = new FileStream(fpicture1, FileMode.Open, FileAccess.Read);
                    BinaryReader br1 = new BinaryReader(fs1);
                    fp = br1.ReadBytes((int)fs1.Length);
                    cnn1.Close();
                    cnn.Open();

                    string gen = "";
                    if (NadMale.Checked)
                    {
                        gen = "Male";
                    }
                    else
                    {
                        gen = "female";
                    }

                    string sql = "Insert into Nad(full_name,father_name,identity_number,address,dob,gender,permanent_address,city,fingerprint,profilepic) Values('" + NadFn.Text + "','" + NadFatN.Text + "','" + cnic_txt.Text + "','" + NadAdd.Text + "','" + NadDate.Text + "','" + gen + "','" + NadPAdd.Text + "','" + NadCity.Text + "',@fp,@dp)";
                    cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.AddWithValue("@fp", fp);
                    cmd.Parameters.AddWithValue("@dp", profile);
                    int x = cmd.ExecuteNonQuery();
                    MessageBox.Show(x.ToString() + " record save");
                    cnn.Close();    
                }
                else
                {
                    cnn1.Close();
                    idlbl.Text = "Identity Number already exsist";
                }

            }
        }
         //   catch (Exception ex)
           // {
          //      MessageBox.Show(ex.ToString());
          //  }
     //   }

        private void NadFatN_TextChanged(object sender, EventArgs e)
        {
            NadFatN.Text = NadFatN.Text.Replace(Environment.NewLine, "");
        }

        private void NadFn_TextChanged(object sender, EventArgs e)
        {
            NadFn.Text = NadFn.Text.Replace(Environment.NewLine, "");
        }

        private void cnic_txt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            cnic_txt.Text = cnic_txt.Text.Replace(Environment.NewLine, "");
        }

        private void NadAdd_TextChanged(object sender, EventArgs e)
        {
            NadAdd.Text = NadAdd.Text.Replace(Environment.NewLine, "");
        }

        private void NadPAdd_TextChanged(object sender, EventArgs e)
        {
            NadPAdd.Text = NadPAdd.Text.Replace(Environment.NewLine, "");
        }

        private void NadFP_Click(object sender, EventArgs e)
        {
            open1.FileName = "";
            open1.Title = "Images";
            open1.Filter = "All Images|*.jpg; *.bmp; *.png";
            open1.ShowDialog();
            if (open1.FileName.ToString() != "")
            {
                fpicture1 = open1.FileName.ToString();
            }
        }
    }
}
