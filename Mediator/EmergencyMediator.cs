/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Mediator;

public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController door;
    private readonly VentilationController ventilation;

    public EmergencyMediator(
        Alarm alarm,
        DoorController door,
        VentilationController ventilation)
    {
        this.alarm = alarm ?? throw new ArgumentNullException(nameof(alarm));
        this.door = door ?? throw new ArgumentNullException(nameof(door));
        this.ventilation = ventilation ?? throw new ArgumentNullException(nameof(ventilation));

        this.alarm.SetMediator(this);
        this.door.SetMediator(this);
        this.ventilation.SetMediator(this);
    }

    public void Notify(object sender, string eventCode)
    {
        switch (eventCode)
        {
            case "FIRE_DETECTED":
                Console.WriteLine("[MEDIATOR] FIRE_DETECTED -> activating emergency protocol.");
                alarm.Trigger();
                door.UnlockAll();
                ventilation.Shutdown();
                break;
        }
    }
}
