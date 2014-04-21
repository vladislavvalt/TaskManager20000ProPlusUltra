//-----------------------------------------------------------------------
// <copyright file="Project.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a project detailed in agreement between a client and a manager
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the project's unique id
        /// </summary>
        [Key]
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the project's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the project's status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the client's unique id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Gets or sets the manager's unique id
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the manager of the project
        /// </summary>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Gets or sets the team's unique id
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        /// Gets or sets the team the project is assigned to
        /// </summary>
        public virtual Team Team { get; set; }

        /// <summary>
        /// Gets or sets the list of tasks the projects consists of
        /// </summary>
        public virtual List<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the project's deadline
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the project's start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the project's end date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}