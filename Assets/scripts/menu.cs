using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject leftBut;
    public GameObject rightBut;
    bool left;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            Camera.main.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 1);
        }
        else if(right)
        {
            Camera.main.transform.RotateAround(new Vector3(0, 0, 0), -Vector3.up, 1);

        }

    }

    public void turnLeftTrue()
    {
        left = true;
    }
    public void turnLeftFalse()
    {
        left = false;
    }
    public void turnRightTrue()
    {
        right = true;
    }
    public void turnRightFalse()
    {
        right = false;
    }

    public void isInputNull(string text)
    {
        if (text!=null )
        {
                settings.Instance.woodCount = int.Parse(text);
                settings.Instance.start = true;
                GameObject.Find("woodCount").SetActive(false);
                rightBut.SetActive(true);
                leftBut.SetActive(true);
            
        }
    }



    public void tryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
