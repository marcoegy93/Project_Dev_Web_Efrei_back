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
            String query = "SELECT  * FROM [Web_Project].[dbo].[Utilisateur] where login='" + login + "' and mdp = '" + mdp+ "'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            User user =  null;
            while (reader.Read())
            {
                user = new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        Convert.ToDateTime(reader.GetValue(3)),
                         reader.GetValue(4).ToString(),
                        Convert.ToBoolean(reader.GetValue(6))
                    );
            }
            return user;
        }



        public List<User> getUserList()
        {
            String query = "SELECT  * FROM [Web_Project].[dbo].[Utilisateur]";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> listUser = new List<User>();
            while (reader.Read())
            {
                listUser.Add( new User(
                     Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        Convert.ToDateTime(reader.GetValue(3)),
                         reader.GetValue(4).ToString(),
                        Convert.ToBoolean(reader.GetValue(6))
                    )
                 );
            }
            return listUser;
        }


        public void deleteUser(string idUser)
        {
            String query = "DELETE FROM [Web_Project].[dbo].[Utilisateur] where idUtilisateur ="+ idUser;
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        public void addUser(User user)
        {
            String query = "INSERT INTO [Web_Project].[dbo].[Utilisateur] (nom, prenom, dateCreationCompte, login, mdp, isAdmin) VALUES ('" + user.nom+ "', '"+user.prenom+ "', '"+ DateTime.Now + "', '"+user.login+ "', '"+user.password+ "', "+ (user.isAdmin == true? 1:0) +")";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        public void modifyUser(User user)
        {
            String query = $"Update[Web_Project].[dbo].[Utilisateur] set nom = '{user.nom}', prenom = '{user.prenom}', login = '{user.login}' where idUtilisateur = {user.idUtilisateur}";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
        }



    }
}
