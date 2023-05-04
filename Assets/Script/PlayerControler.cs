using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10f;
    Animator animator;
    Rigidbody rb;
    public float jumpfoce = 50f;
    public bool IsGrounded;

    public static PlayerControler inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        

    }

    public void savegame()
    {
        SaveLoadGame.inst.Saveplayerdata(transform.position);
    }

   

    

    void Update()
    {
        keymove();
        onJump();
        fall();
       

    }

    void fall()
    {
        animator.SetFloat("Y", rb.velocity.y);
        Debug.Log("Y Value = " + rb.velocity.y);
    }

    





    public void keymove()
    {
        //if (Input.GetButton("Vertical"))
        //{
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        //{ 
        float move = Input.GetAxis("Vertical");
       // Debug.Log(move);

        rb.velocity = new Vector3(0, rb.velocity.y, move * speed);
        animator.SetFloat("X", move);
        // }
        //}

    }


    public void onJump()
    {
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpfoce);
            animator.SetTrigger("Jump");
            Debug.Log("onJump");
        }
                      
    }    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }        
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
            //animator.SetTrigger("Falling");
        }
    }

}
