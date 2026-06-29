using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Database
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
