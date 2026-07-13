using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Infrastructure.Services
{
    public sealed class NullAuditService : IAuditService
    {
        public void ApplyAuditInformation(
            IEnumerable<EntityEntry> entries)
        {
            // Do Nothing
        }
    }
}
