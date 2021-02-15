using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    private static settings _instance;

    public static settings Instance 
    {
        get
        {
            if (_instance==null)
            {
                GameObject go = new GameObject("settings");
                go.AddComponent<settings>();
            }
            return _instance;
        }

    }

    public bool gameOver { get; set; }
    public bool start { get; set; }
    
    public int woodCount { get; set; }

    public int checkHit { get; set; }
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        start = false;
        checkHit = 0;
    }

}
