using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankScript : MonoBehaviour
{
    public static FlankScript instance;

    //public GameObject LeftFlank;
    //public GameObject RightFlank;
    public GameObject LCylinder;
    public GameObject RCylinder;

    //public GameObject LGround;
    //public GameObject RGround;

    public GameObject LeftTyre;
    public GameObject RightTyre;

    public Vector3 iniRot1;
    public Vector3 iniRot2;

    public float ypos1;
    public float ypos2;

    public int AngularVel;

    public bool moveFlaps;

    public GameObject LFlap;
    public GameObject RFlap;

    private Quaternion RotL;
    private Quaternion RotR;

    public Vector3 FlapRotL;
    public Vector3 FlapRotR;

    public PlayerController5 playerController5;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    private void Start()
    {
        FlapRotL = LFlap.transform.rotation.eulerAngles;
        FlapRotR = RFlap.transform.rotation.eulerAngles;

        RotL = LCylinder.transform.rotation;
        RotR = RCylinder.transform.rotation;

        //RotL = LCylinder.transform.rotation.eulerAngles;
        //RotR = RCylinder.transform.rotation.eulerAngles;

        ypos1 = LeftTyre.transform.position.y;
        ypos2 = RightTyre.transform.position.y;

        iniRot1 = LeftTyre.transform.eulerAngles;
        iniRot2 = RightTyre.transform.eulerAngles;
    }
    private void LateUpdate()
    {
        if (RCylinder.transform.rotation.x > RotR.x)
        {
            LCylinder.transform.rotation = RotL;
            RCylinder.transform.rotation = RotR;
        }

        //Debug.Log("isFLying " + playerController5.isFlying);
        
        if (!GameManager.instance.GameOver)
        {
            if (!playerController5.isFlying)
            {

                LeftTyre.transform.eulerAngles = iniRot1;
                RightTyre.transform.eulerAngles = iniRot2;
            }
        }


        /*if (LCylinder.transform.localEulerAngles.x < 2)
        {
            LCylinder.transform.localEulerAngles = new Vector3(2, LCylinder.transform.localEulerAngles.y, LCylinder.transform.localEulerAngles.z);
        }
        if (RCylinder.transform.localEulerAngles.x < -2)
        {
            RCylinder.transform.localEulerAngles = new Vector3(-2,RCylinder.transform.localEulerAngles.y, RCylinder.transform.localEulerAngles.z);
        }
        */

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("LCylinder:"+ LCylinder.transform.rotation.x);
        //Debug.Log("RCylinder:" + RCylinder.transform.rotation.x);

        if (Input.GetKey("v")) 
        {
            Open();
        }
        if (Input.GetKey("c"))
        {
            Close();
        }

        if (Input.GetKey("b"))
        {
            //LCylinder.transform.eulerAngles = RotL;
            //RCylinder.transform.eulerAngles = RotR;

            LFlap.transform.eulerAngles = FlapRotL;
            RFlap.transform.eulerAngles = FlapRotR;

            PlayerController5.instance.rb.useGravity = true;
        }

        float angleX = LCylinder.transform.localRotation.x;
        //float angleX1 = LCylinder.transform.rotation.eulerAngles.y;

        Debug.Log("anglex:"+ LFlap.transform.localRotation.x);


        //Debug.Log("flapx"+ FlapRotL);
        //Debug.Log("anglex1:" + angleX1);
        
        if (angleX > 0.653)
        {
            //LCylinder.transform.rotation.x = 135;
            moveFlaps = true;
        }
        else
        {
            moveFlaps = false;
        }


    }

    void FixedUpdate()
    {
        
    }
    public void Close()
    {
        if (!moveFlaps)
        {
            //if (LCylinder.transform.localRotation.eulerAngles.x > 5)
            {
                LCylinder.transform.Rotate(0, AngularVel * Time.deltaTime, 0);
                RCylinder.transform.Rotate(0, -AngularVel * Time.deltaTime, 0);
            }
        }
        else //if(playerController5.isFlying)
        {
            //if (LCylinder.transform.localRotation.eulerAngles.x > 5)
            {
                //LFlap.transform.Rotate(0, AngularVel * Time.deltaTime * 10, 0);
                //RFlap.transform.Rotate(0, -AngularVel * Time.deltaTime * 10, 0);

                PlayerController5.instance.rb.useGravity = false;
                PlayerController5.instance.rb.transform.Translate(0, -1 * Time.deltaTime, 0);

                PlayerController5.instance.transform.Rotate(0, 0, AngularVel*Time.deltaTime);
            }
        }
    }

    public void Open()
    {
        if (!moveFlaps)
        {
            //if (RCylinder.transform.localRotation.eulerAngles.x < -5)
            {
                Debug.Log("X valll is " + LCylinder.transform.localRotation.eulerAngles.x);

                LCylinder.transform.Rotate(0, -AngularVel * Time.deltaTime, 0);
                RCylinder.transform.Rotate(0, AngularVel * Time.deltaTime, 0);
            }
        }
        else //if(playerController5.isFlying)
        {
            //if (RCylinder.transform.localRotation.eulerAngles.x < -5)
            {
                //LFlap.transform.Rotate(0, -AngularVel * Time.deltaTime * 10, 0);
                //RFlap.transform.Rotate(0, AngularVel * Time.deltaTime * 10, 0);

                PlayerController5.instance.transform.Rotate(0, 0, -AngularVel*Time.deltaTime);
                
                PlayerController5.instance.rb.useGravity = false;
                PlayerController5.instance.rb.transform.Translate(0, 1 * Time.deltaTime, 0);
            }
        }
    }
}
