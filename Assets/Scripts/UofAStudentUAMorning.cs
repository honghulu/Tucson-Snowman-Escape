using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UofAStudentUAMorning : MonoBehaviour
{   
    private float min;
    private float max;

    public float movingMin, movingMax;
    
    void Start () {
        min = transform.position.x;
        max = transform.position.x + Random.Range(movingMin, movingMax);
    }
    
    
    void Update () {
        if (transform.position.x <= min + 1) {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else if (transform.position.x >= max - 1){
            this.transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }

}
