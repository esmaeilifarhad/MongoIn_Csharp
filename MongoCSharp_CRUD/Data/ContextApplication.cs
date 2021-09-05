using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoCSharp_CRUD.Models;

    public class ContextApplication : DbContext
    {
        public ContextApplication (DbContextOptions<ContextApplication> options)
            : base(options)
        {
        }

        public DbSet<MongoCSharp_CRUD.Models.Person> Person { get; set; }
    }
