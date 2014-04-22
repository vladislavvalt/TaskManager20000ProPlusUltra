using TaskManager20000ProPlusUltra.TaskManagerDatabase;

namespace TaskManager20000ProPlusUltra.Service
{
    public class TaskService : Service<Task>
    {
        public TaskService(CompanyContext context)
            : base(context)
        {
        }
    }
}