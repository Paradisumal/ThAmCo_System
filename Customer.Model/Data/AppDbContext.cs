using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWebApplication.Data;

namespace Customer.Model.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

       /* public DbSet<Customer> Customers { get; set; }*/
    }
}
