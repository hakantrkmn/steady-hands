using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class woods : MonoBehaviour
{

    public List<AudioClip> odunsesi1 = new List<AudioClip>();


    public bool checkHit;

    // Start is called before the first frame update
    void Start()
    {
        checkHit = false;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (checkHit==true)
        {
            if (collision.transform.tag == "plank")
            {
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                StartCoroutine(endGame());
            }
            else if (collision.transform.tag == "trash")
            {
                Destroy(gameObject);
                GameObject.Find("gameManager").GetComponent<gameManager>().woodCount += 1;
            }
        }
        
            

        
        if (collision.transform.tag == "plank")
        {

                var r = Random.Range(0, odunsesi1.Count);
                collision.gameObject.GetComponent<AudioSource>().clip = odunsesi1[r];
                collision.gameObject.GetComponent<AudioSource>().Play();


        }
    }

    IEnumerator endGame()
    {
        yield return new  WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
