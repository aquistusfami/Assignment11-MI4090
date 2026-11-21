/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Mediator;

public sealed class Alarm
{
    private IEmergencyMediator? mediator;

    public void SetMediator(IEmergencyMediator mediator)
    {
        this.mediator = mediator;
    }

    public void Trigger()
    {
        Console.WriteLine("[ALARM] Siren activated!");
        mediator?.Notify(this, "ALARM_ON");
    }

    public void Reset()
    {
        Console.WriteLine("[ALARM] Siren turned off.");
        mediator?.Notify(this, "ALARM_OFF");
    }
}
