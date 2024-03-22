using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Only one instance of this, for each client
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public string currentLevel = "Level 1";
    public int rocketAmmo = 0;

    public bool levelComplete = false;
    string newLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        Scene scene = SceneManager.GetActiveScene();
        currentLevel = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(newLevel);
        }
    }

    public void LevelComplete(string nextLevel)
    {
        //Enable ui 
        GameUI.Instance.winPanel.SetActive(true);

        //Allow for level advancement
        newLevel = nextLevel;
        levelComplete = true;
    }
}
