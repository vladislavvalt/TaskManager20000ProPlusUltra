//-----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TaskManager20000ProPlusUltra.Models;

    /// <summary>
    /// Represents project manager
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Gets or sets the manager's unique id
        /// </summary>
        ///
        [Key]
        public string ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the list of teams assigned to the manager
        /// </summary>
        public virtual List<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the list of manager's current projects
        /// </summary>
        public virtual List<Project> Projects { get; set; }
    }
}