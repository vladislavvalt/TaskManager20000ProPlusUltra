using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager20000ProPlusUltra.Domain
{
    public class TurboEmployee : TurboUser
    {
        public List<TurboTask> CurrentTasks { get; set; }
        public List<TurboTask> CompletedTasks { get; set; }
    }
}