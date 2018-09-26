using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DisconnectedModeHW
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        string cs = "";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs= ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.ConnectionString = cs;
            textBox1.Text = "select * from Authors;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(cs);
                set = new DataSet();
                string sql = textBox1.Text;
                da = new SqlDataAdapter(sql, conn);
                da.Fill(set);
                TabPage page = new TabPage();
                //page.Text=
                tabControl1.TabPages.Add(page);

                ListView view = new ListView();
                view.View = View.Details;
               // view.Controls.Add(view);
                page.Controls.Add(view);
                view.Dock = DockStyle.Fill;
                view.Columns.Add("Id");
                view.Columns.Add("First Name");
                view.Columns.Add("Last Name");
                view.Columns.Add("id some");
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    ListViewItem viewitem = new ListViewItem();
                    MessageBox.Show(set.Tables[0].Rows[i][1].ToString());
                    viewitem.Text = set.Tables[0].Rows[i][0].ToString();
                    viewitem.SubItems.Add(set.Tables[0].Rows[i][1].ToString());
                    viewitem.SubItems.Add(set.Tables[0].Rows[i][2].ToString());
                    viewitem.SubItems.Add(set.Tables[0].Rows[i][3].ToString());
                    view.Items.Add(viewitem);
                }
                foreach (var item in set.Tables[0].Rows)
                {
                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}
