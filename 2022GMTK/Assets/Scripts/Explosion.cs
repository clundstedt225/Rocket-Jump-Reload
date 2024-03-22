using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 10.0F;
    public float power = 100.0F;
    Movement ch;

    // Start is called before the first frame update
    void Start()
    {
        //Clean up self
        Destroy(gameObject, 1f);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {

            if (hit.tag == "Player")
            {
                //Debug.LogWarning("Explossion hit player...");

                if (hit.gameObject.GetComponent<Movement>())
                {
                    ch = hit.gameObject.GetComponent<Movement>();

                    //Add force in direction of player to controller
                    ch.jumpVelocity += -(transform.position - ch.gameObject.transform.position) * 5;
                }
            }
        }
    }
}
