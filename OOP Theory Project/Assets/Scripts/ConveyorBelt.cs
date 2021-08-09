using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float Speed { get; private set; } //ENCAPSULATION

    private void Awake()
    {
        Speed = 4.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, Speed * Time.deltaTime);
    }

    public void SetConveyorSpeed(float speed)
    {
        Speed = speed;
    }
}
