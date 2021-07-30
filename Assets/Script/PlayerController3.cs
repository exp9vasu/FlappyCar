using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public static PlayerController3 instance;

    public Rigidbody rb;
    public int zvelocity;
    public Material LightedMaterial;
    public Material DarkMaterial;
    public bool isStarted;

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
        rb = GetComponent<Rigidbody>();
        isStarted = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) 
        { isStarted = true; }
        
            if (transform.position.z < 55 && isStarted)
            {
                //rb.AddForce(0,0,20,ForceMode.Acceleration);
                //rb.velocity = new Vector3(0,0,velocity);
                transform.Translate(-zvelocity * Time.deltaTime, 0, 0);
            }

        if (transform.position.z > 55) { stopCar(); }

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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            other.GetComponent<MeshRenderer>().material = LightedMaterial;
        }
    }

    public void stopCar()
    {
            rb.GetComponent<Rigidbody>().isKinematic = true;
    }
}
