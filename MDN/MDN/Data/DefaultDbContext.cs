﻿using MDN.Models;
using MDN.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.Data
{
    public class DefaultDbContext : IdentityDbContext<ApplicationUser>
    {

        public DefaultDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public virtual T001_PRODUTO T001_PRODUTO { get; set; }
        public virtual T002_CATEGORIA T002_CATEGORIA { get; set; }
        public virtual T003_UF T003_UF { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
