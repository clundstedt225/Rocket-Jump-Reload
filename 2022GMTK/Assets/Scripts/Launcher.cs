using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    bool allowEndGameCheck = false;

    public GameObject rocket;
    public Transform barrelTip;

    public AudioClip shoot, noAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Guard against shooting once level is completed
        if (GameManager.Instance.levelComplete) return;

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.rocketAmmo > 0)
        {
            //Player has had more than 0 rockets, start checking again for 0
            allowEndGameCheck = true;

            GameManager.Instance.rocketAmmo -= 1;
            GameUI.Instance.UpdateRocketUI();

            GetComponent<AudioSource>().clip = shoot;
            GetComponent<AudioSource>().Play();

            GameObject r = Instantiate(rocket, barrelTip.position, barrelTip.rotation);
            r.GetComponent<Rigidbody>().AddForce(barrelTip.forward * 25f, ForceMode.Impulse);

        } else if (Input.GetMouseButtonDown(0) && GameManager.Instance.rocketAmmo <= 0)
        {
            GetComponent<AudioSource>().clip = noAmmo;
            GetComponent<AudioSource>().Play();
        }

        if (allowEndGameCheck && GameManager.Instance.rocketAmmo == 0)
        {
            //Display UI notification
            if (!GameUI.Instance.resetPanel.activeSelf)
            {
                GameUI.Instance.resetPanel.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(GameManager.Instance.currentLevel);
            }
        }
    }
}
