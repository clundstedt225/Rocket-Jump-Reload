using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingUI : MonoBehaviour
{
    public TextMeshProUGUI countText;


    // Update is called once per frame
    void Update()
    {
        if(Camera.main != null)
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
    }
}
