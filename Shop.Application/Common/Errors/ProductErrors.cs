using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Common.Results;

namespace Shop.Application.Common.Errors
{
    public static class ProductErrors
    {
        public static readonly Error NotFound =
            new(
                "Products.NotFound",
                "Product was not found.");

        public static readonly Error DuplicateName =
            new(
                "Products.DuplicateName",
                "Product name already exists.");
    }
}
