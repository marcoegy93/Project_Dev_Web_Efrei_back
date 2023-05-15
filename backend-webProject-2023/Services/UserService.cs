using backend_webProject_2023.IServices;
using backend_webProject_2023.Modele;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace backend_webProject_2023.Services
{
    public class UserService : IUserService
    {
        SqlConnection _con;

        public UserService()
        {
            String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= master; Integrated Security = true";
            _con = new SqlConnection(strConnexion);
            _con.Open();
        }

        public User authentification(string login, string mdp)
        {
            String query = "SELECT  * FROM [Utilisateur] where login='" + login + "' and password = '" + mdp+ "'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            User user =  null;
            while (reader.Read())
            {
                user = new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString()

                    );
            }
            return user;
        }



        public List<User> getUserList()
        {
            String query = "SELECT  * FROM [Utilisateur]";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> listUser = new List<User>();
            while (reader.Read())
            {
                listUser.Add(new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString()

                    )
                 );
            }
            return listUser;
        }


        public void deleteUser(string idUser)
        {
            String query = "DELETE FROM [Utilisateur] where idUser ="+ idUser;
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        public void addUser(User user)
        {
            String query = "INSERT INTO [Utilisateur] (nom, prenom, password, login, type) VALUES ('" + user.nom+ "', '"+user.prenom+ "', '"+ user.password+ "', '"+user.login+ "', '"+ user.type+"')";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        public void modifyUser(User user)
        {
            String query = $"Update [Utilisateur] set nom = '{user.nom}', prenom = '{user.prenom}', login = '{user.login}' where idUser = {user.idUtilisateur}";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }


        public List<User> getClientList()
        {
            String query = "SELECT  * FROM [Utilisateur] where type = 'Client'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> listClient = new List<User>();
            while (reader.Read())
            {
                listClient.Add(new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString()

                    )
                 );
            }
            return listClient;
        }
        public List<User> getRapporteurList()
        {
            String query = "SELECT  * FROM [Utilisateur] where type = 'Rapporteur'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> listRapporteur = new List<User>();
            while (reader.Read())
            {
                listRapporteur.Add(new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString()

                    )
                 );
            }
            return listRapporteur;
        }

        public List<User> getDevList()
        {
            String query = "SELECT  * FROM [Utilisateur] where type = 'Dev'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> listDev = new List<User>();
            while (reader.Read())
            {
                listDev.Add(new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString()

                    )
                 );
            }
            return listDev;
        }


    }
}
