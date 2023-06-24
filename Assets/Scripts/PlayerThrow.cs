using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public ObjectThrownMovement snowBall;
    public Transform snowBallSpawnLocation;
    public int snowBallsAllowed;
    List<ObjectThrownMovement> thrownSnowballs = new List<ObjectThrownMovement>();
    public Animator snowmanAnimator;
    public Damageable snowman;
    public SnowballGiveDamage damageAmount;
    public AudioSource attack;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {

            if (snowBallsAllowed > thrownSnowballs.Count) {
                ObjectThrownMovement newSnowball = 
                Instantiate<ObjectThrownMovement>(snowBall, snowBallSpawnLocation.position, snowBallSpawnLocation.rotation);
                attack.Play();
                newSnowball.owner = this;
                thrownSnowballs.Add(newSnowball);
                snowmanAnimator.SetBool("Shoot", true);
                snowman.TakeDamage(damageAmount.damageToDeal);
            }
        }

        if (Input.GetButtonUp("Fire1")) {
            snowmanAnimator.SetBool("Shoot", false);
        }
    }

    public void SnowBallDestroyed(ObjectThrownMovement destroyedSnowball) {
        thrownSnowballs.Remove(destroyedSnowball);
    }
}
