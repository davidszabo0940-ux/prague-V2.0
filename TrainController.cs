using UnityEngine;

public class TrainController : MonoBehaviour
{
    [Header("Train Settings")]
    public float maxSpeed = 80f;
    public float acceleration = 1.2f;
    public float braking = 2.5f;

    [Header("Train State")]
    public float speed = 0f;
    public bool doorsOpen = false;
    public bool lightsOn = true;
    public bool emergencyBrake = false;

    private float throttleInput = 0f;

    void Update()
    {
        HandleInput();
        UpdateTrainSpeed();
    }

    void HandleInput()
    {
        throttleInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.A))
        {
            doorsOpen = !doorsOpen;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            lightsOn = !lightsOn;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            emergencyBrake = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            emergencyBrake = false;
        }
    }

    void UpdateTrainSpeed()
    {
        if (emergencyBrake)
        {
            speed = Mathf.MoveTowards(
                speed,
                0f,
                braking * 2f * Time.deltaTime
            );

            return;
        }

        if (throttleInput > 0f)
        {
            speed = Mathf.MoveTowards(
                speed,
                maxSpeed,
                acceleration * throttleInput * Time.deltaTime
            );
        }
        else if (throttleInput < 0f)
        {
            speed = Mathf.MoveTowards(
                speed,
                0f,
                braking * Mathf.Abs(throttleInput) * Time.deltaTime
            );
        }
        else
        {
            speed = Mathf.MoveTowards(
                speed,
                0f,
                0.15f * Time.deltaTime
            );
        }

        speed = Mathf.Clamp(speed, 0f, maxSpeed);
    }
}
