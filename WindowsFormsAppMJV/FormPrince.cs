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
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace WindowsFormsAppMJV
{
    public partial class FormPrince : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
            "Database=MJV;Trusted_Connection=True;";
        public FormPrince()
        {
            InitializeComponent();
        }

        private void FormPrince_Load(object sender, EventArgs e)
        {
            FillComboMatos();

           

            FormLogin dlg = new FormLogin();
            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string lelogin = dlg.login;
                string lepwd = dlg.pwd;

                SqlConnection cn = new SqlConnection(this.strcon);
                cn.Open();

                string strsql = "select count(*) as nb from" +
                    " Utilisateur where Nom = @lelogin and MDP = @lepwd";

                SqlCommand cmo = new SqlCommand(strsql, cn);
                cmo.Parameters.AddWithValue("lelogin", lelogin);

                //! calcul du hash de lepwd
                string hashpwd = hashca(lepwd);

                cmo.Parameters.AddWithValue("lepwd", hashpwd);
 
                SqlDataReader sqldr = cmo.ExecuteReader();

                sqldr.Read();

                int res = Convert.ToInt32(sqldr["nb"]);

                if (res == 0)
                { 
                    MessageBox.Show("Identifiants incorrects");

                    Application.Exit();
                    Application.DoEvents();
                }
            }
            else
            if (dr == DialogResult.Cancel)
            {
                Application.Exit();
                Application.DoEvents();
            }
           
        }

        private string hashca(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);

            SHA256 sha256Hash = SHA256.Create();

            byte[] hashdata = sha256Hash.ComputeHash(data);


            var sBuilder = new StringBuilder();

            for (int i = 0; i < hashdata.Length; i++)
            {
                sBuilder.Append(hashdata[i].ToString("x2"));
            }


            return sBuilder.ToString();
        }

        private void FillComboMatos()
        {
            comboBoxMatos.Items.Clear();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select nom from MATOS order by nom";
            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read() == true)
            {
                comboBoxMatos.Items.Add(dr["nom"].ToString());
            }

            dr.Close();
            cn.Close();
        }

        private void buttonCreation_Click(object sender, EventArgs e)
        {
            // vérif inter
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment créer une intervention ?",
                "Warning", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif matos
            int i = comboBoxMatos.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Veuillez choisir un matériel !", "Warning");
                comboBoxMatos.Focus();
                return;
            }

            // Ajout d'une intervention !!!

            int idmatos = this.giveMeTheMatosID(comboBoxMatos.SelectedItem.ToString());

            /*
            string comm = textBoxComment.Text;
            comm = comm.Replace("'", "''");
            string strsql = "INSERT INTO Intervention VALUES('" +
                dateTimePickerInstall.Value.ToShortDateString() + "','" +
                comm + "'," + idmatos.ToString() + ")";  */
            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "INSERT INTO Intervention VALUES(@ladate,@lecomment,@lid)";

            SqlCommand com = new SqlCommand(strsql, cn);
            com.Parameters.AddWithValue("ladate",
                dateTimePickerInstall.Value.ToShortDateString());
            com.Parameters.AddWithValue("lecomment", textBoxComment.Text);
            com.Parameters.AddWithValue("lid", idmatos);

            int res = com.ExecuteNonQuery();

            if (res == 1)
            {
                MessageBox.Show("Intervention enregistrée", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // maj de la date d'installation

            string insertsql = "UPDATE MATOS SET DateInst = @LANEWDATE WHERE ID_MATOS = @LIDMATOS";
            SqlCommand commaj = new SqlCommand(insertsql, cn);
            commaj.Parameters.AddWithValue("LANEWDATE", dateTimePickerInstall.Value.ToShortDateString());
            commaj.Parameters.AddWithValue("LIDMATOS", idmatos);

            commaj.ExecuteNonQuery();



            cn.Close();
        }

        private int giveMeTheMatosID(string nomMatos)
        {
            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select ID_MATOS from MATOS where nom = '" + nomMatos + "'";

            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            dr.Read();
            int id = Convert.ToInt16(dr["ID_MATOS"]);

            dr.Close();
            cn.Close();

            return id;


        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClient dlg = new FormClient();
            dlg.ShowDialog();

        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTypeMatos dlg = new FormTypeMatos();
            dlg.ShowDialog();
        }

        private void matérielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMatos dlg = new FormMatos();
            dlg.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                FormHistorique f = new FormHistorique();
                f.Show();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
