/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Observer;

public sealed class AuditLogObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[AUDIT LOG] {alertEvent.OccurredAt:yyyy-MM-dd HH:mm:ss} | " +
            $"Sensor={alertEvent.SensorName} | " +
            $"Value={alertEvent.Value:F1}{alertEvent.Unit} | " +
            $"Severity={alertEvent.Severity}"
        );
    }
}
