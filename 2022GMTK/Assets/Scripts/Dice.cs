using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //Report value only once, after complete stop
    bool hasLanded = false;
    Rigidbody rb;
    GameObject highestPoint;
    public float timer = 0;

    //Hold all side points
    public List<GameObject> sidePoints = new List<GameObject>();
    public GameObject floatyUI;
    public AudioClip collide, award;

    // Start is called before the first frame update
    void Start()
    {
        highestPoint = sidePoints[0];
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Coniditonal guard
        if (hasLanded) return;

        //Have dice been still for half a second at least?
        if (rb.velocity.magnitude >= 0 && rb.angularVelocity.magnitude >= 0)
        {
            timer += Time.deltaTime;
        }

        //Has the dice stopped
        if (timer > 3f)
        {
            hasLanded = true;

            //Report highest point as the value
            foreach (GameObject point in sidePoints) {

                //New highest point
                if (point.transform.position.y > highestPoint.transform.position.y)
                {
                    highestPoint = point;
                }
            }  
            
            Debug.Log("Highest point is: " + highestPoint.name);
            GameManager.Instance.rocketAmmo += int.Parse(highestPoint.name);
            GameUI.Instance.UpdateRocketUI();

            GetComponent<AudioSource>().clip = award;
            GetComponent<AudioSource>().Play();

            GameObject awardText = Instantiate(floatyUI, highestPoint.transform.position, Quaternion.identity);
            awardText.GetComponent<FloatingUI>().countText.text = "+" + highestPoint.name + " Rockets";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().clip = collide;
        GetComponent<AudioSource>().Play();
    }

    private void FixedUpdate()
    {
        rb.velocity += new Vector3(0, -.1f, 0);
    }
}
