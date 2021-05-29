using System.Threading.Tasks;

namespace Framework.Tools.ShortKey
{
    public class ShortKeyGenerator : IShortKeyGenerator
    {
        public async Task<string> GenerateUniqKey()
        {
            return "TestKey";
        }
    }
}