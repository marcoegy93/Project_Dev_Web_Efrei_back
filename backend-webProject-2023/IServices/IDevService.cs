using backend_webProject_2023.Modele;

namespace backend_webProject_2023.IServices
{
    public interface IDevService
    {
        public List<Ticket> getTicketList(int idUser);
        public void updateTicket(Ticket ticket);

        public void deleteTicket(int idTicket);

    }
}
