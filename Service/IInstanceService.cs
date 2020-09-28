using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IInstanceService {
        Task<List<Instance>> GetInstances();
    }
}