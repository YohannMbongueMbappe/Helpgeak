using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMJV
{
    public partial class FormClient : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
           "Database=MJV;Trusted_Connection=True;";

        public FormClient()
        {
            InitializeComponent();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            FillClientList();

            listBoxClient.Focus();
        }

        private void FillClientList()
        {
            listBoxClient.Items.Clear();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select ID_CLIENT, NOM from Client order by nom";
            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            Itemcpl item;
            int id;
            string nom;
            
            while (dr.Read() == true)
            {
                id = Convert.ToInt32(dr["ID_CLIENT"]);
                nom = dr["nom"].ToString();

                item = new Itemcpl(id, nom);
                listBoxClient.Items.Add(item);
            }

            dr.Close();
            cn.Close();
        }

        private void listBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Itemcpl its = (Itemcpl)listBoxClient.SelectedItem;

            int theid = its.getId();


            string nomclient = listBoxClient.SelectedItem.ToString();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select * from client where ID_CLIENT = " + theid.ToString();

            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            dr.Read();

            textBoxNom.Text = dr["Nom"].ToString();
            textBoxMail.Text = dr["Mail"].ToString();
            textBoxTel.Text = dr["Tel"].ToString();

            dr.Close();
            cn.Close();
        }

        private void buttonAJouter_Click(object sender, EventArgs e)
        {
            // Ajouter
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment ajouter un client ?",
                "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif nom           
            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Nom de client vide !", "Warning");
                textBoxNom.Focus();
                return;
            }

            // Ajout d'un client !!!

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "INSERT INTO Client VALUES(@lenom, @lemail, @letel)";

            SqlCommand com = new SqlCommand(strsql, cn);
            com.Parameters.AddWithValue("lenom", textBoxNom.Text);
            com.Parameters.AddWithValue("lemail", textBoxMail.Text);
            com.Parameters.AddWithValue("letel", textBoxTel.Text);

            int res = com.ExecuteNonQuery();

            if (res == 1)
            {
                MessageBox.Show("Client ajouté", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            cn.Close();

            textBoxNom.Text = textBoxMail.Text = textBoxTel.Text = "";

            FillClientList();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // Modifier
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment modifier un client ?",
                "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif listbox
            int i = listBoxClient.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Veuillez choisir un client !", "Warning");
                listBoxClient.Focus();
                return;
            }

            // Modifier un client !!!
            Itemcpl its = (Itemcpl)listBoxClient.SelectedItem;
            int theid = its.getId();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strSql = "UPDATE Client SET Nom = @lenom ,Mail = @lemail,Tel = @letel WHERE ID_CLIENT = @lid";
            SqlCommand com = new SqlCommand(strSql, cn);
            com.Parameters.AddWithValue("lenom", textBoxNom.Text);
            com.Parameters.AddWithValue("lemail", textBoxMail.Text);
            com.Parameters.AddWithValue("letel", textBoxTel.Text);
            com.Parameters.AddWithValue("lid", theid);

            int res = com.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("Client modifié", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            cn.Close();
            textBoxNom.Text = textBoxMail.Text = textBoxTel.Text = "";
            FillClientList();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {       
            // Supprimer
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment supprimer un client ?",
                "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif listbox
            int i = listBoxClient.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Veuillez choisir un client !", "Warning");
                listBoxClient.Focus();
                return;
            }

            // Supprimer un client !!!
            Itemcpl its = (Itemcpl)listBoxClient.SelectedItem;
            int theid = its.getId();

            SqlConnection cn = null;
            SqlCommand com = null;

            try
            {                
                cn = new SqlConnection(strcon);
                cn.Open();

                string strSql = "DELETE FROM Client WHERE ID_CLIENT = @idclient";
                com = new SqlCommand(strSql, cn);
                com.Parameters.AddWithValue("idclient", theid);

                int res = com.ExecuteNonQuery();

                if (res == 1)
                {
                    MessageBox.Show("Client supprimé", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBoxNom.Text = textBoxMail.Text = textBoxTel.Text = "";
                FillClientList();
            }
            catch (SqlException ex)
            {
                int sqr = ex.Errors[0].Number;

                if (sqr == 547)
                {
                    MessageBox.Show("Impossible de supprimer un client qui détient un matériel", "Erreur",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Problème de base de données, contactez votre admin", "Erreur",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème système, merci de contacter votre admin");
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                }
                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
    }
}
