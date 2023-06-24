using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutGiveDamage : EnvironmentGiveDamage
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable victim = collision.gameObject.GetComponent<Damageable>();

        if (victim != null && this.transform.position.y > -2.4)
        {
            victim.TakeDamage(damageToDeal);
        }
    }
}
