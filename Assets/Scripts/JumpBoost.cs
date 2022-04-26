using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject block = collision.gameObject;
        Rigidbody rb = block.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 5000);
    }
}
