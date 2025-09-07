using System;
using UnityEngine;

public class Triger : MonoBehaviour
{
    public event Action Triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Triggered?.Invoke();
        }
    }
}
