/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Observer;

public sealed class EmailAlertObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[EMAIL] To: safety-admin@campus.edu | " +
            $"Subject: [{alertEvent.Severity}] Alert at {alertEvent.SensorName} | " +
            $"Value: {alertEvent.Value:F1}{alertEvent.Unit}"
        );
    }
}
