using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PhotoBooth.Model;
using PhotoBooth.SigR;

namespace PhotoBooth.Controllers
{
    [Route("api/MessageController")]
    public class MessageController : Controller
    {
        private static int _countdown = 10;

        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
            Console.WriteLine("MessageController created." + _countdown);
        }

        [HttpGet("SendNotification")]
        public string SendNotification([FromQuery] string type, [FromQuery] string message)
        {
            string retMessage = string.Empty;
            try
            {
                if (type == "notify")
                {
                    _hubContext.Clients.All.Notify(message);
                    retMessage = "Success";
                }
                else if (type == "navigate")
                {
                    _hubContext.Clients.All.Navigate(message);
                    retMessage = "Success";
                }
                else
                {
                    retMessage = "Failed. Unknown type";
                }
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }

        [HttpGet("SendMessage")]
        public string SendMessage()
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.All.BroadcastMessage("notify", _countdown.ToString());
                _countdown--;
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
    }
}