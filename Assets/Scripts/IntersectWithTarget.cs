using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectWithTarget : MonoBehaviour
{
    public playerControl target;
    public float intersectAfterTime;
    Vector3 travelDelta;

    void Start()
    {
        Vector3 leadingPos = target.transform.position + intersectAfterTime * target.direction;
        travelDelta = leadingPos - transform.position;
    }

    void Update()
    {
        transform.position += travelDelta * Time.deltaTime / intersectAfterTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
