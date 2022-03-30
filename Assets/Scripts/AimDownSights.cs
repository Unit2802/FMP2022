using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour
{
    

    [Header("Changing the FOV")]
    public Camera myCam;
    public int ZoomInFOV = 30;
    public int ZoomOutFOV = 60;

    

    [Header("Moving the gun when aiming in")]

    private Vector3 originalPos;
    [SerializeField] Vector3 aimPos;
    [SerializeField] float adsSpeed = 8;


    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ADS();
        if(Input.GetButton("Fire2"))
        {
            ZoomIn();
        } else
        {
            ZoomOut();
        }

      
    }

    void ZoomIn()
    {
        myCam.fieldOfView = ZoomInFOV;
    }

    void ZoomOut()
    {
        myCam.fieldOfView = ZoomOutFOV;
    }

    private void ADS()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPos, Time.deltaTime * adsSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPos, Time.deltaTime * adsSpeed);
        }
    }
}