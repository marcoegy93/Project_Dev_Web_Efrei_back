namespace backend_webProject_2023.Modele
{
    public class Projet
    {
        public int? idProjet { get; set; }

        public string?  nom { get; set; }
        public string? description { get; set; }
        public int []? listClient { get; set; }


        public Projet() { }

        public Projet(int idProjet, string nom, string description)
        {
            this.nom = nom;
            this.description = description;
            this.idProjet = idProjet;
        }

    }
}
