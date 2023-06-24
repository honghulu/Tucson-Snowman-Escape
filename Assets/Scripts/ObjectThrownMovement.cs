using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrownMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public PlayerThrow owner;

    void FixedUpdate() {
        body.velocity = this.transform.TransformDirection(new Vector2(speed, 0f));
    }

   void OnBecameInvisible()
    {
        Destroy(gameObject);
        owner.SnowBallDestroyed(this);
    }
}
