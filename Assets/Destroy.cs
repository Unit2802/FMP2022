using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        effect = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (effect != null)
        Invoke(nameof(DestroyEffect), 1f);
    }

    void DestroyEffect()
    {
        Destroy(effect);
    }
}
