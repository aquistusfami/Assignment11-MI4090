/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using Assignment11_MI4090.Adapter;

namespace Assignment11_MI4090;

class Program
{
    static void Main(string[] args)
    {
        var legacy = new LegacySmokerDetector(735);
        ISensor sensor = new SmokeSensorAdapter(legacy);

        Console.WriteLine(sensor.ReadValue()); // output: 73.5
        Console.WriteLine(sensor.GetUnit()); // output: % smoke
    }
}
