namespace backend_webProject_2023.Modele
{
    public class Ticket
    {
        public int? idTicket { get; set; }
        public string? nom { get; set; }
        public string? description { get; set; }
        public string? nomProjet { get; set; }
        public DateTime? dateCreation { get; set; }
        public string? nomClient { get; set; }
        public string? prenomClient { get; set; }
        public string? nomRapporteur { get; set; }
        public string? prenomRapporteur { get; set; }
        public string? etat { get; set; }
        public string? nomDev { get; set; }
        public string? prenomDev { get; set; }
        public int idProjet { get; set; }



        public Ticket()
        {
        }

        public Ticket(string nomProjet,int idTicket, string description, string nom, DateTime dateCreation, string nomClient, string prenomClient,string nomRapporteur,string prenomRapporteur,string etat, string nomDev,string prenomDev, int idProjet )
        {
            this.idTicket = idTicket;   
            this.nom = nom;
            this.description = description;
            this.nomProjet = nomProjet;
            this.nomRapporteur = nomRapporteur;
            this.nomClient= nomClient;
            this.dateCreation = dateCreation;
            this.prenomRapporteur = prenomRapporteur;
            this.prenomClient = prenomClient;
            this.etat = etat;
            this.nomDev= nomDev;
            this.prenomDev= prenomDev;
            this.idProjet= idProjet;
        }

    }
}
