using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballGiveDamage : GiveDamage
{
    public PlayerThrow owner;
    public ObjectThrownMovement snowball;
    
    public override void OnTriggerEnter2D(Collider2D collider) {
        Damageable victim = collider.gameObject.GetComponent<Damageable>();

        if (victim != null) {
            victim.TakeDamage(damageToDeal);
            if (victim.name != "Snowman") {
                Destroy(this.gameObject);
                owner.SnowBallDestroyed(snowball);
            }
        }
    }
}

