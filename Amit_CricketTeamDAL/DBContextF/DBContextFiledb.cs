using Amit_CricketTeamDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamDAL.DBContextF
{
    public class DBContextFiledb : DbContext
    {
        public DBContextFiledb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CricketTeamMaster> CricketTeamMasters { get; set; }

    }
}
