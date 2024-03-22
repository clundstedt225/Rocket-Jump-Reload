using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    //Only one instance of this, for each client
    private static GameUI _instance;
    public static GameUI Instance { get { return _instance; } }

    //UI references
    public TextMeshProUGUI iText, crosshair;
    public TextMeshProUGUI rocketCount;

    public GameObject resetPanel, winPanel;

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
    }
    
    public void UpdateRocketUI()
    {
        rocketCount.text = GameManager.Instance.rocketAmmo.ToString();
    }
}
