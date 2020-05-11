using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;


    public static GameController Instance
    {
        get => _instance == null ? new GameController() : _instance;
    }

    public GameController()
    {
        if (_instance != null)
        {
            Debug.LogError("Cannot be two instances of GameController");
            return;
        }
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
