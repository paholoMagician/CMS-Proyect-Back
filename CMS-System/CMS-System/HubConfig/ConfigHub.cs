using Microsoft.AspNetCore.SignalR;

namespace hubproject.HubConfig
{
    public class ConfigHub : Hub
    {
        public static string GenerateResponseMessage(string input)
        {
            if (input == "key")
            {
                return "HOLI FUNCIONANDO";
            }
            else
            {
                return "Mensaje enviado desde el backend 222";
            }
        }

        public async Task askServer(string someTextFromClient)
        {
            string tempString = GenerateResponseMessage(someTextFromClient);
            await Clients.Clients(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);
        }
    }
}
