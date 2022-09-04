namespace WebApi.HealthCheck;

public class HealthCheckResponse
{
    public string Status { get; set; }

    public IEnumerable<HealthCheck> HealthChecks { get; set; }

    public TimeSpan Duraction { get; set; }
}