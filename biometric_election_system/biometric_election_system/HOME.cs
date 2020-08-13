using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometric_election_system
{
    public partial class MyHome : Form
    {
        string fpicture = "";
        bool flag = true;
        int count1, count2;
        SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
        SqlConnection cnn1 = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
        SqlCommand cmd;
        public static string Identity = "";
        public static string email = ""; 
        OpenFileDialog open = new OpenFileDialog();
        Regex namechk = new Regex(@"^[A-Z][a-zA-Z ]*$");
        Regex emailchk = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        Regex emailchk1= new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex namechk2 = new Regex(@"^[A-Z][a-zA-Z ]*$");
        Regex emailchk2 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public MyHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPanel.SelectedTab = Home;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TabPanel.SelectedTab = HowToCastVote;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TabPanel.SelectedTab = Register;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (LoginEmail.Text == "admin" && LoginPass.Text == "admin")
            {
                Admin obj = new Admin();
                obj.Show();
            }
            else
            {

                try
                {
                    if (!(LoginEmail.Text == "") && !emailchk1.Match(LoginEmail.Text).Success)
                    {
                        maillbl.Text = "Invalid email should include @";
                    }
                    else if (LoginEmail.Text == "" && LoginPass.Text == "")
                    {
                        maillbl.Text = "Please fill the fields.";
                    }
                    else
                    {
                        maillbl.Text = "";

                        cnn.Open();
                        string sql = "SELECT EMAIL,PASSWORD FROM REGISTRATION WHERE EMAIL = '" + LoginEmail.Text + "' and password = '" + LoginPass.Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        SqlDataReader read = cmd.ExecuteReader();
                        read.Read();
                        if (read.HasRows)
                        {
                            email = read[0].ToString();
                            FingerPrint fp = new FingerPrint();
                            fp.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email or Password not Matched");
                        }
                        cnn.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            
        }

        private void uploadbtn_Click(object sender, EventArgs e)
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

        private void Availibility_Click(object sender, EventArgs e)
        {
            try
            {
                if (EleNIC.Text == ReEleNIC.Text)
                {
                    cnn.Open();
                    string sql = "Select identity_number from Nad where identity_number  = '" + EleNIC.Text + "'";
                    cmd = new SqlCommand(sql, cnn);
                    SqlDataReader read = cmd.ExecuteReader();
                    read.Read();
                    if (read.HasRows)
                    {
                        MessageBox.Show("You are Eligable for vote.");
                    }
                    else
                    {
                        MessageBox.Show("You are not elegible for vote because we cant find your data.");
                    }
                    cnn.Close();
                }
                else
                {
                    MessageBox.Show("Not Match");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            nametxt.Text = nametxt.Text.Replace(Environment.NewLine, "");
        }

        private void idnotxt_TextChanged(object sender, EventArgs e)
        {
            idnotxt.Text = idnotxt.Text.Replace(Environment.NewLine, "");
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {
            emailtxt.Text = emailtxt.Text.Replace(Environment.NewLine, "");
        }

        private void passtxt_TextChanged(object sender, EventArgs e)
        {
            passtxt.Text = passtxt.Text.Replace(Environment.NewLine, "");
        }

        private void repasstxt_TextChanged(object sender, EventArgs e)
        {
            repasstxt.Text = repasstxt.Text.Replace(Environment.NewLine, "");
        }

        private void countrytxt_TextChanged(object sender, EventArgs e)
        {

            countrytxt.Text = countrytxt.Text.Replace(Environment.NewLine, "");
        }

        private void LoginEmail_TextChanged(object sender, EventArgs e)
        {
            LoginEmail.Text = LoginEmail.Text.Replace(Environment.NewLine, "");
        }

        private void LoginPass_TextChanged(object sender, EventArgs e)
        {
            LoginPass.Text = LoginPass.Text.Replace(Environment.NewLine, "");
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            
            //code for datastoring and validation

            if (nametxt.Text == "")
            {
                namelbl.Text = "fill the feild";
            }
            else
            {
                namelbl.Text = "";
            }
            //
            if (repasstxt.Text == "")
            {
                repasslbl.Text = "fill the feild";
            }
            else
            {
                repasslbl.Text = "";
            }
            //
            if (countrytxt.Text == "")
            {
                countrylbl.Text = "fill the feild";
            }
            else
            {
                countrylbl.Text = "";
            }
            //
            if (emailtxt.Text == "")
            {
                emaillbl.Text = "fill the feild";
            }
            else
            {
                emaillbl.Text = "";
            }
            //
            if (passtxt.Text == "")
            {
                passlbl.Text = "fill the feild";
            }
            else
            {
                passlbl.Text = "";
            }
            //
            if (idnotxt.Text == "")
            {
                idlbl.Text = "Enter Your identity card number";
            }
            else
            {
                idlbl.Text = "";
            }
            //
            if (fpicture == "")
            {
                piclbl.Text = "upload a picture";
            }
            else
            {
                piclbl.Text = "";
            }
            //
            if (!(nametxt.Text == "") && !namechk.Match(nametxt.Text).Success)
            {

                namelbl.Text = "Invalid name first letter should be capital";
            }
            else
            {
                namelbl.Text = "";
            }
            //
            if (!(emailtxt.Text == "") && !emailchk.Match(emailtxt.Text).Success)
            {
                emaillbl.Text = "Invalid email should include @";
            }
            else
            {
                emaillbl.Text = "";
            }
            //
            if (passtxt.Text == repasstxt.Text)
            {
                passlbl.Text = "";
            }
            else
            {
                repasslbl.Text = "* Password does not match";
            }

            if ((namechk.Match(nametxt.Text).Success) && (emailchk.Match(emailtxt.Text).Success) && (passtxt.Text == repasstxt.Text))
            {
                try
                {


                    byte[] profile;
                    Identity = idnotxt.Text;
                    ////code for image comparisonnn
                    cnn.Open();
                    string idch = " select Identity_number,Fingerprint,profilepic from Nad where Identity_Number = '" + idnotxt.Text + "'";
                    cmd = new SqlCommand(idch, cnn);
                    SqlDataReader rd1 = cmd.ExecuteReader();
                    Bitmap img1, img2;
                    string img1_ref, img2_ref;
                    byte[] img = null;
                    MemoryStream ms;
                    rd1.Read();

                    if (rd1.HasRows)
                    {

                        string sql1 = "Select email,identity_number from registration where email = '" + emailtxt.Text + "' or identity_number = '" + idnotxt.Text + "'";
                        cnn1.Open();
                        cmd = new SqlCommand(sql1, cnn1);
                        SqlDataReader rd2 = cmd.ExecuteReader();
                        rd2.Read();
                        if (rd2.HasRows)
                        {
                            if (rd2[0].ToString() == emailtxt.Text)
                            {

                                emaillbl.Text = "Email already Registered";
                                cnn.Close();
                            }
                            else if (rd2[1].ToString() == idnotxt.Text)
                            {

                                idlbl.Text = "Identity Number already Registered";
                                cnn.Close();
                            }
                            else
                            {

                                emaillbl.Text = "Email already Registered";
                                idlbl.Text = "Identity Number already Registered";
                                cnn.Close();
                            }
                            cnn1.Close();
                        }

                        else
                        {
                            img = (byte[])(rd1[1]);
                            profile = (byte[])(rd1[2]);
                            ms = new MemoryStream(img);
                            img1 = new Bitmap(Image.FromStream(ms));
                            img2 = new Bitmap(fpicture);

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
                                    //  progressBar1.Value++;
                                }
                                if (flag == false)
                                {
                                    cnn.Close();
                                    cnn1.Close();
                                    flag = true;
                                    MessageBox.Show("Sorry, finger print is not matching with Nadra database, Try Again!");
                                    fpicture = "";
                                }

                                else
                                {
                                    cnn.Close();
                                    MemoryStream pro = new MemoryStream(profile);
                                    string sql = "INSERT INTO REGISTRATION(fullname,identity_number,Email,Password,country,fingerprint,VoteFor,isVoted,profilepic)VALUES('" + nametxt.Text + "' , '" + idnotxt.Text + "','" + emailtxt.Text + "','" + repasstxt.Text + "','" + countrytxt.Text + "', @img,null,0,@pic)";
                                    cnn.Open();
                                    cmd = new SqlCommand(sql, cnn);

                                    cmd.Parameters.AddWithValue("@img", img);
                                    cmd.Parameters.AddWithValue("@pic", pro);
                                    cmd.ExecuteNonQuery();
                                    Identity = idnotxt.Text;
                                    cnn.Close();
                                    TabPanel.SelectedTab = Login;

                                }
                            }
                            else
                                MessageBox.Show("Images are not same.");
                            cnn.Close();
                        }
                    }
                    else
                    {
                        idlbl.Text = "Identity card no is not correct";
                        cnn.Close();
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            TabPanel.SelectedTab = Faqs;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TabPanel.SelectedTab = Login;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPanel.SelectedTab = ContactUs;
        }

        private void MyHome_Load(object sender, EventArgs e)
        {
            passtxt.PasswordChar = '*';
            LoginPass.PasswordChar = '*';
        }

        private void TabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void HowToCastVote_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReEleNIC_TextChanged(object sender, EventArgs e)
        {
            ReEleNIC.Text = ReEleNIC.Text.Replace(Environment.NewLine, "");
        }

        private void REleNIC_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void EleNIC_TextChanged(object sender, EventArgs e)
        {
            EleNIC.Text = EleNIC.Text.Replace(Environment.NewLine, "");
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Faqs_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ContactUs_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void msg_txt_TextChanged(object sender, EventArgs e)
        {
            msg_txt.Text = msg_txt.Text.Replace(Environment.NewLine, "");
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void name_txt_TextChanged(object sender, EventArgs e)
        {
            name_txt.Text = name_txt.Text.Replace(Environment.NewLine, "");
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {
            email_txt.Text = email_txt.Text.Replace(Environment.NewLine, "");
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void piclbl_Click(object sender, EventArgs e)
        {

        }

        private void countrylbl_Click(object sender, EventArgs e)
        {

        }

        private void namelbl_Click(object sender, EventArgs e)
        {

        }

        private void passlbl_Click(object sender, EventArgs e)
        {

        }

        private void idlbl_Click(object sender, EventArgs e)
        {

        }

        private void emaillbl_Click(object sender, EventArgs e)
        {

        }

        private void repasslbl_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (name_txt.Text == "")
            {
                cnlbl.Text = "Enter Your identity card number";
            }
            else
            {
                cnlbl.Text = "";
            }
            if (email_txt.Text == "")
            {
                celbl.Text = "Enter Your identity card number";
            }
            else
            {
                celbl.Text = "";
            }
            if (msg_txt.Text == "")
            {
                cmsglbl.Text = "Enter your Message";
            }
            else
            {
                cmsglbl.Text = "";
            }
            if (!(email_txt.Text == "") && !emailchk2.Match(email_txt.Text).Success)
            {
                celbl.Text = "Invalid email should include @";
            }
            else
            {
                celbl.Text = "";
            }
            if (!(name_txt.Text == "") && !namechk2.Match(name_txt.Text).Success)
            {

                cnlbl.Text = "Invalid name first letter should be capital";
            }
            else
            {
                cnlbl.Text = "";
            }
            if ((namechk2.Match(name_txt.Text).Success) && (emailchk2.Match(email_txt.Text).Success) && msg_txt.Text != "")
            {
                cnn.Open();
                string sql = "INSERT INTO Contact_us(Name,Email,Message)VALUES('" + name_txt.Text + "' , '" + email_txt.Text + "','" + msg_txt.Text + "')";
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Message Send.");
            }

            
        }
         

        }
    }


