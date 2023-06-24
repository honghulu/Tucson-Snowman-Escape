using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowHide : MonoBehaviour
{
    public GameObject snowman;
    
    public void OnTriggerStay2D (Collider2D collider) {
        if (Input.GetButton("hide")) {
            snowman.SetActive(false);
        } else {
            snowman.SetActive(true);
        }
    }
}
