using backend_webProject_2023.Modele;
using Microsoft.Identity.Client;

namespace backend_webProject_2023.IServices
{
    public interface IRapporteurService
    {

       public void createTicket(Ticket ticket, int idRapporteur);
        public void createProjet(Projet projet);
        public List<Projet> getListProjet(int idUser);

    }
}
