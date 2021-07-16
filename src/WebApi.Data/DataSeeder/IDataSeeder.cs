using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.DataSeeder
{
    public interface IDataSeeder
    {
        Task SeedData();
    }
}