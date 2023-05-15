using backend_webProject_2023.IServices;
using backend_webProject_2023.Modele;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_webProject_2023.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RapporteurController : ControllerBase
    {

        IRapporteurService _rapporteurService;

        public RapporteurController(IRapporteurService rapporteurService)
        {
            this._rapporteurService = rapporteurService;
        }


        [HttpPost("createTicket/{idRapporteur}")]
        public void createTicket(Ticket ticket, int idRapporteur)
        {
            this._rapporteurService.createTicket(ticket, idRapporteur);
            Ok();
        }

        [HttpGet("listProjet/{idUser}")]
        public List<Projet>  getListProject(int idUser)
        {
            
           return  this._rapporteurService.getListProjet(idUser);
        }

        [HttpPost("createProject/")]
        public void createProjet(Projet projet)
        {
            this._rapporteurService.createProjet(projet);
            Ok();
        }

    }
}
