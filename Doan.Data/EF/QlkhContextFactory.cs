using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Doan.Data.EF
{
    public class QlkhContextFactory : IDesignTimeDbContextFactory<QlkhContext>
    {
        public QlkhContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("QlkhDB");

            var optionsBuilder = new DbContextOptionsBuilder<QlkhContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QlkhContext(optionsBuilder.Options);
        }
    }
}