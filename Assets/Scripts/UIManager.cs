using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text ammoText;

   public void UpdateAmmo(float count)
    {
        ammoText.text = "Ammo: " + count;
    }
}
