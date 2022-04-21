using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
   [Range(100, 10000)]
   public float bounceheight;
   PlayerController player;



   private void OnCollisionEnter(Collision collision)
   {
		player.SetGroundedState(true);
		GameObject bouncer = collision.gameObject;
		Rigidbody rb = bouncer.GetComponent<Rigidbody>();
		rb.AddForce(Vector3.up * bounceheight);
   }
}
