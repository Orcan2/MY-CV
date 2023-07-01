using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMovement : MonoBehaviour
{
    public float force;

    
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*force*Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }
}
