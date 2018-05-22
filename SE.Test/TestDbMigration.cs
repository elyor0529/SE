using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE.Model;
using SE.Model.Entity;

namespace SE.Test
{
    public static class TestDbMigration
    {
        public static void Seed(StorageDbContext context)
        {
            var listCountry = new List<SearchProvider>
            {
                new SearchProvider {Id = 1, Name = "Google"},
                new SearchProvider {Id = 2, Name = "Bing"},
                new SearchProvider {Id = 3, Name = "Yandex"}
            };
            context.Providers.AddRange(listCountry);
            context.SaveChanges();
        }
    }
}
