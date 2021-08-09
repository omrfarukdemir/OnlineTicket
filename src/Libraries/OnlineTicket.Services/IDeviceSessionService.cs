using System.Threading.Tasks;
using OnlineTicket.Models.Services.DeviceSession;

namespace OnlineTicket.Services
{
    public interface IDeviceSessionService
    {
        ValueTask<DeviceSessionModel> GetDeviceSessionAsync();
    }
}