using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    public int maxHeight;
    public int minHeight;
    public int timeToMove;
   


    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "Player")
       {
              if(Input.GetKey(KeyCode.W))
              {
                    if(gameObject.transform.position.y < maxHeight)
                    {
                        transform.DOMoveY(maxHeight, timeToMove);
                    }
              }
       }      if(Input.GetKey(KeyCode.S))
              {
                  if(gameObject.transform.position.y > minHeight)
                  {
                    transform.DOMoveY(minHeight, timeToMove * 2);
                  }
                 
              }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            if(gameObject.transform.position.y > minHeight)
            {
                transform.DOMoveY(minHeight, timeToMove * 2);
            }
        }
    }

    
}