using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Parcours_management.Domain.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Parcours_management.Data;

public class ApplicationDbContext : DbContext
{


    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //{
    //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    //}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Parcour> Parcourslist { get; set; }
    

   

}
