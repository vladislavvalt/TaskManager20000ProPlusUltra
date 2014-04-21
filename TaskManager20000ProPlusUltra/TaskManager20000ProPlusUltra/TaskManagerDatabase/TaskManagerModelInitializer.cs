using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager20000ProPlusUltra.Models;

using Microsoft.AspNet.Identity;

namespace TaskManager20000ProPlusUltra.TaskManagerDatabase
{
    public class TaskManagerModelInitializer:DropCreateDatabaseAlways<CompanyContext>//DropCreateDatabaseIfModelChanges<CompanyContext>
    {

        public static UserManager<ApplicationUser> UserManager { get; private set; }

        public static string Password = "1111";

        public static string Stamp = "";

        public static UserStore<ApplicationUser> Store = null;


        public static List<Employee> employees = null;

        public static List<Task> tasks = null;

        protected override void Seed(CompanyContext context)
        {
 	        base.Seed(context);
            Store = new UserStore<ApplicationUser>(context);
            UserManager = new UserManager<ApplicationUser>(Store);
            String newPassword = "test@123";
            String hashedNewPassword = UserManager.PasswordHasher.HashPassword(newPassword);
            Password = hashedNewPassword;

            Store.Dispose();
            UserManager.Dispose();

            GetClients().ForEach(c => context.Clients.Add(c));
            GetEmployees().ForEach(c => context.Employees.Add(c));
            GetManagers().ForEach(c => context.Managers.Add(c));
            GetTeams().ForEach(c => context.Teams.Add(c));
            GetTasks().ForEach(c => context.Tasks.Add(c));
            GetProjects().ForEach(c => context.Projects.Add(c));          
        }


        //TODO write tasks to employees
        //TODO write projects and tasks end teams to manager ... etc

        private static List<Employee> GetEmployees()
        {
            employees = new List<Employee>{
                new Employee{
                    EmployeeId = "1",
                    User = new ApplicationUser{
                        Id = "1",
                        UserName = "Anastasiya",
                        FirstName = "Anastasiya",
                        LastName = "Bushkova",
                        PasswordHash = Password,
                        SecurityStamp = "41fererg",
                        PhoneNumber = "+380631234567",
                        Email = "bushkova@taskturbo.com",
                        EmailConfirmed = true,
                        Description = "starosta client"   
                    }
                },
                new Employee{
                    EmployeeId = "4",
                    User = new ApplicationUser{
                        Id = "4",
                        UserName = "Olena",
                        FirstName = "Olena",
                        LastName = "Sokolova",
                        PasswordHash = Password,
                        SecurityStamp = "41fererg",
                        PhoneNumber = "+380631234567",
                        Email = "superlenka@taskturbo.com",
                        EmailConfirmed = true,
                        Description = "Employee"
                    }
                }
            };

            return employees;
        }


        private static List<Manager> GetManagers()
        {
            var managers = new List<Manager>
            {
                new Manager{
                    ManagerId = "2",
                    User = new ApplicationUser{
                        Id = "2",
                        UserName = "Vladislav",
                        FirstName = "Vladislav",
                        LastName = "Valt",
                        PasswordHash = Password,
                        SecurityStamp = "41fererg",
                        PhoneNumber = "+380631234567",
                        Email = "vladislav.valt@taskturbo.com",
                        EmailConfirmed = true,
                        Description = "superprogramer manager"
                    }
                }  
            };
            return managers;
        }


        private static List<Client> GetClients()
        {
            var clients = new List<Client>{
                new Client{
                    ClientId = "3",
                    User = new ApplicationUser{
                        Id = "3",
                        UserName = "Danilo",
                        FirstName = "Danilo",
                        LastName = "Fitel",
                        PasswordHash = Password,
                        SecurityStamp = "41fererg",
                        PhoneNumber = "+380631234567",
                        Email = "den@taskturbo.com",
                        EmailConfirmed = true,
                        Description = "Client",
                    }
                }
            };
            
            return clients;
        }

        private static List<Team> GetTeams()
        {
            var teams = new List<Team>
            {
                new Team{
                    TeamId = "1",
                    ManagerId = "2",
                    Employees = employees
                }
            };
            return teams;
        }


        private static List<Task> GetTasks()
        {
            tasks = new List<Task>
            {
                new Task{
                    TaskId = "1",
                    Name = "Be starosta!",
                    Description = "Bla bla",
                    Status = "OPENED",
                    Deadline = new DateTime(2014, 05, 25),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.MaxValue,
                    EmployeeId = "1"
                },
                new Task{
                    TaskId = "2",
                    Name = "Write some ASP.NET Controller!",
                    Description = "Bla bla",
                    Status = "CLOSED",
                    Deadline = new DateTime(2014, 05, 25),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.MaxValue,
                    EmployeeId = "1"
                },
                new Task{
                    TaskId = "3",
                    Name = "Do practice number 4",
                    Description = "Bla bla",
                    Status = "OPENED",
                    Deadline = new DateTime(2014, 05, 25),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.MaxValue,
                    EmployeeId = "4"
                },
            };
            return tasks;
        }


        // TODO set project
        private static List<Project> GetProjects()
        {
            var projects = new List<Project>
            {
                new Project{
                    ProjectId = "1",
                    ClientId = "3",
                    ManagerId = "2",
                    TeamId = "1",
                    Tasks = tasks,
                    Name = "TaskTurboPlus",
                    Status = "OPENED",
                    Description = "Cool Stuff!",
                    Deadline = new DateTime(2014, 05, 28),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.MaxValue,
                }
            };
            return projects;
        }       

    }
}