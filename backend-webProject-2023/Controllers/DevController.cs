using backend_webProject_2023.IServices;
using backend_webProject_2023.Modele;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_webProject_2023.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevController : ControllerBase
    {
        IDevService _devService;

        public DevController(IDevService devService)
        {
            this._devService = devService;
        }

        [HttpGet("listTicket/{idDev}")]
        public List<Ticket> getUserList(int idDev )
        {
            return this._devService.getTicketList(idDev);
        }

        [HttpPost("updateTicket/")]
        public void updateTicket([FromBody]Ticket ticket)
        {
            this._devService.updateTicket(ticket);
        }

        [HttpGet("deleteTicket/")]
        public void deleteTicket([FromBody] int idTicket)
        {
            this._devService.deleteTicket(idTicket);
        }
    }
}
