using System.Threading.Tasks;

namespace PhotoBooth.SigR
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
        Task Navigate(string target);
        Task Notify(string timer);
    }
}