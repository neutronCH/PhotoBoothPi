using System;
using System.Net.Http;
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
                Console.WriteLine("PhotoBooth Workflow: Start LiveView");
                StartLiveView();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                _hubContext.Clients.All.Notify("5");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("4");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("3");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("2");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _hubContext.Clients.All.Notify("1");
                Console.WriteLine("PhotoBooth Workflow: Stop LiveView");
                StopLiveView();
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                _hubContext.Clients.All.Notify("CHÄÄÄÄÄÄÄÄÄS");
                Console.WriteLine("PhotoBooth Workflow: Take Picture");
                TakePicture();
            });
        }
        
        [HttpGet("StartLiveView")]
        public void StartLiveView()
        {
            _hubContext.Clients.All.Navigate("live-view");
            var res = BashHelper.ExecuteNonBlockingBash("cd /home/pi/photobooth && ./startLiveView.sh");
            Console.WriteLine(res);
        }
        
        [HttpGet("StopLiveView")]
        public void StopLiveView()
        {
            var res = BashHelper.ExecuteNonBlockingBash("cd /home/pi/photobooth && ./stopLiveView.sh");
            Console.WriteLine(res);
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
        }
        
        [HttpGet("Init")]
        public void Init()
        {
            var res = BashHelper.ExecuteBlockingBash("cd scripts && ./initsystem.sh");
            Console.WriteLine(res);
        }
    }
}