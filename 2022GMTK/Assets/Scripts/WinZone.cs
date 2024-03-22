using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public ParticleSystem confetti;
    public string LevelName;
    AudioSource aSource;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() && !GameManager.Instance.levelComplete)
        {
            confetti.Play();
            aSource.Play();

            //Passes next level to load and allows for advancement
            GameManager.Instance.LevelComplete(LevelName);
        }
    }
}
