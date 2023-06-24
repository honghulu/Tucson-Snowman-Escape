using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageableSun : Damageable
{
    private float healthCopy;
    public GameObject[] snowToDestroy;

    void Start() {
        healthCopy = health;
    }
    public override void TakeDamage( float damageToTake ) {
        health -= damageToTake;
        healthBar.fillAmount -= damageToTake / 100f;

        if (health <= healthCopy / 2f) {
            for (int i = 0; i < snowToDestroy.Length; i++) {
                snowToDestroy[i].SetActive(false);
            }
        }

        if (health <= 0) {
            Destroy(this.gameObject);
            SaveGame saveGame = new SaveGame();
            saveGame.ClearSerializedInfo();
            SceneManager.LoadScene(sceneToLoad);
        }

        
    }
}
