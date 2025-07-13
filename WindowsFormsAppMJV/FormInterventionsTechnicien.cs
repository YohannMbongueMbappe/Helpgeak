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
    public partial class FormInterventionsTechnicien : Form
    {
        public FormInterventionsTechnicien()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormInterventionsTechnicien_Load);
        }

        private void FormAjoutIntervention_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;Database=MJV;Trusted_Connection=True;");
            cn.Open();

            string sql = "SELECT id_technician, nom FROM TECHNICIEN ORDER BY nom";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();

            comboBoxTechnicien.Items.Clear();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id_technician"]);
                string nom = dr["nom"].ToString();
                comboBoxTechnicien.Items.Add(new Itemcpl(id, nom));
            }

            dr.Close();
            cn.Close();
        }

        private void FormInterventionsTechnicien_Load(object sender, EventArgs e)
        {

        }
    }
}
