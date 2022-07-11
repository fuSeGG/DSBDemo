using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightInputKeyboard : MonoBehaviour, IFlightInput
{
    public float ThrustInput { get => this.thrustInput; }
    public float StrafeInput { get => this.strafeInput; }
    public float YawInput { get => this.yawInput; }
    public float RollInput { get => this.rollInput; }
    public float PitchInput { get => this.pitchInput; }

    private float thrustInput;
    private float strafeInput;
    private float yawInput;
    private float rollInput;
    private float pitchInput;

    void Update()
    {
        this.yawInput = Input.GetAxisRaw("Horizontal");
        this.pitchInput = Input.GetAxisRaw("Vertical");
        this.rollInput = Input.GetAxisRaw("HorizontalSecondary");
        this.thrustInput = Input.GetAxisRaw("Fire1");
    }
}
