using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        //Clean up if lost in void too long
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            //Debug.LogWarning("ROCKET HIT A THING");

            //Create explosion at contact point
            Instantiate(explosion, transform.position, Quaternion.identity);

            //Destroy self
            Destroy(gameObject);
        }
    }
}
