using hubproject.HubConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
namespace CMS_System.Controllers.alerts_controller
{
    [Route("api/Alerts")]
    [ApiController]
    public class AlertController : ControllerBase
    {

        private readonly IHubContext<ConfigHub> _hubContext;

        public AlertController(IHubContext<ConfigHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("alert")]
        public async Task<IActionResult> SendAlert([FromBody] string message)
        {
            try
            {
                string tempString = ConfigHub.GenerateResponseMessage(message);
                await _hubContext.Clients.All.SendAsync("askServerResponse", tempString);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
