//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="Primat NaUKMA">
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
    /// Represents user of the service
    /// </summary>
    public class Client
    {
        [Key]
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the list of client's contracts
        /// </summary>
        public List<Project> Projects { get; set; }
    }
}