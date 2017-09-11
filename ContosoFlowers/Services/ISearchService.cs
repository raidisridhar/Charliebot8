using System.Threading.Tasks;
using ContosoFlowers.Models.Search;

namespace ContosoFlowers.Services
{
    public interface ISearchService
    {
        string FindArticles(string query);
    }
}
