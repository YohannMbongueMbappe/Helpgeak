using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMJV
{
    // Définition du formulaire de connexion
    public partial class FormLogin : Form
    {
        // Variables publiques pour stocker le login et le mot de passe saisis
        public string login, pwd;

        // Constructeur du formulaire
        public FormLogin()
        {
            InitializeComponent(); // Initialisation des composants graphiques
        }

        // Événement déclenché lorsque le texte du champ login est modifié
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Événement déclenché lorsque le texte du champ mot de passe est modifié
        private void textBoxMDP_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Événement appelé lors du chargement du formulaire
        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegister reg = new FormRegister();
            reg.ShowDialog();

        }

        // Événement appelé lorsque l'utilisateur clique sur le bouton OK
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Récupération des données saisies dans les champs login et mot de passe
            this.login = textBoxLogin.Text;
            this.pwd = textBoxMDP.Text;

            // Indique que le formulaire s'est terminé correctement (OK)
            this.DialogResult = DialogResult.OK;

            // Ferme le formulaire
            this.Close();
        }
    }
}
