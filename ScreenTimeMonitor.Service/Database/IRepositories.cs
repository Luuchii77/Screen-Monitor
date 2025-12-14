using ScreenTimeMonitor.Service.Models;

namespace ScreenTimeMonitor.Service.Database
{
    /// <summary>
    /// Repository interface for AppUsageSession entities.
    /// </summary>
    public interface IAppUsageRepository
    {
        Task<int> CreateSessionAsync(AppUsageSession session);
        Task<AppUsageSession?> GetSessionByIdAsync(int id);
        Task<List<AppUsageSession>> GetSessionsByDateAsync(DateTime date);
        Task<List<AppUsageSession>> GetSessionsByAppAsync(string appName, DateTime startDate, DateTime endDate);
        Task<List<AppUsageSession>> GetActiveSessionsAsync();
        Task UpdateSessionAsync(AppUsageSession session);
        Task DeleteSessionAsync(int id);
        
        /// <summary>
        /// Gets the total accumulated time for an app across all historical sessions (excluding current session).
        /// </summary>
        Task<long> GetAppHistoricalTotalAsync(string appName);
        
        /// <summary>
        /// Gets all past sessions for an app.
        /// </summary>
        Task<List<AppUsageSession>> GetAppSessionHistoryAsync(string appName, DateTime beforeDate);
    }

    /// <summary>
    /// Repository interface for SystemMetric entities.
    /// </summary>
    public interface ISystemMetricsRepository
    {
        Task<int> CreateMetricAsync(SystemMetric metric);
        Task<SystemMetric?> GetMetricByIdAsync(int id);
        Task<List<SystemMetric>> GetMetricsByDateAsync(DateTime date);
        Task<List<SystemMetric>> GetMetricsAsync(DateTime startDate, DateTime endDate);
        Task<List<SystemMetric>> GetLatestMetricsAsync(int count);
        Task DeleteMetricsBeforeDateAsync(DateTime date);
    }

    /// <summary>
    /// Repository interface for DailyAppSummary entities.
    /// </summary>
    public interface IDailyAppSummaryRepository
    {
        Task<int> CreateSummaryAsync(DailyAppSummary summary);
        Task<DailyAppSummary?> GetSummaryAsync(string appName, DateTime date);
        Task<List<DailyAppSummary>> GetSummariesByDateAsync(DateTime date);
        Task<List<DailyAppSummary>> GetSummariesByAppAsync(string appName, int daysBack);
        Task<List<DailyAppSummary>> GetAllSummariesAsync(DateTime startDate, DateTime endDate);
        Task UpdateSummaryAsync(DailyAppSummary summary);
        Task DeleteSummaryAsync(int id);
        
        /// <summary>
        /// Aggregates app usage sessions for a date, deduplicating overlapping sessions.
        /// Merges sessions for the same app to prevent double-counting time.
        /// </summary>
        Task<List<DailyAppSummary>> AggregateDailyUsageAsync(DateTime date);
    }

    /// <summary>
    /// Repository interface for DailySystemSummary entities.
    /// </summary>
    public interface IDailySystemSummaryRepository
    {
        Task<int> CreateSummaryAsync(DailySystemSummary summary);
        Task<DailySystemSummary?> GetSummaryByDateAsync(DateTime date);
        Task<List<DailySystemSummary>> GetSummariesAsync(DateTime startDate, DateTime endDate);
        Task<DailySystemSummary?> GetLatestSummaryAsync();
        Task UpdateSummaryAsync(DailySystemSummary summary);
        Task DeleteSummaryAsync(int id);
    }
}
