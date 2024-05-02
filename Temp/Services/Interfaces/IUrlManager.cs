using Temp.Services.Utils;

namespace Temp.Services
{
    public interface IUrlManager
    {
        string GetUrlWithOptions(QueryOptions options);
    }
}
