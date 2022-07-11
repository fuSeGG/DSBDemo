using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    // Serializing fields to expose them in the inspector in Unity for manual setup
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private TextMeshProUGUI speedText;

    private void Awake()
    {
        if (this.rigidbody == null)
        {
            this.rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {        
        this.speedText.text = "Speed: " + System.Math.Round(rigidbody.velocity.magnitude, 0).ToString();
    }
}
