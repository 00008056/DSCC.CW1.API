using DSCC.CW_1._00008056.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW_1._00008056.DbContexts
{
    public class CDAlbumContext :DbContext
    {
        //Creating a database context with 2 tables as specified below Albums and Artists
        public CDAlbumContext(DbContextOptions<CDAlbumContext> options) : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

    }
}
