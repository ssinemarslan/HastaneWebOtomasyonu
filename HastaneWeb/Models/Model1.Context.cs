﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HastaneWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HastaneWebEntities1 : DbContext
    {
        public HastaneWebEntities1()
            : base("name=HastaneWebEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DoktorlarBilgi> DoktorlarBilgis { get; set; }
        public virtual DbSet<HastalarBilgi> HastalarBilgis { get; set; }
        public virtual DbSet<KullanicilarBilgi> KullanicilarBilgis { get; set; }
        public virtual DbSet<PolikliniklerBilgi> PolikliniklerBilgis { get; set; }
    }
}
