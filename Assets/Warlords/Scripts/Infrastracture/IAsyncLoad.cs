using System.Threading.Tasks;

namespace Warlords.Infrastracture
{
    public interface IAsyncLoad
    {
        Task AsyncLoad();
    }
}