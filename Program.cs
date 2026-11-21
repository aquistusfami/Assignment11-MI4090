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
            var legacy = new LegacySmokerDetector(735);
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
            var legacy = new LegacySmokerDetector(0);
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
            var legacy = new LegacySmokerDetector(0);
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
            Console.WriteLine("T3: Phat canh bao Warning, khong co Mediator => PASSED");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.WriteLine();
        // tc4
        try
        {
            var legacy = new LegacySmokerDetector(0);
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
    }
}
