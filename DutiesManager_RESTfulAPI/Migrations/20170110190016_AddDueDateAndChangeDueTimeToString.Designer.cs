using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DutiesManager_RESTfulAPI.Models;

namespace DutiesManager_RESTfulAPI.Migrations
{
    [DbContext(typeof(DutiesManagerDbContext))]
    [Migration("20170110190016_AddDueDateAndChangeDueTimeToString")]
    partial class AddDueDateAndChangeDueTimeToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DutiesManager_RESTfulAPI.Models.Duty", b =>
                {
                    b.Property<int>("DutyId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("DueTime")
                        .IsRequired();

                    b.Property<string>("DutyTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.HasKey("DutyId");

                    b.HasIndex("UserId");

                    b.ToTable("Duties");
                });

            modelBuilder.Entity("DutiesManager_RESTfulAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DutiesManager_RESTfulAPI.Models.Duty", b =>
                {
                    b.HasOne("DutiesManager_RESTfulAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
