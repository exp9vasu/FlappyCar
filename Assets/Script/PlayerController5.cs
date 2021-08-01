using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController5 : MonoBehaviour
{
    public static PlayerController5 instance;
    public CameraFollow1 cameraFollow1;
    public FlankScript flankScript;

    public Rigidbody rb;
    public int zvelocity;
    public Material LightedMaterial;
    public Material DarkMaterial;
    public bool isStarted;
    public bool isFlying;
    private Quaternion startRotation; 

    public GameObject TutorPanel;

    public float DistanceLeft;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
        isStarted = false;

        isFlying = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) 
        { isStarted = true;}
        
            if (transform.position.z < 250 && isStarted)
            {
                //rb.AddForce(0,0,20,ForceMode.Acceleration);
                //rb.velocity = new Vector3(0,0,velocity);

                transform.Translate(-zvelocity * Time.deltaTime, 0, 0);
            }

        if (transform.position.z > 250) 
        { stopCar(); }

        if(transform.position.z>= 48 && transform.position.z <= 54)
        {
            UIManager.instance.AnimateCoin();
        }
        else
        {
            UIManager.instance.CoinStop();
        }
    }


    private void Update()
    {
        if (isStarted)
        {
            TutorPanel.SetActive(false);
        }

        DistanceLeft = 55 - transform.position.z;

        if (DistanceLeft > 55)
        {
            DistanceLeft = 55;
        }

        if (transform.position.z > 55)
        {
            DistanceLeft = 0;
        }

        if(transform.position.x > 1.8f || transform.position.x < -1.8f)
        {
            GameManager.instance.GameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            other.GetComponent<MeshRenderer>().material = DarkMaterial;
        }

        if (other.CompareTag("end"))
        {
            cameraFollow1.StartFlying();
            isFlying = true;
            //cameraFollow1.transform.Translate(2,0,-4);

        }

        if (other.CompareTag("newstart"))
        {
          //  transform.rotation = startRotation;

            cameraFollow1.OnLanding();
            isFlying = false;
            EnableAnim();
            //PlayerController5.instance.transform.Rotation
            //flankScript.LFlap.transform.eulerAngles = flankScript.FlapRotL;
            //flankScript.RFlap.transform.eulerAngles = flankScript.FlapRotR;
        }

        if (other.CompareTag("ditch"))
        {
            //isFlying = true;
            //DisableAnim();
        } 

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            other.GetComponent<MeshRenderer>().material = LightedMaterial;
        }

        if (other.CompareTag("ditch"))
        {
            //isFlying = false;
            //EnableAnim();
        }
    }

    public void DisableAnim()
    {
        cameraFollow1.DisableAnimator();
    }

    public void EnableAnim()
    {
        cameraFollow1.EnableAnimator();
    }
    public void stopCar()
    {
            rb.GetComponent<Rigidbody>().isKinematic = true;
    }
}
