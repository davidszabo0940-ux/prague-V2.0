using System;

class Program
{
    static void Main()
    {
        MetroTrain train = new MetroTrain();

        train.SetPower(5);

        for (int i = 0; i < 20; i++)
        {
            train.Update(1);

            Console.WriteLine(
                $"Rychlost: {train.Speed:F2} m/s | " +
                $"Pozice: {train.Position:F2} m"
            );
        }
    }
}
