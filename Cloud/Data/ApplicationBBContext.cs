using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cloud.Models;

public class ApplicationBBContext : DbContext
{
    public ApplicationBBContext(DbContextOptions<ApplicationBBContext> options)
        : base(options)
    {
    }

    public DbSet<History> History { get; set; } = default!;
}
