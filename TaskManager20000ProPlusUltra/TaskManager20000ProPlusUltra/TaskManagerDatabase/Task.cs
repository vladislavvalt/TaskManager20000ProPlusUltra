//-----------------------------------------------------------------------
// <copyright file="Task.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a task assigned to the team member
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the task's unique id
        /// </summary>
        [Key]
        public string TaskId { get; set; }

        /// <summary>
        ///  Gets or sets the task's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description of the task
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the task status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date of deadline
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date of completion
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets unique id of employee the task is assigned to
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee the task is assigned to
        /// </summary>
        public virtual Employee Employee { get; set; }
    }
}