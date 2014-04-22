using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class ManagerService : Service<Manager>
    {
        public Service<Employee> employee;
        public Service<Project> project;
        public Service<Team> team;

        public ManagerService(CompanyContext context)
            : base(context)
        {
        }

        public void CreateProject(Project proj, String managerId)
        {
            proj.ManagerId = managerId;
            project.Insert(proj);
            //Manager m = GetByID(managerId);
            // m.Projects.Add(proj);
            // Update(m);
        }

        public void CreateTeam(List<Employee> employees, String managerId, List<Project> projects = null)
        {
            var t = new Team
            {
                ManagerId = managerId,
                Manager = GetByID(managerId),
                Employees = employees,
                Projects = projects
            };

            team.Insert(t);
        }

        public void CreateTaskInProject(Task task, String projectId)
        {
            Project proj = project.GetByID(projectId);
            CreateTaskInProject(task, proj);
        }

        public void CreateTaskInProject(Task task, Project proj)
        {
            proj.Tasks.Add(task);
            project.Update(proj);
        }

        public List<Project> GetCompletedProjects(String managerId)
        {
            List<Project> listToReturn = new List<Project>();
            var queryCompletedProjects = from proj in project.Get()
                                         where proj.ManagerId == managerId && proj.EndDate < DateTime.Now
                                         select proj;
            foreach (Project p in queryCompletedProjects)
            {
                listToReturn.Add(p);
            }
            return listToReturn;
        }

        public List<Project> GetCurrentProjects(String managerId)
        {
            List<Project> listToReturn = new List<Project>();
            var queryCompletedProjects = from proj in project.Get()
                                         where proj.ManagerId == managerId && proj.EndDate > DateTime.Now
                                         select proj;
            foreach (Project p in queryCompletedProjects)
            {
                listToReturn.Add(p);
            }
            return listToReturn;
        }

        public List<Project> GetAllProjects(String managerId)
        {
            List<Project> listToReturn = new List<Project>();
            var queryCompletedProjects = from proj in project.Get()
                                         where proj.ManagerId == managerId
                                         select proj;
            foreach (Project p in queryCompletedProjects)
            {
                listToReturn.Add(p);
            }
            return listToReturn;
        }

        public List<Task> GetCProjectTasks(String projectId)
        {
            return project.GetByID(projectId).Tasks;
        }

        public List<Task> GetCProjectsTasks(List<Project> projects)
        {
            List<Task> toReturn = new List<Task>();
            foreach (Project proj in projects)
            {
                toReturn.AddRange(proj.Tasks);
            }
            return toReturn;
        }

        public void ChangeProjectDeadline(Project proj, DateTime deadLine, String managerID)
        {
            if (proj.ManagerId == managerID)
            {
                proj.Deadline = deadLine;
                project.Update(proj);
            }
        }

        public void ChangeProjectDeadline(String projId, DateTime deadLine, String managerID)
        {
            ChangeProjectDeadline(project.GetByID(projId), deadLine, managerID);
        }
    }
}