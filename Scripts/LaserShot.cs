using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public float Speed { private set; get; } = 10f;
    
    void Update()
    {
        MoveForwards();
    }

    private void MoveForwards()
    {
        transform.position += transform.forward * this.Speed * Time.deltaTime;
    }
}
