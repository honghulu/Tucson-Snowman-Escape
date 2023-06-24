using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healable : MonoBehaviour
{
    public Damageable healableCharacter;
    public Image healthBar;
    public AudioSource heal;
    public void Heal( float healAmount ) {
        if (healableCharacter.health + healAmount <= 100) {
            heal.Play();
            healableCharacter.health += healAmount;
            healthBar.fillAmount += healAmount / 100f;
        } else if (healableCharacter.health + healAmount > 100) {
            heal.Play();
            healableCharacter.health = 100;
            healthBar.fillAmount = 1f;
        }
    }
}
