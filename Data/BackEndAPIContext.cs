using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.API.Models;
using FrontEnd.Webclient.Models;

namespace BackEnd.API.Data
{
    public class BackEndAPIContext : DbContext
    {
        public BackEndAPIContext (DbContextOptions<BackEndAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BackEnd.API.Models.Oferentes> Oferentes { get; set; } = default!;

        public DbSet<BackEnd.API.Models.Concursante>? Concursante { get; set; }

        public DbSet<BackEnd.API.Models.Concurso>? Concurso { get; set; }

        public DbSet<FrontEnd.Webclient.Models.Titulos>? Titulos { get; set; }

        public DbSet<FrontEnd.Webclient.Models.Experiencia>? Experiencia { get; set; }
    }
}
