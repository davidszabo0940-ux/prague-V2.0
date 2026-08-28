using UnityEngine;

public class MetroTrain : MonoBehaviour
{
    [Header("Train")]
    public float speed = 0f;
    public float position = 0f;

    [Header("Controls")]
    [Range(0, 5)]
    public int powerLevel = 0;

    [Range(0, 5)]
    public int brakeLevel = 0;

    [Header("Physics")]
    public float acceleration = 0.8f;
    public float brakingForce = 1.2f;
    public float maxSpeed = 22f;

    private void Update()
    {
        UpdateTrainPhysics();
    }

    private void UpdateTrainPhysics()
    {
        float power = powerLevel * acceleration;
        float brake = brakeLevel * brakingForce;

        float accelerationResult = power - brake;

        speed += accelerationResult * Time.deltaTime;

        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        position += speed * Time.deltaTime;
    }
}
