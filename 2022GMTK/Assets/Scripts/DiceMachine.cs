using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceMachine : MonoBehaviour, IInteractable
{
    float randomScatterAmountY = 0.0f;

    public GameObject dicePrefab;
    public Transform launchPoint;
    public TextMeshProUGUI useCountText;

    //How hard do the dice get launched?
    public float launchForce = 10f;

    //How many more times can this machine dispence dice?
    public int allowedUses = 1; 

    public string Descriptor = "Press E to Use Machine";

    public string ItemName
    {
        get { return Descriptor; }

        set { ItemName = value; }
    }

    private void Start()
    {
        //Update UI to display initial use count
        useCountText.text = allowedUses.ToString();
    }

    public void Interact()
    {
        //If allowed, launch dice
        if (allowedUses > 0)
        {        
            //Account for use, and update world space UI
            allowedUses -= 1;
            useCountText.text = allowedUses.ToString();

            //Space out launches to avoid mid air collision
            Invoke("launchDice", .01f);
            Invoke("launchDice", .2f);
        }

    }

    public void launchDice()
    {
        //Generate random scatter angle if any, then apply to the barrel where the ray fires out
        randomScatterAmountY = UnityEngine.Random.Range(-145, -200);
        Quaternion rot = Quaternion.Euler(-10, randomScatterAmountY, 0);
        launchPoint.localRotation = rot;

        //Shoot dice
        GameObject dice1 = Instantiate(dicePrefab, launchPoint.position, launchPoint.rotation);
        dice1.GetComponent<Rigidbody>().AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
    }
}
