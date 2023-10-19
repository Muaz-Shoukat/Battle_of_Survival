using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Animator enemyAnim;
    public Rigidbody enemyRigid;
    public float rn_speed;
    public Transform playerTrans,enemyTrans;


  

    void Start()
    {

    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(playerTrans.position, enemyTrans.position);
        if (distance < 50f && distance>=1f)
        {
            enemyRigid.velocity = transform.forward * rn_speed * Time.deltaTime;
        }
        else
        {
            enemyRigid.velocity = new Vector3(0,0,0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(playerTrans.position, enemyTrans.position);
        if (distance < 50f)
        {
            transform.LookAt(playerTrans.position);
            if (distance > 2f)
            {
                enemyAnim.SetTrigger("run");
                enemyAnim.ResetTrigger("idle");
            }else if(distance <= 2f)
            {
                enemyAnim.ResetTrigger("run");
                enemyAnim.SetTrigger("attack");
            }
        

        }
        else
        {
            enemyAnim.ResetTrigger("run");
            enemyAnim.SetTrigger("idle");
        }


       

      

       

    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyAnim.SetTrigger("dying");
            Invoke("destroyObject", 3);
        }
    }

}
