using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PhotoBooth.Helpers;
using PhotoBooth.SigR;

namespace PhotoBooth.Controllers
{
    [Route("api/PhotoBoothController")]
    public class PhotoBoothController : Controller
    {
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public PhotoBoothController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("LiveAndCapture")]
        public void LiveAndCapture()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("PhotoBooth Workflow: Start PhotoBooth Workflow");
                Console.WriteLine("PhotoBooth Workflow: Start Start Live View");
                StartLiveView();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _hubContext.Clients.All.Notify("3");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("2");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("1");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("CHÄÄÄÄÄÄÄÄÄS");
                Console.WriteLine("PhotoBooth Workflow: Take Picture");
                TakePicture();
            });
        }

        [HttpGet("StartLiveView")]
        public void StartLiveView()
        {
            _hubContext.Clients.All.Navigate("live-view");
        }

        [HttpGet("StopLiveView")]
        public void StopLiveView()
        {
        }

        [HttpGet("TakePicture")]
        public void TakePicture()
        {
            var res = BashHelper.ExecuteBlockingBash("cd /home/pi/photobooth && ./takePicture.sh");
            Console.WriteLine(res);
            _hubContext.Clients.All.Navigate("capture");
        }

        [HttpGet("PrintPicture")]
        public void PrintPicture()
        {
            var res = BashHelper.ExecuteNonBlockingBash("lp /home/pi/net/photobooth/ClientApp/dist/assets/latest.jpg");
            Console.WriteLine(res);
            Home();
        }

        [HttpGet("Home")]
        public void Home()
        {
            _hubContext.Clients.All.Navigate("home");
        }

        [HttpGet("Init")]
        public void Init()
        {
            var res = BashHelper.ExecuteBlockingBash("cd scripts && ./initsystem.sh");
            Console.WriteLine(res);
        }
    }
}