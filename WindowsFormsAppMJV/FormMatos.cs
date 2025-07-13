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

namespace WindowsFormsAppMJV
{
    public partial class FormMatos : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
                "Database=MJV;Trusted_Connection=True;";
        public FormMatos()
        {
            InitializeComponent();
        }

        private void FormMatos_Load(object sender, EventArgs e)
        {
            FillMatosList();
            FillTypeList();
            FillClientList();

            listBoxMatos.Focus();
        }

        private void FillTypeList()
        {
            comboBoxType.Items.Clear();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select ID_TYPE, NOM from TYPE_MATOS order by nom";
            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            Itemcpl it;
            int id;
            string nom;

            while (dr.Read() == true)
            {
                id = Convert.ToInt32(dr["ID_TYPE"]);
                nom = dr["NOM"].ToString();
                it = new Itemcpl(id, nom);
                comboBoxType.Items.Add(it);
            }

            dr.Close();
            cn.Close();
        }

        private void FillClientList()
        {
            comboBoxClient.Items.Clear();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select ID_CLIENT, NOM from CLIENT order by nom";
            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            Itemcpl it;
            int id;
            string nom;

            while (dr.Read() == true)
            {
                id = Convert.ToInt32(dr["ID_CLIENT"]);
                nom = dr["NOM"].ToString();
                it = new Itemcpl(id, nom);
                comboBoxClient.Items.Add(it);
            }

            dr.Close();
            cn.Close();
        }


        private void FillMatosList()
        {
            listBoxMatos.Items.Clear();

            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            string strsql = "select ID_MATOS, NOM from MATOS order by nom";
            SqlCommand com = new SqlCommand(strsql, cn);
            SqlDataReader dr = com.ExecuteReader();

            Itemcpl item;
            int id;
            string nom;

            while (dr.Read() == true)
            {
                id = Convert.ToInt32(dr["ID_MATOS"]);
                nom = dr["nom"].ToString();

                item = new Itemcpl(id, nom);
                listBoxMatos.Items.Add(item);
            }

            dr.Close();
            cn.Close();
        }

        private void buttonAJouter_Click(object sender, EventArgs e)
        {
            // pour vérification
            Itemcpl p = (Itemcpl)comboBoxType.SelectedItem;
            int idtype = p.getId();

            // aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        }
    }
}
