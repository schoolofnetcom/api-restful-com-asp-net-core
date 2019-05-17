using System;
using System.Collections.Generic;
using System.Text;
using api_rest.Models;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Produto> Produtos {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

    }
}