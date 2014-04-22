//-----------------------------------------------------------------------
// <copyright file="CompanyContext.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TaskManager20000ProPlusUltra.Models;

    /// <summary>
    /// The management company context
    /// </summary>
    public class CompanyContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the Clients collection
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Gets or sets the Managers collection
        /// </summary>
        public DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Gets or sets the Employees collection
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the Teams collection
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the Projects collection
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the Tasks collection
        /// </summary>
        public DbSet<Task> Tasks { get; set; }
    }
}