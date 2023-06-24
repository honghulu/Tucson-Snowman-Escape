using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunShotManager : MonoBehaviour
{

    public IntersectWithTarget BallObj;
    private IntersectWithTarget _ball;
    public playerControl character;

    public float waitTime;
    private float timer = 0.0f;
    Quaternion rotation = Quaternion.Euler(0, 0, 0);
    private int allShots = 0;


    void Update()
    {
        if (timer < waitTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;

            Vector3 charPosition = character.transform.position.normalized;
            Vector3 thisPosition = this.transform.position.normalized;
            Vector3 crossProduct = Vector3.Cross(charPosition, thisPosition);
            rotation = Quaternion.Euler(0, 0, crossProduct.y);
            _ball = Instantiate(BallObj, transform.position * 1.0f, rotation);
            _ball.target = character;
            allShots += 1;
            _ball.name = "Shot " + allShots.ToString();
        }
    }

}