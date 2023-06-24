using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGiveDamage : GiveDamage
{   
    public virtual void OnCollisionEnter2D(Collision2D collision) {
        Damageable victim = collision.gameObject.GetComponent<Damageable>();

        if (victim != null) {
           
            victim.TakeDamage(damageToDeal);
        }
    }
}

