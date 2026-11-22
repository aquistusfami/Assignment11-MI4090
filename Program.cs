/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using Assignment11_MI4090.Adapter;
using Assignment11_MI4090.Observer;
using Assignment11_MI4090.Mediator;
namespace Assignment11_MI4090;

class Program
{
    static void Main(string[] args)
    {
        // tc1
        try
        {
            var legacy = new LegacySmokeDetector(735);
            ISensor sensor = new SmokeSensorAdapter(legacy);

            Console.WriteLine(sensor.ReadValue()); // output: 73.5
            Console.WriteLine(sensor.GetUnit()); // output: % smoke
            Console.WriteLine("T1: In ra 73.5 va % smoke => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc2
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();
            monitor.Attach(new DashboardObserver());
            monitor.Attach(new EmailAlertObserver());
            monitor.Attach(new AuditLogObserver());

            foreach (int level in new[] { 300, 499 })
            {
                legacy.SetSmokeLevel(level);
                monitor.CheckSensor("D3-102", sensor);
                Console.WriteLine($"[~] Checked level {sensor.ReadValue()}{sensor.GetUnit()}");
            }
            Console.WriteLine("T2: Khong phat canh bao => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc3
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();
            monitor.Attach(new DashboardObserver());
            monitor.Attach(new EmailAlertObserver());
            monitor.Attach(new AuditLogObserver());
            var mediator = new EmergencyMediator(new Alarm(), new DoorController(), new VentilationController());
            monitor.Attach(new EmergencyBridgeObserver(mediator));
            foreach (int level in new[] { 500, 699 })
            {
                legacy.SetSmokeLevel(level);
                monitor.CheckSensor("D3-102", sensor);
                Console.WriteLine($"[~] Checked level {sensor.ReadValue()}{sensor.GetUnit()}");
            }
            Console.WriteLine("T3: Phat canh bao Warning, Mediator khong kich hoat => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc4
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();
            monitor.Attach(new DashboardObserver());
            monitor.Attach(new EmailAlertObserver());
            monitor.Attach(new AuditLogObserver());
            var mediator = new EmergencyMediator(new Alarm(), new DoorController(), new VentilationController());
            monitor.Attach(new EmergencyBridgeObserver(mediator));
            legacy.SetSmokeLevel(700);
            monitor.CheckSensor("D3-102", sensor);
            Console.WriteLine($"[~] Checked level {sensor.ReadValue()}{sensor.GetUnit()}");

            Console.WriteLine("T4: Phat canh bao Critical => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc5
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();
            var dashboard = new DashboardObserver();
            monitor.Attach(dashboard);
            monitor.Attach(dashboard);
            monitor.Attach(new EmailAlertObserver());
            monitor.Attach(new AuditLogObserver());
            var mediator = new EmergencyMediator(new Alarm(), new DoorController(), new VentilationController());
            monitor.Attach(new EmergencyBridgeObserver(mediator));
            legacy.SetSmokeLevel(600);
            monitor.CheckSensor("D3-102", sensor);
            // Console.WriteLine($"[~] Checked level {sensor.ReadValue()}{sensor.GetUnit()}");

            Console.WriteLine("T5: Observer chi nhan canh bao 1 lan => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc6
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();
            var dashboard = new DashboardObserver();
            monitor.Attach(dashboard);
            monitor.Attach(new EmailAlertObserver());
            monitor.Attach(new AuditLogObserver());
            legacy.SetSmokeLevel(600);
            Console.WriteLine("[~] Truoc detach");
            monitor.CheckSensor("D3-102", sensor);
            // Console.WriteLine($"[~] Checked level {sensor.ReadValue()}{sensor.GetUnit()}");
            monitor.Detach(dashboard);
            Console.WriteLine("[~] Sau detach");
            monitor.CheckSensor("D3-102", sensor);
            Console.WriteLine("T6: Detach hoat dong => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc7
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();

            IAlertObserver? self = null;
            self = new ActionObserver(e =>
            {
                Console.WriteLine("[SELF-DETACH] Nhan canh bao, tu go khoi monitor");
                monitor.Detach(self!);
            });
            monitor.Attach(self);
            monitor.Attach(new DashboardObserver());

            legacy.SetSmokeLevel(600);
            Console.WriteLine("[~] Lan 1");
            monitor.CheckSensor("D3-102", sensor);
            Console.WriteLine("[~] Lan 2");
            monitor.CheckSensor("D3-102", sensor);
            Console.WriteLine("T7: Vong lap khong loi khi observer tu go chinh no => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc8
        try
        {
            var legacy = new LegacySmokeDetector(0);
            ISensor sensor = new SmokeSensorAdapter(legacy);
            var monitor = new SensorMonitor();
            monitor.Attach(new ActionObserver(e => throw new InvalidOperationException("Observer gia lap loi")));
            monitor.Attach(new DashboardObserver());

            legacy.SetSmokeLevel(600);
            monitor.CheckSensor("D3-102", sensor);
            Console.WriteLine("T8: Observer nem ngoai le, cac observer khac van ok => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
sealed class ActionObserver : IAlertObserver
{
    private readonly Action<AlertEvent> action;
    public ActionObserver(Action<AlertEvent> action) => this.action = action;
    public void Update(AlertEvent alertEvent) => action(alertEvent);
}
