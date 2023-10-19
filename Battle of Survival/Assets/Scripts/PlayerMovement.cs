using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed,wb_speed,olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
  

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * wb_speed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
        else
        {
            playerRigid.velocity = new Vector3(0,0,0);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {



        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            

        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
                playerAnim.Play("attack");
                Invoke("WalkAnimation", 2);
                
            }
            //if (Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //    w_speed = olw_speed;
            //    playerAnim.SetTrigger("walk");
            //    playerAnim.ResetTrigger("attack");
            //}
        }

    }

    public void WalkAnimation()
    {
        playerAnim.SetTrigger("walk");
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            playerAnim.SetTrigger("dying");
            Invoke("destroyObject", 3);
        }
    }
}




