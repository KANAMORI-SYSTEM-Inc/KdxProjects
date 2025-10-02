using Kdx.Contracts.DTOs;
using Kdx.Contracts.Interfaces;
using Kdx.Core.Application;

namespace Kdx.Infrastructure.Services
{
    /// <summary>
    /// プロセスフロー図の構築と管理を行うサービスの実装
    /// </summary>
    public class ProcessFlowService : IProcessFlowService
    {
        private readonly IAccessRepository _repository;

        public ProcessFlowService(IAccessRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<ProcessDetail> GetProcessDetailsByCycle(int cycleId)
        {
            var allProcessDetails = _repository.GetProcessDetails();
            var processes = _repository.GetProcesses();

            return allProcessDetails
                .Where(pd => processes.Any(p => p.Id == pd.ProcessId && p.CycleId == cycleId))
                .ToList();
        }

        public List<ProcessDetailConnection> GetConnections(int cycleId)
        {
            return _repository.GetProcessDetailConnections(cycleId);
        }

        public List<ProcessDetailFinish> GetFinishConditions(int cycleId)
        {
            return _repository.GetProcessDetailFinishes(cycleId);
        }

        public List<ProcessStartCondition> GetStartConditions(int cycleId)
        {
            return _repository.GetProcessStartConditions(cycleId);
        }

        public List<ProcessFinishCondition> GetProcessFinishConditions(int cycleId)
        {
            return _repository.GetProcessFinishConditions(cycleId);
        }

        public void AddConnection(ProcessDetailConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            _repository.AddProcessDetailConnection(connection);
        }

        public void DeleteConnection(int connectionId)
        {
            if (connectionId <= 0)
                throw new ArgumentException("無効な接続IDです", nameof(connectionId));

            _repository.DeleteProcessDetailConnection(connectionId);
        }

        public void AddFinishCondition(ProcessDetailFinish finish)
        {
            if (finish == null)
                throw new ArgumentNullException(nameof(finish));

            _repository.AddProcessDetailFinish(finish);
        }

        public void DeleteFinishCondition(int finishId)
        {
            if (finishId <= 0)
                throw new ArgumentException("無効な終了条件IDです", nameof(finishId));

            _repository.DeleteProcessDetailFinish(finishId);
        }

        public bool ValidateConnection(int fromId, int toId)
        {
            if (fromId <= 0 || toId <= 0)
                return false;

            if (fromId == toId)
                return false;

            return true;
        }

        public bool HasCircularReference(int fromId, int toId, int cycleId)
        {
            var connections = GetConnections(cycleId);
            var visited = new HashSet<int>();

            return HasCircularReferenceRecursive(toId, fromId, connections, visited);
        }

        /// <summary>
        /// 循環参照を再帰的にチェック
        /// </summary>
        private bool HasCircularReferenceRecursive(int currentId, int targetId, List<ProcessDetailConnection> connections, HashSet<int> visited)
        {
            if (visited.Contains(currentId))
                return false;

            visited.Add(currentId);

            var outgoingConnections = connections.Where(c => c.FromProcessDetailId == currentId);

            foreach (var connection in outgoingConnections)
            {
                if (!connection.ToProcessDetailId.HasValue)
                    continue;

                if (connection.ToProcessDetailId.Value == targetId)
                    return true;

                if (HasCircularReferenceRecursive(connection.ToProcessDetailId.Value, targetId, connections, visited))
                    return true;
            }

            return false;
        }
    }
}
