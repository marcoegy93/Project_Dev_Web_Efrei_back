using backend_webProject_2023.IServices;
using backend_webProject_2023.Modele;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace backend_webProject_2023.Services
{
    public class RapporteurService: IRapporteurService
    {

        SqlConnection _con;

        public RapporteurService()
        {
            String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= master; Integrated Security = true";
            _con = new SqlConnection(strConnexion);
            _con.Open();
        }

        public void createTicket(Ticket ticket, int idRapporteur)
        {
            String query = "INSERT INTO Ticket ([description], [nom], [etat], [dateCreation], [idDev], [idClient], [idRapporteur], [idProjet]) " +
                "SELECT '" + ticket.description + "', '" + ticket.nom + "', '" + ticket.etat + "', '" + ticket.dateCreation + "', " +
                "dev.idUser, client.idUser, '" + idRapporteur + "', '" + ticket.idProjet + "' " +
                "FROM Utilisateur AS dev, Utilisateur AS client " +
                "WHERE dev.nom = '" + ticket.nomDev + "' AND dev.prenom = '" + ticket.prenomDev + "' AND " +
                "client.nom = '" + ticket.nomClient + "' AND client.prenom = '" + ticket.prenomClient + "'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        public void createProjet(Projet projet)
        {
            String query = " INSERT INTO Projet ( Nom, Description) Values('" + projet.nom + "','" + projet.description + "')";
            SqlCommand cmd = new SqlCommand(query, _con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            String queryId = "SELECT  max(idProjet) FROM [Projet]";
             cmd = new SqlCommand(queryId, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            string insertQuery= "INSERT INTO Souscrit ( idProjet,idClient) Values";
            int idProjet = Convert.ToInt32(reader.GetValue(0));
            cmd.Dispose();
            reader.Close();

            foreach (int idClient in projet.listClient)
            {

                insertQuery = insertQuery + "( "+idProjet+","+idClient+"),";

               

            }
            if (projet.listClient.Length > 0)
            {
                insertQuery = insertQuery.Remove(insertQuery.Length - 1);
                System.Diagnostics.Debug.WriteLine(insertQuery);

                cmd = new SqlCommand(insertQuery, _con);
                cmd.ExecuteNonQuery();
            }
            
        }

        public List<Projet> getListProjet(int idUser)
        {
            string query = "SELECT distinct p.idProjet,p.nom as nom, p.description as description FROM [Ticket] as t RIGHT JOIN [Projet] as p on t.idProjet =p.idProjet  INNER JOIN Souscrit as s on p.idProjet = s.idProjet where s.idClient = "+idUser+"or t.idClient =" + idUser;
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Projet> listProjet  = new List<Projet>();

            while (reader.Read())
            {

                listProjet.Add(
                    new Projet(Convert.ToInt32(reader.GetValue(0)),reader.GetValue(1).ToString(), reader.GetValue(2).ToString())
              );
            }
            return listProjet;
        }

    }
}
