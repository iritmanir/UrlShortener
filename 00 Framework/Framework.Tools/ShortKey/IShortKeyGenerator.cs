using System.Threading.Tasks;

namespace Framework.Tools.ShortKey
{
    public interface IShortKeyGenerator
    {
        Task<string> GenerateUniqKey();
    }
}