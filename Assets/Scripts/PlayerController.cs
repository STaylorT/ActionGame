using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 200;
    public float Spin = 20;

    private Rigidbody body;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("attacking");
        }
    }

    void FixedUpdate()
    { // physics stuff here
        float direction = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * Spin;
        body.AddRelativeForce(new Vector3(0, 0, direction));
        animator.SetBool("running", direction > 0);
        body.AddTorque(new Vector3(0, rotation, 0));

    }
}
