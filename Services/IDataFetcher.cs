using System.Collections.Generic;
using System.Threading.Tasks;
using roksh.Models;

namespace roksh.Services {
    public interface IDataFetcher {
        Task<IEnumerable<Item>> GetItems();
    }
}