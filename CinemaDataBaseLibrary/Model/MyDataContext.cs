using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServerCompact;

namespace CinemaDataBaseLibrary.Model
{
    public class MyDataContext : DbContext
    {
        public MyDataContext() : base("DataBase")
        {

        }

        public DbSet<CinemaRoom> Rooms { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
