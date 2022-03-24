using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;



    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    public void SetXSense (float x)
    {
       
        RoomManager.Instance.xSense = x;

    }
    public void SetYSense (float y)
    {
        Debug.Log(y);
        RoomManager.Instance.ySense = y;
    }
}
