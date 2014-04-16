//-----------------------------------------------------------------------
// <copyright file="Team.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a team of employees working on the same set of projects
    /// </summary>
    public class Team
    {
        /// <summary>
        ///  Gets or sets the team's unique id
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the id of the team's manager
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the team's manager
        /// </summary>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Gets or sets the list of team members
        /// </summary>
        public virtual List<Employee> Members { get; set; }

        /// <summary>
        /// Gets or sets the list of current projects
        /// </summary>
        public virtual List<Project> CurrentProjects { get; set; }

        /// <summary>
        /// Gets or sets the list of completed projects
        /// </summary>
        public virtual List<Project> CompletedProjects { get; set; }
    }
}
