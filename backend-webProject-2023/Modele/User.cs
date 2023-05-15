using System;

namespace backend_webProject_2023.Modele
{
    public class User
    {
        public int? idUtilisateur { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string login { get; set; }
        public string? password { get; set; }
        public string? type { get; set; }



        public User() { }
        public User(int idUtilisateur, string nom, string prenom, string login,string type )
        {
            this.idUtilisateur = idUtilisateur;
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.type = type;
        }
    }
}
