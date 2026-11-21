/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using Assignment11_MI4090.Mediator;

namespace Assignment11_MI4090.Observer;

public sealed class EmergencyBridgeObserver : IAlertObserver
{
    private readonly IEmergencyMediator mediator;

    public EmergencyBridgeObserver(IEmergencyMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public void Update(AlertEvent alertEvent)
    {
        if (alertEvent.Severity == "CRITICAL")
        {
            mediator.Notify(this, "FIRE_DETECTED");
        }
    }
}
