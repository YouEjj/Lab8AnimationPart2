using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Animator animator;
    float velocityX = 0f;
    float velocityZ = 0f;

    float accelaration = 0.25f;
    float decelaration = 0.25f;


    float maxWalking = 0.5f;
    float maxRunning = 2f;

    float maxVelocityforward = 0f;
    float maxVelocityright = 0f;
    float maxVelocityleft = 0f;
    float maxVelocityback = 0f;

    bool testpress=false;
    bool runpress = false;
    //bool rot = false;
    //private bool alreadyExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //get inputs
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.UpArrow);
        bool runbackPressed = Input.GetKey(KeyCode.DownArrow);
        bool rightPressed = Input.GetKey(KeyCode.E);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.Q);
        bool runRightPressed = Input.GetKey(KeyCode.RightArrow);
        bool runleftPressed = Input.GetKey(KeyCode.LeftArrow);



        maxVelocityforward = runPressed ? maxRunning : maxWalking;
        maxVelocityright = runRightPressed ? maxRunning : maxWalking;
        maxVelocityleft = runleftPressed ? maxRunning : maxWalking;
        maxVelocityback = runbackPressed ? maxRunning : maxWalking;



        if (forwardPressed && velocityZ < maxVelocityforward)
        {
            velocityZ += Time.deltaTime * accelaration;
            testpress = true;
        }
        if (rightPressed && velocityX < maxVelocityright)
        {
            velocityX += Time.deltaTime * accelaration;
            testpress = true;
        }
        if (leftPressed && velocityX > -maxVelocityleft)
        {
            velocityX -= Time.deltaTime * accelaration;
            testpress = true;
        }
        if (backPressed && velocityZ > -maxVelocityback)
        {
            velocityZ -= Time.deltaTime * accelaration;
            testpress = true;
        }
        if (forwardPressed && runPressed && velocityZ <maxVelocityforward)
        {
            velocityZ += Time.deltaTime * accelaration;
            runpress=true;
            
        }

        if (rightPressed && runRightPressed && velocityX < maxVelocityright)
        {
            velocityX += Time.deltaTime * accelaration;
            runpress = true;
        }

        if (leftPressed && runleftPressed && velocityX > -maxVelocityleft)
        {
            velocityX -= Time.deltaTime * accelaration;
            runpress = true;
        }
        if (backPressed && runbackPressed && velocityZ > -maxVelocityback)
        {
            velocityZ -= Time.deltaTime * accelaration;
            runpress = true;
            //rot = true;
        }
        //walking
        if (!backPressed && testpress && velocityZ<=0)
        {
            velocityZ += Time.deltaTime * decelaration;
           
        }
        if (!forwardPressed && testpress && velocityZ >= 0)
        {
            velocityZ -= Time.deltaTime * decelaration;

        }
        if (!rightPressed && testpress && velocityX >= 0)
        {
            velocityX -= Time.deltaTime * decelaration;

        }
        if (!leftPressed && testpress && velocityX <= 0)
        {
            velocityX += Time.deltaTime * decelaration;

        }
        //running
        if (!runbackPressed && runpress && velocityZ <= -0.5)
        {
            velocityZ += Time.deltaTime * decelaration;
            
        }
        
        if (!runPressed && runpress && velocityZ >= 0.5)
        {
            velocityZ -= Time.deltaTime * decelaration;
        }
        if (!runRightPressed && runpress && velocityX >= 0.5)
        {
            velocityX -= Time.deltaTime * decelaration;

        }
        if (!runleftPressed && runpress && velocityX <= -0.5)
        {
            velocityX += Time.deltaTime * decelaration;

        }


      

        animator.SetFloat("VelocityX", velocityX);
        animator.SetFloat("VelocityZ", velocityZ);



























        /*if (rot && !alreadyExecuted)
        {
            velocityX += 0.15f;
            alreadyExecuted = true;
        }*/

    }
}
