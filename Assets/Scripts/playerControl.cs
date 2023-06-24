using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed;
    public Rigidbody2D thisBody;
    public float jumpPower;
    float horizInput;
    public Transform groundedRayOrigin;
    public float groundedRayLength;
    public Vector3 direction;
    public Animator snowmanAnimator;
    
    public AudioSource jump;
    public AudioSource walk;
    
    
    void Update() {
        thisBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        horizInput = Input.GetAxis("Horizontal");

        
        if (horizInput < 0f) {
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            thisBody.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        } else if (horizInput > 0f) {
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            thisBody.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } 

        if (Input.GetButtonDown("Jump")) {
            RaycastHit2D raycastResult = Physics2D.Raycast(groundedRayOrigin.position, groundedRayOrigin.right, groundedRayLength);
            if (raycastResult.collider != null) {
                jump.Play();
                thisBody.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            }
        }

        if (Mathf.Abs(horizInput) > 0){
            snowmanAnimator.SetBool("Move", true);
        } else {
            snowmanAnimator.SetBool("Move", false);
        }
        
        // OLD: the direction should be the way the character is traveling, not its position
        // direction = this.transform.position;
    }

    void FixedUpdate()
    {
        thisBody.velocity = new Vector2(horizInput * speed, thisBody.velocity.y);
        direction = Vector3.Normalize( thisBody.velocity ); // NEW: set the direction here
    }
}
