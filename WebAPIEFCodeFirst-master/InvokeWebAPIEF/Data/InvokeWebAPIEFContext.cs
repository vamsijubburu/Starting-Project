﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvokeWebAPIEF.Model;

namespace InvokeWebAPIEF.Data
{
    public class InvokeWebAPIEFContext : DbContext
    {
        public InvokeWebAPIEFContext (DbContextOptions<InvokeWebAPIEFContext> options)
            : base(options)
        {
        }

        public DbSet<InvokeWebAPIEF.Model.Crypto> Crypto { get; set; }
    }
}
