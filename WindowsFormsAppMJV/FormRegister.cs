using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppMJV
{
    public partial class FormRegister : Form
    {
        // Chaîne de connexion à la base de données MJV sur le serveur local
        private string strcon = "Server=.\\SQLEXPRESS;Database=MJV;Trusted_Connection=True;";

        public FormRegister()
        {
            InitializeComponent(); // Initialise les composants du formulaire (boutons, textbox, etc.)
        }

        // Méthode appelée lorsque l'utilisateur clique sur le bouton "S'inscrire"
        private void buttonInscrire_Click(object sender, EventArgs e)
        {
            // On récupère le login et le mot de passe saisis par l'utilisateur
            string login = textBoxLogin.Text.Trim();
            string pwd = textBoxPwd.Text.Trim();

            // Vérifie que les champs ne sont pas vides
            if (login == "" || pwd == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Hachage du mot de passe avec SHA256 avant stockage en base
            string hashPwd = HashPassword(pwd);

            // Ouverture de la connexion SQL
            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();

            // Vérifie si un utilisateur avec le même login existe déjà
            string check = "SELECT COUNT(*) FROM Utilisateur WHERE Nom = @nom";
            SqlCommand checkCmd = new SqlCommand(check, cn);
            checkCmd.Parameters.AddWithValue("@nom", login);

            int count = (int)checkCmd.ExecuteScalar(); // Renvoie le nombre de lignes trouvées

            if (count > 0)
            {
                // Si un utilisateur existe déjà, on affiche un message et on arrête
                MessageBox.Show("Ce nom d'utilisateur existe déjà !");
                cn.Close();
                return;
            }

            // Préparation de la requête SQL pour insérer le nouvel utilisateur
            string strsql = "INSERT INTO Utilisateur (Nom, MDP) VALUES (@nom, @mdp)";
            SqlCommand cmd = new SqlCommand(strsql, cn);
            cmd.Parameters.AddWithValue("@nom", login);       // nom d'utilisateur
            cmd.Parameters.AddWithValue("@mdp", hashPwd);     // mot de passe haché

            int res = cmd.ExecuteNonQuery(); // Exécution de la requête (INSERT)

            // Si l'insertion a fonctionné
            if (res == 1)
            {
                MessageBox.Show("Enregistrement Reussi !");
                this.Close(); // Ferme le formulaire après succès
            }

            // Fermeture de la connexion SQL
            cn.Close();
        }

        // Fonction utilitaire qui génère un hash SHA256 à partir d'un mot de passe
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertit le mot de passe en tableau de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertit les bytes en chaîne hexadécimale lisible
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // "x2" = hexadécimal sur 2 caractères
                }

                return builder.ToString(); // Retourne le hash final
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPwd_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
