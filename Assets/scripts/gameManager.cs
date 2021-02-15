using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public List<GameObject> odunlar= new List<GameObject>();

    public GameObject gameOver;
    public int woodCount;
    // Start is called before the first frame update
    void Start()
    {
        woodCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (woodCount == settings.Instance.woodCount && woodCount!=0)
        {
            gameOver.SetActive(true);
        }
        if (settings.Instance.start)
        {
            gameObject.GetComponent<AudioSource>().Play();
            for (int i = 0; i < settings.Instance.woodCount; i++)
            {
                var x = Random.Range(-2, 2);
                var y = Random.Range(0, 3);
                var obj = Instantiate(odunlar[y], new Vector3(x, (i+2) * 5, 0), Random.rotation);
                obj.name = "odun" + i;
            }
            settings.Instance.start = false;
            
        }
    }


}
