using System;
using Microsoft.AspNetCore.Mvc;
using PhotoBooth.Helpers;

namespace PhotoBooth.Controllers
{
    [Route("api/[controller]")]
    public class PhotoBoothController : Controller
    {
        [HttpGet("[action]")]
        public void LiveAndCapture()
        {
            var res = BashHelper.ExecuteBlockingBash("cd /home/pi/fftest && ./liveandpicture.sh");
            Console.WriteLine(res);
        }
    }
}