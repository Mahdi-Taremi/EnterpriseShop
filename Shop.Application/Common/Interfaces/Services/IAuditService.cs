using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces.Services
{
    public interface IAuditService
    {
        void ApplyAuditInformation(
            IEnumerable<EntityEntry> entries);
    }
}
