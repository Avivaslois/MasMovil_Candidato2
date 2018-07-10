using Catalog.Infrastructure.Models.Catalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Factories
{
    public class PhoneContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            Context context = new Context();
            return context;
        }
    }
}
