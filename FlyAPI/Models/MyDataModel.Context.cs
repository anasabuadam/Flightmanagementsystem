﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlyAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FlightManagementSystemEntities : DbContext
    {
        public FlightManagementSystemEntities()
            : base("name=FlightManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adminstrator> Adminstrators { get; set; }
        public virtual DbSet<Airline_Companies> Airline_Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User_Roles> User_Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
