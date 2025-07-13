using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient; // Pour interagir avec SQL Server

namespace WindowsFormsAppMJV
{
    public partial class FormHistorique : Form
    {
        // Constructeur du formulaire
        public FormHistorique()
        {
            InitializeComponent(); // Initialise les composants graphiques
            this.Load += new EventHandler(FormHistorique_Load); // Associe l'événement Load à la méthode
        }

       
        private void FormHistorique_Load(object sender, EventArgs e)
        {
            // connexion à SQL Server avec la base de données MJV
            SqlConnection cn = new SqlConnection("Server=.\\SQLEXPRESS;Database=MJV;Trusted_Connection=True;");
            cn.Open(); // Ouverture de la connexion

            // Requête SQL : on récupère pour chaque matériel sa dernière intervention
            string sql = @"
                SELECT 
                    M.NOM AS MATERIEL,                         -- Nom du matériel
                    I.Date_inter AS DERNIERE_INTERVENTION,     -- Date de la dernière intervention
                    I.Comment AS MOTIF                         -- Motif/commentaire de l’intervention
                FROM INTERVENTION I
                INNER JOIN (
                    SELECT ID_MATOS, MAX(Date_inter) AS MAX_DATE
                    FROM INTERVENTION
                    GROUP BY ID_MATOS
                ) LastInter
                ON I.ID_MATOS = LastInter.ID_MATOS
                AND I.Date_inter = LastInter.MAX_DATE
                JOIN MATOS M ON M.ID_MATOS = I.ID_MATOS
                ORDER BY M.NOM;
            ";

            // Exécution de la requête SQL
            SqlDataAdapter da = new SqlDataAdapter(sql, cn); // Prépare l'exécution
            DataTable dt = new DataTable(); // Crée un tableau en mémoire
            da.Fill(dt); // Remplit ce tableau avec le résultat SQL

            

            // Affiche les données dans le DataGridView du formulaire
            dataGridViewHistorique.DataSource = dt;

            
        

            cn.Close(); // Fermeture de la connexion SQL
        }

        // Méthode vide pour gérer un clic sur une cellule du DataGridView (non utilisée ici)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
