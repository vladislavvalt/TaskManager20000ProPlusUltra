//-----------------------------------------------------------------------
// <copyright file="Team.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a team of employees working on the same set of projects
    /// </summary>
    public class Team
    {
        /// <summary>
        ///  Gets or sets the team's unique id
        /// </summary>
        [Key]
        public string TeamId { get; set; }

        /// <summary>
        /// Gets or sets the id of the team's manager
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the team's manager
        /// </summary>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Gets or sets the list of team members
        /// </summary>
        public virtual List<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the list of projects
        /// </summary>
        public virtual List<Project> Projects { get; set; }
    }
}