using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float Tumble { get; private set; } = 0.2f;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * this.Tumble;
    }
}