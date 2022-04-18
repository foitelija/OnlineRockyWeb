using Microsoft.EntityFrameworkCore;
using OnlineRockyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRockyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // Сюда добавляем новые таблицы, после добавления: Средства - NuGet - Консоль NuGet - [add-migration {Name}] - update-database
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
