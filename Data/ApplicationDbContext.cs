using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using peru_fails.Models;

namespace peru_fails.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Fail> Fails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
