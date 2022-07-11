using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    public bool ActionInput { get; private set; }
    public float VerticalInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        this.ActionInput = Input.GetButtonDown("Fire1");
        this.VerticalInput = Input.GetAxisRaw("Vertical");
    }
}
