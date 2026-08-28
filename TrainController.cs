using System;

public class TrainController
{
    public float Speed = 0f;
    public float Acceleration = 0f;

    public bool DoorsOpen = false;
    public bool LightsOn = false;

    public void StartTrain()
    {
        Console.WriteLine("A szerelvény elindult.");
    }
}
