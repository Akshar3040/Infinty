using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10f;
   public  Animator animator;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      //  animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float move = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(0, rb.velocity.y, move * speed);
        animator.SetFloat("X", move);

         



    }
}
