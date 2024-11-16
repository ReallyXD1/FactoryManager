using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryManager.Desktop.ViewModels
{
    public class PlanningViewModel : ViewModelBase
    {
        private readonly IPlanningService _planningService;
        private readonly IProductionService _productionService;

        private PlanningTask _selectedTask;
        private Resource _selectedResource;
        private DateTime _selectedDate;
        private bool _isLoading;

        public PlanningTask SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (SetProperty(ref _selectedTask, value))
                {
                    LoadTaskDetails();
                }
            }
        }

        public Resource SelectedResource
        {
            get => _selectedResource;
            set
            {
                if (SetProperty(ref _selectedResource, value))
                {
                    LoadResourceSchedule();
                }
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (SetProperty(ref _selectedDate, value))
                {
                    RefreshScheduleCommand.Execute(null);
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ObservableCollection<PlanningTask> Tasks { get; } = new();
        public ObservableCollection<Resource> Resources { get; } = new();
        public ObservableCollection<ScheduleEvent> Schedule { get; } = new();
        public ObservableCollection<PlanningConflict> Conflicts { get; } = new();

        public ICommand RefreshScheduleCommand { get; }
        public ICommand CreateTaskCommand { get; }
        public ICommand OptimizeScheduleCommand { get; }
        public ICommand ResolveConflictCommand { get; }
        public ICommand GenerateReportCommand { get; }

        public PlanningViewModel(
            IPlanningService planningService,
            IProductionService productionService)
        {
            _planningService = planningService;
            _productionService = productionService;
            _selectedDate = DateTime.Today;

            RefreshScheduleCommand = new RelayCommand(async _ => await RefreshSchedule());
            CreateTaskCommand = new RelayCommand(async _ => await CreateTask());
            OptimizeScheduleCommand = new RelayCommand(async _ => await OptimizeSchedule());
            ResolveConflictCommand = new RelayCommand(async _ => await ResolveConflict(), CanResolveConflict);
            GenerateReportCommand = new RelayCommand(async _ => await GenerateReport());

            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadResources();
            await RefreshSchedule();
            await CheckConflicts();
        }

        private async Task LoadResources()
        {
            try
            {
                var resources = await _planningService.GetResourcesAsync();
                Resources.Clear();
                foreach (var resource in resources)
                {
                    Resources.Add(resource);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading resources: {ex.Message}");
            }
        }

        private async Task RefreshSchedule()
        {
            IsLoading = true;
            try
            {
                var schedule = await _planningService.GetScheduleAsync(SelectedDate);
                Schedule.Clear();
                foreach (var evt in schedule)
                {
                    Schedule.Add(evt);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing schedule: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task CheckConflicts()
        {
            try
            {
                var conflicts = await _planningService.CheckConflictsAsync(SelectedDate);
                Conflicts.Clear();
                foreach (var conflict in conflicts)
                {
                    Conflicts.Add(conflict);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error checking conflicts: {ex.Message}");
            }
        }

        private async void LoadTaskDetails()
        {
            if (SelectedTask == null) return;

            try
            {
                var details = await _planningService.GetTaskDetailsAsync(SelectedTask.Id);
                // Aktualizacja szczegółów zadania
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading task details: {ex.Message}");
            }
        }

        private async void LoadResourceSchedule()
        {
            if (SelectedResource == null) return;

            try
            {
                var schedule = await _planningService.GetResourceScheduleAsync(SelectedResource.Id, SelectedDate);
                Schedule.Clear();
                foreach (var evt in schedule)
                {
                    Schedule.Add(evt);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading resource schedule: {ex.Message}");
            }
        }

        private async Task CreateTask()
        {
            // Implementacja tworzenia nowego zadania
        }

        private async Task OptimizeSchedule()
        {
            IsLoading = true;
            try
            {
                await _planningService.OptimizeScheduleAsync(SelectedDate);
                await RefreshSchedule();
                await CheckConflicts();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error optimizing schedule: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ResolveConflict()
        {
            // Implementacja rozwiązywania konfliktów
        }

        private bool CanResolveConflict(object parameter)
        {
            return Conflicts.Count > 0;
        }

        private async Task GenerateReport()
        {
            // Implementacja generowania raportu
        }
    }

    public class PlanningTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
    }

    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public double Capacity { get; set; }
    }

    public class ScheduleEvent
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class PlanningConflict
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Resolution { get; set; }
    }
}
