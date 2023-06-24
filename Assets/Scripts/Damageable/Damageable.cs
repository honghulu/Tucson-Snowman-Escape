using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    public string sceneToLoad;
    public float health;
    public Image healthBar;
    public bool active = true;

    private void Start()
    {
        print("call start");
        if (health <= 0)
        {
            active = false;
            this.gameObject.SetActive(false);
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
            {
                c.enabled = false;
            }
        }
    }

    public virtual void TakeDamage( float damageToTake ) {
        health -= damageToTake;
        if (healthBar != null) {
            healthBar.fillAmount -= damageToTake / 100f;
        }

        if (health <= 0) {

            if (sceneToLoad != null) {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        
    }

    private void Update()
    {
        if (health <= 0 && active == true)
        {
            active = false;
            this.gameObject.SetActive(false);
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
            {
                c.enabled = false;
            }
        }
    }
}
