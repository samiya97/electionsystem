using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biometric_election_system
{
    public partial class Admin : Form
    {
        SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
        SqlConnection cnn1 = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");
        SqlConnection cnn2 = new SqlConnection("Data Source=samiyabatool;Initial Catalog=ElectionSystem;Persist Security Info=True;User ID=samiya;Password=tirmazi1234");

        SqlCommand cmd = new SqlCommand();

        Regex namechk = new Regex(@"^[A-Z][a-zA-Z ]*$");
        Regex emailchk = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        int rowindex;
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //    // TODO: This line of code loads data into the 'electionSystemDummyDataSet.users' table. You can move, or remove it, as needed.
            //    this.usersTableAdapter.Fill(this.electionSystemDummyDataSet.users);
            // TODO: This line of code loads data into the 'electionSystemDataSet.Contact_us' table. You can move, or remove it, as needed.
            this.contact_usTableAdapter.Fill(this.electionSystemDataSet.Contact_us);
            // TODO: This line of code loads data into the 'electionSystemDataSet.Nad' table. You can move, or remove it, as needed.
            this.nadTableAdapter.Fill(this.electionSystemDataSet.Nad);
            // TODO: This line of code loads data into the 'electionSystemDataSet.Registration' table. You can move, or remove it, as needed.
            this.registrationTableAdapter.Fill(this.electionSystemDataSet.Registration);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                tabpanels.SelectedTab = nadrapage;
                //nadra table
                cnn.Open();
                cmd.CommandText = "select * from Nad";
                cmd.Connection = cnn;
                DataTable dt = new DataTable();
                /////tablefilldatatable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                nadra_grid.DataSource = dt;
                // dataGridView1.Refresh();
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabpanels.SelectedTab = voterspage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                tabpanels.SelectedTab = votespage;
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='PTI'";
                cmd.Connection = cnn;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    pti_votes.Text = rd[0].ToString();
                    cnn.Close();
                }
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='PPPP'";
                cmd.Connection = cnn;
                SqlDataReader rd1 = cmd.ExecuteReader();
                rd1.Read();
                if (rd1.HasRows)
                {
                    ppp_votes.Text = rd1[0].ToString();
                    cnn.Close();
                }
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='MMA'";
                cmd.Connection = cnn;
                SqlDataReader rd2 = cmd.ExecuteReader();
                rd2.Read();
                if (rd2.HasRows)
                {
                    mma_votes.Text = rd2[0].ToString();
                    cnn.Close();
                }
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='MMA'";
                cmd.Connection = cnn;
                SqlDataReader rd3 = cmd.ExecuteReader();
                rd3.Read();
                if (rd3.HasRows)
                {
                    mma_votes.Text = rd3[0].ToString();
                    cnn.Close();
                }
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='PMLN'";
                cmd.Connection = cnn;
                SqlDataReader rd4 = cmd.ExecuteReader();
                rd4.Read();
                if (rd4.HasRows)
                {
                    pml_votes.Text = rd4[0].ToString();
                    cnn.Close();
                }
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='TLP'";
                cmd.Connection = cnn;
                SqlDataReader rd5 = cmd.ExecuteReader();
                rd5.Read();
                if (rd5.HasRows)
                {
                    tl_votes.Text = rd5[0].ToString();
                    cnn.Close();
                }
                cnn.Open();
                cmd.CommandText = "select Count(VoteFor) from Registration where VoteFor ='MQM'";
                cmd.Connection = cnn;
                SqlDataReader rd6 = cmd.ExecuteReader();
                rd6.Read();
                if (rd6.HasRows)
                {
                    mqm_votes.Text = rd6[0].ToString();
                    cnn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabpanels.SelectedTab = contactpage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //contact table
            try
            {
                cnn.Open();
                cmd.CommandText = "select * from Contact_us";
                cmd.Connection = cnn;
                DataTable dt = new DataTable();
                /////tablefilldatatable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                nadra_grid.DataSource = dt;
                // dataGridView1.Refresh();
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //contact table
            try
            {
                String id1 = contact_grid.Rows[rowindex].Cells[0].Value.ToString();
                cnn.Open();
                cmd.CommandText = "delete  from Contact_us where id ='" + id1 + "'";
                cmd.Connection = cnn;
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Deleted!");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }
        public void grid_refresh()
        {
            try
            {
                cnn.Open();
                cmd.CommandText = "select * from Registration";
                cmd.Connection = cnn;

                DataTable dt = new DataTable();
                /////tablefilldatatable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                Voter_grid.DataSource = dt;
                // dataGridView1.Refresh();
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }
        private void view_btn_Click(object sender, EventArgs e)
        {
            //resgiter table
            grid_refresh();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
           //register table
            try
            {


                if (name_txt.Text == "" || cnic_txt.Text == "" || email_txt.Text == "" || pass_txt.Text == "" || id_txt.Text == "" || country_txt.Text == "" || cnic_txt.Text == "")
                {
                    MessageBox.Show("Please Insert Data First.");
                }
                else
                {
                    cnn1.Open();
                    cmd.CommandText = "select * from Registration where id ='" + id_txt.Text + "'";
                    cmd.Connection = cnn1;
                    cmd.ExecuteNonQuery();
                    cnn.Open();
                    cmd.CommandText = "update Registration set Fullname='" + name_txt.Text + "' ,Identity_Number='" + cnic_txt.Text + "',Email='" + email_txt.Text + "',Password='" + pass_txt.Text + "',Country='" + country_txt.Text + "' where ID='" + id_txt.Text + "'";
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("User updated !");
                    grid_refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            //Register table
            try
            {
                if (id_txt.Text == "")
                {
                    MessageBox.Show("Please Select User to Delete.");
                }
                else
                {
                    String id = Voter_grid.Rows[rowindex].Cells[0].Value.ToString();
                    cnn.Open();
                    cmd.CommandText = "delete  from Registration where id ='" + id + "'";
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Deleted!");
                    grid_refresh();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Please Select User to Delete");
            }
        }

      

        
        private void Voter_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
            id_txt.Text = Voter_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            name_txt.Text = Voter_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            cnic_txt.Text = Voter_grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            email_txt.Text = Voter_grid.Rows[e.RowIndex].Cells[3].Value.ToString();
            pass_txt.Text = Voter_grid.Rows[e.RowIndex].Cells[4].Value.ToString();
            country_txt.Text = Voter_grid.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {


                cnn.Open();
                cnn1.Open();
                cnn2.Open();
                string name = textBox1.Text;
                SqlCommand cmd2 = new SqlCommand();
                SqlCommand cmd1 = new SqlCommand();
                //int id = Convert.ToInt32(textBox1.Text);
                cmd.CommandText = cmd1.CommandText = "select * from Registration where Fullname like '" + name + "%'";
                cmd.Connection = cnn;

                cmd1.Connection = cnn1;
                SqlDataReader rd5 = cmd1.ExecuteReader();

                if (rd5.HasRows)
                {
                    DataTable dt = new DataTable();
                    /////tablefilldatatable
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    Voter_grid.DataSource = dt;
                }
                else
                {

                    cmd.CommandText = cmd2.CommandText = "select * from Registration where id like '" + name + "%'";
                    cmd.Connection = cnn;

                    cmd2.Connection = cnn2;
                    SqlDataReader rd = cmd2.ExecuteReader();
                    rd.Read();
                    if (rd.HasRows)
                    {
                        DataTable dt = new DataTable();
                        /////tablefilldatatable
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        Voter_grid.DataSource = dt;
                    }
                    else
                    {
                        Voter_grid.DataSource = null;
                    }
                }
                // dataGridView1.Refresh();
                cnn.Close();
                cnn1.Close();
                cnn2.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                cnn1.Open();
                cnn2.Open();
                string name = textBox2.Text;
                SqlCommand cmd2 = new SqlCommand();
                SqlCommand cmd1 = new SqlCommand();
                //int id = Convert.ToInt32(textBox1.Text);
                cmd.CommandText = cmd1.CommandText = "select * from Nad where Full_name like '" + name + "%'";
                cmd.Connection = cnn;

                cmd1.Connection = cnn1;
                SqlDataReader rd5 = cmd1.ExecuteReader();

                if (rd5.HasRows)
                {
                    DataTable dt = new DataTable();
                    /////tablefilldatatable
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    nadra_grid.DataSource = dt;
                }
                else
                {

                    cmd.CommandText = cmd2.CommandText = "select * from Nad where id like '" + name + "%'";
                    cmd.Connection = cnn;

                    cmd2.Connection = cnn2;
                    SqlDataReader rd = cmd2.ExecuteReader();
                    rd.Read();
                    if (rd.HasRows)
                    {
                        DataTable dt = new DataTable();
                        /////tablefilldatatable
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        nadra_grid.DataSource = dt;
                    }
                    else
                    {
                        nadra_grid.DataSource = null;
                    }
                }
                // dataGridView1.Refresh();
                cnn.Close();
                cnn1.Close();
                cnn2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void NadraInsert_Click(object sender, EventArgs e)
        {
            NadraInsert nad = new NadraInsert();
            nad.Show();
        }

        private void namelbl_Click(object sender, EventArgs e)
        {

        }

        private void votespage_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        PrintDocument pntdoc = new PrintDocument();
        private void printbtn_Click(object sender, EventArgs e)
        {
            Print(this.panel2);
        }
     
        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel2=pnl;
            getprintarea(pnl);
            prntprvw.Document = pntdoc;
            pntdoc.PrintPage += new PrintPageEventHandler(pntdoc_printpage);
            prntprvw.ShowDialog();
        }
        public void pntdoc_printpage(object sender , PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
           
            e.PageSettings.Landscape = true;
            e.Graphics.DrawImage(memorying, (pagearea.Width/2) - (this.panel2.Width /2 ), this.panel2.Location.Y);

        }
        Bitmap memorying;
        public void getprintarea(Panel pnl)
        {
            memorying = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memorying, new Rectangle(0, 0, pnl.Width, pnl.Height));
          

        }

        private void Contact_Click(object sender, EventArgs e)
        {
            tabpanels.SelectedTab = contatus;
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (cname.Text == "")
            {
                cnlbl.Text = "Enter Your identity card number";
            }
            else
            {
                cnlbl.Text = "";
            }
            if (cemail.Text == "")
            {
                celbl.Text = "Enter Your identity card number";
            }
            else
            {
                celbl.Text = "";
            }
            if (cmsg.Text == "")
            {
                cmsglbl.Text = "Enter your Message";
            }
            else
            {
                cmsglbl.Text = "";
            }
            if (!(cemail.Text == "") && !emailchk.Match(cemail.Text).Success)
            {
                celbl.Text = "Invalid email should include @";
            }
            else
            {
                celbl.Text = "";
            }
            if (!(cname.Text == "") && !namechk.Match(cname.Text).Success)
            {

                cnlbl.Text = "Invalid name first letter should be capital";
            }
            else
            {
                cnlbl.Text = "";
            }
            if ((namechk.Match(cname.Text).Success) && (emailchk.Match(cemail.Text).Success) && cmsg.Text != "")
            {
                SmtpClient obj = new SmtpClient();
                obj.Host = "smtp.live.com";
                obj.Port = 25;
                obj.EnableSsl = true;
                obj.DeliveryMethod = SmtpDeliveryMethod.Network;
                obj.UseDefaultCredentials = false;
                obj.Credentials = new NetworkCredential("samiya97@hotmail.com", "nintyseven");


                // mailcompse code

                MailMessage msg = new MailMessage();
                msg.To.Add(cemail.Text);
                msg.From = new MailAddress("samiya97@hotmail.com");
                msg.Subject = "Thank you for feedback";
                msg.Body = "Name : " + cname.Text + "\nEmail : " + cemail.Text + "\nMessage : " + cmsg.Text;
                obj.Send(msg);

                MessageBox.Show("Email send and Saved!");
            }
        }

        private void Voter_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
