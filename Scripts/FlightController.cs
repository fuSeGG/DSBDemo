using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    // Serializing field to expose it in the inspector in Unity for manual setup, while avoiding making them public
    [SerializeField]
    private Rigidbody rigidBody;
    private const float thrustPower = 250;
    private const float rollPower = 25;
    private const float pitchPower = 15;
    private const float yawPower = 25;

    // Obviously the project is too small for an interface to be needed. But it seems a reasonable place to use it.
    // To make using different input system like a gamepad or joystick easier in the future
    private IFlightInput controller;

    private void Awake()
    {
        if (this.controller == null)
        {
            this.controller = GetComponent<IFlightInput>();
        }
        if (this.rigidBody == null)
        {
            this.rigidBody = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        if (this.controller.ThrustInput != 0)
        {
            ThrustForwards(this.controller.ThrustInput);
        }

        if (this.controller.RollInput != 0)
        {
            RotateShip(Vector3.forward, this.controller.RollInput, rollPower);
        }

        if (this.controller.PitchInput != 0)
        {
            RotateShip(Vector3.right, this.controller.PitchInput, pitchPower);
        }

        if (this.controller.YawInput != 0)
        {
            RotateShip(Vector3.up, this.controller.YawInput, yawPower);
        }
    }

    public void ThrustForwards(float thrustInput)
    {
        this.rigidBody.AddRelativeForce(Vector3.forward * (thrustInput * thrustPower * Time.deltaTime));
    }

    public void RotateShip(Vector3 axis, float input, float magnitude)
    {
        this.rigidBody.AddRelativeTorque(axis * (input * magnitude * Time.deltaTime));
    }
}
