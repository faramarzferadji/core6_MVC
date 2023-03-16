﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_shst.Areas.Identity.Data;
using Project_shst.Models;

namespace Project_shst.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Brand> BrandAffer { get; set; }
    public DbSet<ELProducts> ELProductAffer { get; set; }
    public DbSet<ELShoppingCart2> ElShopAffer2 { get; set; }
    public DbSet<ShipBody> ShipBodyAffer { get; set; }
    public DbSet<ShipHead> ShipHeadAffer { get; set; }
    public DbSet<Pyment_method> Pyment_methodAffer { get; set; }
    public DbSet<Payment> PaymentAffer { get; set; }
    public DbSet<PaymentUser> PaymentUserAffer { get; set; }




    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(250);
        builder.Property(x => x.LastName).HasMaxLength(250);
    }
}

