/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Mediator;

public sealed class VentilationController
{
    private IEmergencyMediator? mediator;

    public void SetMediator(IEmergencyMediator mediator)
    {
        this.mediator = mediator;
    }

    public void Shutdown()
    {
        Console.WriteLine("[VENTILATION] System shut down to prevent smoke spread");
        mediator?.Notify(this, "VENTILATION_OFF");
    }

    public void Start()
    {
        Console.WriteLine("[VENTILATION] System running");
        mediator?.Notify(this, "VENTILATION_ON");
    }
}
