
using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour
{
    public Vector3 konum;
    public Text sa; 
    public float hiz;
    public List<AudioClip> odunsesi1 = new List<AudioClip>();

    public float deltaX;
    public float deltaY;

    int i = 0;

    private void Start()
    {
        sa = GameObject.Find("Text").GetComponent<Text>();
    }

    private void Update()
    {
        if (transform.position.y<-5)
        {
            Destroy(gameObject);
        }
        Camera.main.transform.RotateAround(konum, Vector3.up, hiz);
        if (Input.touchCount>0)
        {
            sa.text = "dokundu";
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase==TouchPhase.Began)
            {
                deltaX = touchPos.x - transform.position.x;
                deltaY = touchPos.y - transform.position.y;
            }
            //mZCoord = Camera.main.WorldToScreenPoint(
            //gameObject.transform.position).z;
            //// Store offset = gameobject world pos - mouse world pos
            //mOffset = gameObject.transform.position - GetMouseAsWorldPoint(touch.position);
            

            if (touch.phase == TouchPhase.Moved)
            {
                sa.text = "kaydırıyor";
                if (Camera.main.transform.eulerAngles.y < 45 && Camera.main.transform.eulerAngles.y >= 0)
                {

                    float temp = transform.position.z;
                    //transform.position = GetMouseAsWorldPoint(touch.position) + mOffset;
                    //transform.position = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, temp);

                    gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(touchPos.x - deltaX, touchPos.y - deltaY,temp));
                }
                else if (Camera.main.transform.eulerAngles.y < 135 && Camera.main.transform.eulerAngles.y > 45)
                {

                    float temp = transform.position.x;
                    //transform.position = GetMouseAsWorldPoint(touch.position) + mOffset;
                    //transform.position = new Vector3(temp, touch.deltaPosition.y, touch.deltaPosition.x);
                    gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(temp, touchPos.y - deltaY, touchPos.x-deltaX));

                }
                else if (Camera.main.transform.eulerAngles.y < 225 && Camera.main.transform.eulerAngles.y > 135)
                {

                    float temp = transform.position.z;
                    //transform.position = GetMouseAsWorldPoint(touch.position) + mOffset;
                    //transform.position = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, temp);
                    gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(touchPos.x - deltaX, touchPos.y - deltaY, temp));

                }
                else if (Camera.main.transform.eulerAngles.y < 315 && Camera.main.transform.eulerAngles.y > 225)
                {
                    float temp = transform.position.x;
                    //transform.position = GetMouseAsWorldPoint(touch.position) + mOffset;
                    //transform.position = new Vector3(temp, touch.deltaPosition.y, touch.deltaPosition.x);
                    gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(temp, touchPos.y - deltaY, touchPos.x - deltaX));

                }
                else if (Camera.main.transform.eulerAngles.y < 360 && Camera.main.transform.eulerAngles.y > 315)
                {

                    float temp = transform.position.z;
                    //transform.position = GetMouseAsWorldPoint(touch.position) + mOffset;
                    //transform.position = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, temp);
                    gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(touchPos.x - deltaX, touchPos.y - deltaY, temp));

                }

                var oduns = GameObject.FindGameObjectsWithTag("plank");
                foreach (var item in oduns)
                {
                    if (item == gameObject)
                    {
                        continue;
                    }
                    else
                    {
                        if (item.GetComponent<Rigidbody>().velocity.magnitude > 0.6f)
                        {
                            item.GetComponent<MeshRenderer>().material.color = Color.red;
                            Debug.Log("çarptın");
                            break;
                        }

                    }
                }
            }

            if (touch.phase==TouchPhase.Ended)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        }
    }
    private Vector3 mOffset;
    private float mZCoord;
    //void OnMouseDown()
    //{
    //    mZCoord = Camera.main.WorldToScreenPoint(
    //        gameObject.transform.position).z;
    //    // Store offset = gameobject world pos - mouse world pos
    //    mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    //}
    private Vector3 GetMouseAsWorldPoint(Vector2 touchPos)
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = new Vector3(touchPos.x, touchPos.y, 0);
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    //void OnMouseDrag()
    //{

    //    if (Camera.main.transform.eulerAngles.y < 45 && Camera.main.transform.eulerAngles.y >= 0)
    //    {

    //        float temp = transform.position.z;
    //        //gameObject.GetComponent<Rigidbody>().MovePosition(GetMouseAsWorldPoint() + mOffset);
    //        //gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, transform.position.y, temp));
    //        transform.position = GetMouseAsWorldPoint() + mOffset;
    //        transform.position = new Vector3(transform.position.x, transform.position.y, temp);
    //    }
    //    else if (Camera.main.transform.eulerAngles.y < 135 && Camera.main.transform.eulerAngles.y > 45)
    //    {

    //        float temp = transform.position.x;
    //        transform.position = GetMouseAsWorldPoint() + mOffset;
    //        transform.position = new Vector3(temp, transform.position.y, transform.position.z);
    //    }
    //    else if (Camera.main.transform.eulerAngles.y < 225 && Camera.main.transform.eulerAngles.y > 135)
    //    {

    //        float temp = transform.position.z;
    //        transform.position = GetMouseAsWorldPoint() + mOffset;
    //        transform.position = new Vector3(transform.position.x, transform.position.y, temp);
    //    }
    //    else if (Camera.main.transform.eulerAngles.y < 315 && Camera.main.transform.eulerAngles.y > 225)
    //    {
    //        float temp = transform.position.x;
    //        transform.position = GetMouseAsWorldPoint() + mOffset;
    //        transform.position = new Vector3(temp, transform.position.y, transform.position.z);
    //    }
    //    else if (Camera.main.transform.eulerAngles.y < 360 && Camera.main.transform.eulerAngles.y > 315)
    //    {

    //        float temp = transform.position.z;
    //        transform.position = GetMouseAsWorldPoint() + mOffset;
    //        transform.position = new Vector3(transform.position.x, transform.position.y, temp);
    //    }

    //    var oduns = GameObject.FindGameObjectsWithTag("plank");
    //    foreach (var item in oduns)
    //    {
    //        if (item == gameObject)
    //        {
    //            continue;
    //        }
    //        else 
    //        {
    //            if (item.GetComponent<Rigidbody>().velocity.magnitude > 0.6f)
    //            {
    //                item.GetComponent<MeshRenderer>().material.color = Color.red;
    //                Debug.Log("çarptın");
    //                break;
    //            }
                    
    //        }
    //    }

    //}

    private void OnCollisionEnter(Collision collision)
    {
        i++;
        if (collision.transform.tag=="plank")
        {
            if (i==4)
            {
                var r = Random.Range(0, odunsesi1.Count);
                collision.gameObject.GetComponent<AudioSource>().clip = odunsesi1[r];
                collision.gameObject.GetComponent<AudioSource>().Play();
                i = 0;
            }
            
        }
    }

}