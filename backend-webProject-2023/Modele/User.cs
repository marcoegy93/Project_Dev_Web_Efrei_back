using System;

namespace backend_webProject_2023.Modele
{
    public class User
    {
        public int? idUtilisateur { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime dateCreationCompte { get; set; }
        public string login { get; set; }
        public bool isAdmin { get; set; }
        public string? password { get; set; }


        public User() { }
        public User(int idUtilisateur, string nom, string prenom, DateTime dateCreationCompte, string login, bool isAdmin)
        {
            this.idUtilisateur = idUtilisateur;
            this.nom = nom;
            this.prenom = prenom;
            this.dateCreationCompte = dateCreationCompte;
            this.login = login;
            this.isAdmin = isAdmin;
        }
    }
}
