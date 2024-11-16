using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface IPlanningService
    {
        Task<IEnumerable<PlanningTask>> GetTasksAsync(DateTime date);
        Task<IEnumerable<Resource>> GetResourcesAsync();
        Task<IEnumerable<ScheduleEvent>> GetScheduleAsync(DateTime date);
        Task<IEnumerable<ScheduleEvent>> GetResourceScheduleAsync(int resourceId, DateTime date);
        Task<bool> CreateTaskAsync(PlanningTask task);
        Task<bool> UpdateTaskAsync(PlanningTask task);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<bool> OptimizeScheduleAsync(DateTime date);
        Task<IEnumerable<PlanningConflict>> CheckConflictsAsync(DateTime date);
    }
}
