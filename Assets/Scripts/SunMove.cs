using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float cameraX;
    public float cameraY;

    void Update()
    {
        if (transform.position.x >= 0f)
        {
            // slow down when approaching mid from right
            acceleration = Mathf.Abs(acceleration);
        } else if (transform.position.x < 0f)
        {
            // speed up when approaching mid from left
            acceleration = -Mathf.Abs(acceleration);
        }

        if (transform.position.x > cameraX)
        {
            speed = -Mathf.Abs(speed);
        } else if (transform.position.x < -cameraX)
        {
            speed = Mathf.Abs(speed);
        }
        transform.Translate((speed + acceleration) * Time.deltaTime, 0f, 0f);
    }
}
