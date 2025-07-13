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

namespace WindowsFormsAppMJV
{
    public partial class FormTypeMatos : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
         "Database=MJV;Trusted_Connection=True;";
        public FormTypeMatos()
        {
            InitializeComponent();
        }



        private void FillTypesMatosList()
        {
            listBoxTypes.Items.Clear();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select ID_TYPE, NOM from TYPE_MATOS order by nom";
            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            Itemcpl item;
            int id;
            string nom;

            while (dr.Read() == true)
            {
                id = Convert.ToInt32(dr["ID_TYPE"]);
                nom = dr["nom"].ToString();

                item = new Itemcpl(id, nom);
                listBoxTypes.Items.Add(item);
            }

            dr.Close();
            cn.Close();
        }

        private void FormTypeMatos_Load(object sender, EventArgs e)
        {
            FillTypesMatosList();

            listBoxTypes.Focus();
        }

        private void listBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Itemcpl its = (Itemcpl)listBoxTypes.SelectedItem;

            int theid = its.getId();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select * from TYPE_MATOS where ID_TYPE = " + theid.ToString();

            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            dr.Read();

            textBoxNom.Text = dr["Nom"].ToString();

            dr.Close();
            cn.Close();
        }

        private void buttonAJouter_Click(object sender, EventArgs e)
        {
            // Ajouter
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment ajouter un type ?",
                "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif nom           
            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Nom de type vide !", "Warning");
                textBoxNom.Focus();
                return;
            }

            // Ajout d'un type !!!

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "INSERT INTO TYPE_MATOS VALUES(@lenom)";

            SqlCommand com = new SqlCommand(strsql, cn);
            com.Parameters.AddWithValue("lenom", textBoxNom.Text);


            int res = com.ExecuteNonQuery();

            if (res == 1)
            {
                MessageBox.Show("Type ajouté", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            cn.Close();

            textBoxNom.Text  = "";

            FillTypesMatosList();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // Modifier
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment modifier un type ?",
                "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif listbox
            int i = listBoxTypes.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Veuillez choisir un type !", "Warning");
                listBoxTypes.Focus();
                return;
            }

            // Modifier un type !!!
            Itemcpl its = (Itemcpl)listBoxTypes.SelectedItem;
            int theid = its.getId();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strSql = "UPDATE TYPE_MATOS SET Nom = @lenom where ID_TYPE = @lid";
            SqlCommand com = new SqlCommand(strSql, cn);
            com.Parameters.AddWithValue("lenom", textBoxNom.Text);
            com.Parameters.AddWithValue("lid", theid);

            int res = com.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("Type modifié", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            cn.Close();
            textBoxNom.Text = "";
            FillTypesMatosList();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // Supprimer
            DialogResult drrep = MessageBox.Show("Voulez vous vraiment supprimer un type ?",
                "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drrep == DialogResult.No)
            {
                return;
            }

            // verif listbox
            int i = listBoxTypes.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Veuillez choisir un Type !", "Warning");
                listBoxTypes.Focus();
                return;
            }

            // Supprimer un type !!!
            Itemcpl its = (Itemcpl)listBoxTypes.SelectedItem;
            int theid = its.getId();

            SqlConnection cn = null;
            SqlCommand com = null;

            try
            {
                cn = new SqlConnection(strcon);
                cn.Open();

                string strSql = "DELETE FROM TYPE_MATOS WHERE ID_TYPE = @idtype";
                com = new SqlCommand(strSql, cn);
                com.Parameters.AddWithValue("idtype", theid);

                int res = com.ExecuteNonQuery();

                if (res == 1)
                {
                    MessageBox.Show("Type supprimé", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBoxNom.Text =  "";
                FillTypesMatosList();
            }
            catch (SqlException ex)
            {
                int sqr = ex.Errors[0].Number;

                if (sqr == 547)
                {
                    MessageBox.Show("Impossible de supprimer un type qui référence un matériel", "Erreur",
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
