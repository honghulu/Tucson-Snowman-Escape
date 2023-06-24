using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    public float damageToDeal;

    private void Start()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable victim = collision.gameObject.GetComponent<Damageable>();

        if (victim != null)
        {
            victim.TakeDamage(damageToDeal);
        }
    }
}
