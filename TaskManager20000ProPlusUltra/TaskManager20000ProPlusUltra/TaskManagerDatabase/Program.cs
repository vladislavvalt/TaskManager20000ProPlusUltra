//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Primat NaUKMA">
//     Primat NaUKMA Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A simple test class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Method arguments</param>
        //public static void Main(string[] args)
        //{
        //    using (var db = new CompanyContext())
        //    {
        //        PopulateDatabase(db);

        //        var clients = from c in db.Clients
        //                      orderby c.Name
        //                      select c;

        //        Console.WriteLine("Clients:");
        //        foreach (var c in clients)
        //        {
        //            Console.WriteLine(" {0}. {1}, {2}, {3}", c.ClientId, c.Name, c.Description, c.Email);
        //        }

        //        var managers = from m in db.Managers
        //                       orderby m.Name
        //                       select m;

        //        Console.WriteLine("Managers:");
        //        foreach (var m in managers)
        //        {
        //            Console.WriteLine(" {0}. {1}, {2}, {3}", m.ManagerId, m.Name, m.Description, m.Email);
        //            foreach (var t in m.Teams)
        //            {
        //                Console.WriteLine("     {0}", t.TeamId);
        //            }
        //        }

        //        var employees = from e in db.Employees
        //            orderby e.Name
        //            select e;

        //        Console.WriteLine("Employees:");
        //        foreach (var e in employees)
        //        {
        //            Console.WriteLine("{0}. {1}, {2}, {3}", e.EmployeeId, e.Name, e.Description, e.Email);
        //        }

        //        var teams = from t in db.Teams
        //            orderby t.Manager.Name
        //            select t;

        //        Console.WriteLine("Teams:");
        //        foreach (var t in teams)
        //        {
        //            Console.WriteLine(" {0}. {1}", t.TeamId, t.Manager.Name);
        //            foreach (var m in t.Members)
        //            {
        //                Console.WriteLine("     {0}", m.Name);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Removes all entries from the database context
        ///// </summary>
        ///// <param name="db">Database context</param>
        //private static void ClearDatabase(CompanyContext db)
        //{
        //    db.Tasks.RemoveRange(db.Tasks);
        //    db.Projects.RemoveRange(db.Projects);
        //    db.Teams.RemoveRange(db.Teams);
        //    db.Employees.RemoveRange(db.Employees);
        //    db.Managers.RemoveRange(db.Managers);
        //    db.Clients.RemoveRange(db.Clients);
        //}

        ///// <summary>
        ///// Populates the database with test entries
        ///// </summary>
        ///// <param name="db">Database context</param>
        //private static void PopulateDatabase(CompanyContext db)
        //{
        //    ClearDatabase(db);

        //    var client1 = new Client { Name = "ClientFoo", Description = "Foo", Email = "Client@Foo" };
        //    var client2 = new Client { Name = "ClientBar", Description = "Bar", Email = "Client@Bar" };

        //    var manager1 = new Manager { Name = "ManagerFoo", Description = "Foo", Email = "Manager@Foo" };
        //    var manager2 = new Manager { Name = "ManagerBar", Description = "Bar", Email = "Manager@Bar" };

        //    var employee1 = new Employee { Name = "EmployeeFoo", Description = "Foo", Email = "Employee@Foo" };
        //    var employee2 = new Employee { Name = "EmployeeBar", Description = "Bar", Email = "Employee@Bar" };
        //    var employee3 = new Employee { Name = "EmployeeBoo", Description = "Boo", Email = "Employee@Boo" };

        //    var team1 = new Team
        //    {
        //        Manager = manager1,
        //        Members = new List<Employee> { employee1, employee2 }
        //    };

        //    var team2 = new Team
        //    {
        //        Manager = manager2,
        //        Members = new List<Employee> { employee2, employee3 }
        //    };

        //    manager1.Teams = new List<Team> { team1 };
        //    manager2.Teams = new List<Team> { team2 };

        //    db.Clients.Add(client1);
        //    db.Clients.Add(client2);

        //    db.Managers.Add(manager1);
        //    db.Managers.Add(manager2);

        //    db.Employees.Add(employee1);
        //    db.Employees.Add(employee2);
        //    db.Employees.Add(employee3);

        //    db.Teams.Add(team1);
        //    db.Teams.Add(team2);

        //    db.SaveChanges();
        //}
    }
}
