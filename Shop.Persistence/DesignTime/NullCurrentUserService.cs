using Shop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.DesignTime
{
    public class NullCurrentUserService : ICurrentUserService
    {
        //public string? UserId => "Migration";
        public string? UserId => null;
    }
}
