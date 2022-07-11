using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlightInput
{
    float ThrustInput { get; }
    float StrafeInput { get; }
    float YawInput { get; }
    float RollInput { get; }
    float PitchInput { get; }
}
