using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager20000ProPlusUltra.Domain
{
    public class TurboManager : TurboUser
    {
        public List<TurboProject> CurrentProjects { get; set; }
        public List<TurboProject> CompletedProjects { get; set; }

        public List<TurboTeam> CurrentTeams { get; set; }
    }
}