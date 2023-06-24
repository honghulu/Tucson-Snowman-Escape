using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamEffectOnSnowman : MonoBehaviour
{
    public float healAmount;
    void OnCollisionEnter2D(Collision2D collision) {
        Healable snowman = collision.gameObject.GetComponent<Healable>();
        if (snowman != null){
            if (collision.transform == snowman.transform) {
                if (snowman != null) {
                    snowman.Heal(healAmount);
                }

                Destroy(this.gameObject);
            }
        }

        
    }
}
