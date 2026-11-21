/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
namespace Assignment11_MI4090.Mediator;

public sealed class DoorController
{
    private IEmergencyMediator? mediator;

    public void SetMediator(IEmergencyMediator mediator)
    {
        this.mediator = mediator;
    }

    public void UnlockAll()
    {
        Console.WriteLine("[DOOR] Emergency exits unlocked");
        mediator?.Notify(this, "DOORS_UNLOCKED");
    }
    public void LockAll()
    {
        Console.WriteLine("[DOOR] Doors locked");
        mediator?.Notify(this, "DOORS_LOCKED");
    }
}
