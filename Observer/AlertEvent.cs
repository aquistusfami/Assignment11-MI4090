/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Observer;

public sealed record AlertEvent(
    string SensorName,
    double Value,
    string Unit,
    string Severity,
    DateTime OccurredAt
);
