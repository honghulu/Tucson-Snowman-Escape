using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : FollowCamera
{
    float GAP = 5;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        Vector3 position = this.transform.position;
        if (this.transform.position.x < objectToFollow.transform.position.x - GAP || this.transform.position.x > objectToFollow.transform.position.x + GAP)
        {
            position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        }
        this.transform.position = position;
    }
}