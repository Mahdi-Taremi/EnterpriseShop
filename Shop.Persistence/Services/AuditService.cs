using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Application.Common.Interfaces.Services;
using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Services
{
    public sealed class AuditService : IAuditService
    {
        private readonly IDateTimeProvider _dateTime;
        private readonly ICurrentUserService _currentUser;
        public AuditService(
            IDateTimeProvider dateTime,
            ICurrentUserService currentUser)
        {
            _dateTime = dateTime;
            _currentUser = currentUser;
        }
        public void ApplyAuditInformation(
            IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                if (entry.Entity is not BaseSoftDeleteEntity entity)
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:

                        entity.CreatedAt = _dateTime.UtcNow;
                        entity.CreatedBy = _currentUser.UserId;
                        break;

                    case EntityState.Modified:

                        entity.LastModifiedAt = _dateTime.UtcNow;
                        entity.LastModifiedBy = _currentUser.UserId;
                        break;

                    case EntityState.Deleted:

                        entry.State = EntityState.Modified;

                        entity.IsDeleted = true;

                        entity.DeletedAt = _dateTime.UtcNow;

                        entity.DeletedBy = _currentUser.UserId;

                        break;
                }
            }
        }
    }
}
