using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerVFX : MonoBehaviour
{
    // Serializing fields to expose them in the inspector in Unity, while avoiding making them public
    [SerializeField] private GameObject propeller;
    [SerializeField] private Rigidbody rigidbody;


    private void Awake()
    {
        if (this.rigidbody == null)
        {
            this.rigidbody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (this.rigidbody.velocity != Vector3.zero)
        {
            RotatePropeller();
        }
    }

    private void RotatePropeller()
    {        
        this.propeller.transform.Rotate(Vector3.up, this.rigidbody.velocity.magnitude);
    }
}