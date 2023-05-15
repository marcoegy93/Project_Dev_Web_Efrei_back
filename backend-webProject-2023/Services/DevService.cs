using backend_webProject_2023.IServices;
using backend_webProject_2023.Modele;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace backend_webProject_2023.Services
{
    public class DevService : IDevService
    {
        SqlConnection _con;

        public DevService()
        {
            String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= master; Integrated Security = true";
            _con = new SqlConnection(strConnexion);
            _con.Open();
        }


        public List<Ticket> getTicketList(int idUser)
        {
            String queryAdmin = "Select type from Utilisateur where idUser = " + idUser;
            SqlCommand cmd = new SqlCommand(queryAdmin, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Ticket> listTicket = new List<Ticket>();
            string query = "SELECT p.nom, t.idTicket, t.description, t.nom,t.dateCreation, client.nom as nomClient,client.prenom as prenomClient, rapporteur.nom as nomRapporteur, rapporteur.prenom as prenomRapporteur, t.etat,dev.nom as nomDev,dev.prenom as prenomDev,t.idProjet FROM [Ticket] as t INNER JOIN [Projet] as p on t.idProjet =p.idProjet  INNER JOIN [Utilisateur] as Client on Client.idUser = t.idClient INNER JOIN [Utilisateur] as Rapporteur on Rapporteur.idUser = t.idRapporteur INNER JOIN [Utilisateur] as dev on dev.idUser = t.idDev ";
            if (reader.Read() && reader.GetValue(0).ToString() == "Dev") 
                query = query + "where t.idDev="+ idUser;
            if (reader.GetValue(0).ToString() == "Client")
                query = query + "where t.idClient=" + idUser + " OR t.idTicket in ( SELECT  t.idTicket FROM [Ticket] as t INNER JOIN [Projet] as p on t.idProjet =p.idProjet  INNER JOIN [Utilisateur] as Client on Client.idUser = t.idClient INNER JOIN [Utilisateur] as Rapporteur on Rapporteur.idUser = t.idRapporteur INNER JOIN [Utilisateur] as dev on dev.idUser = t.idDev inner join Souscrit s on s.idProjet = t.idProjet where s.idClient =" + idUser +")";

            reader.Close();
            cmd.Dispose();

        
                cmd = new SqlCommand(query, _con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    listTicket.Add(new Ticket(
                                reader.GetValue(0).ToString(),
                                Convert.ToInt32(reader.GetValue(1)),
                                reader.GetValue(2).ToString(),
                                reader.GetValue(3).ToString(),
                                DateTime.Parse(reader.GetValue(4).ToString()),
                                reader.GetValue(5).ToString(),
                                reader.GetValue(6).ToString(),
                                reader.GetValue(7).ToString(),
                                reader.GetValue(8).ToString(),
                                reader.GetValue(9).ToString(),
                                reader.GetValue(10).ToString(),
                                reader.GetValue(11).ToString(),
                                Convert.ToInt32(reader.GetValue(12))
                            )
                         );
                }

   
            return listTicket;

        }




        public void updateTicket(Ticket ticket)
        {
            System.Diagnostics.Debug.WriteLine(ticket);
            System.Diagnostics.Debug.WriteLine(ticket.nomDev);

            String query = "UPDATE Ticket SET description = '" + ticket.description + "', nom = '" + ticket.nom + "', etat = '" + ticket.etat + "', idClient = client.idUser, idRapporteur = rapporteur.idUser, idDev = dev.idUser " +
                           "FROM Utilisateur AS client, Utilisateur AS rapporteur,Utilisateur AS dev " +
                           "WHERE idTicket = " + ticket.idTicket +
                           " AND rapporteur.Nom = '" + ticket.nomRapporteur + "' " +
                           " AND rapporteur.Prenom = '" + ticket.prenomRapporteur + "' " +
                           " AND client.nom = '" + ticket.nomClient + "' " +
                           " AND client.prenom = '" + ticket.prenomClient + "' " +
                           " AND dev.nom = '" + ticket.nomDev + "' " +
                           " AND dev.prenom = '" + ticket.prenomDev + "'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        public void deleteTicket(int idTicket)
        {
            String query = "DELETE FROM [Ticket] where idTicket =" + idTicket;
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }
    }
}
