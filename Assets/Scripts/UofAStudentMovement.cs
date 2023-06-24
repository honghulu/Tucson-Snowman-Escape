using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UofAStudentMovement : MonoBehaviour
{
    public float speed;
    public bool moveRight;
    public Transform collisionDetection;
    public float rayLength;
    public LayerMask turnAroundWhenHitLayer;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D rayCastResult = Physics2D.Raycast(collisionDetection.position, Vector2.up, rayLength, turnAroundWhenHitLayer);
        if (rayCastResult.collider == true) {
            if (moveRight) {
                this.transform.eulerAngles = new Vector3(0f, -180f, 0f);
                moveRight = false;
            }
            else {
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                moveRight = true;
            }
        }
    }

    public void freeze()
    {
        this.speed = 0;
    }
}
