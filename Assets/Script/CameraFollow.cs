using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject VCar;
    public Vector3 offset;
    public Vector3 CameraPos;
    public Vector2 lastMousePosition;

    private float swipeResistanceX = 0.0f;

    Vector2 touchPosition;

    // Start is called before the first frame update
    void Start()
    {
        CameraPos = transform.position;
        offset = transform.position - VCar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 55)
        {
            GameManager.instance.levelCleared = true;
        }

        if (VCar.transform.position.z < 55)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, VCar.transform.position.z + offset.z);
        }

        else
        {
            if (transform.position.z < 55.5)
            {
                transform.RotateAround(new Vector3(0, 0, 55), Vector3.down, 20 * Time.deltaTime);
            }          
        }

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {

            Vector2 deltaSwipe = touchPosition - (Vector2)Input.mousePosition;
        
            if(/*Mathf.Abs(deltaSwipe.x)> swipeResistanceX &&*/ (Vector2)Input.mousePosition != lastMousePosition)
            {
                lastMousePosition = (Vector2)Input.mousePosition;

                if (deltaSwipe.x < 0)
                {
                    FlankScript.instance.Open();
                }

                if (deltaSwipe.x > 0)
                {
                    FlankScript.instance.Close();
                }
            }
        }
    
    }

}
