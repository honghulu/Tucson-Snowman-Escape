using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathGround : LoadScene
{
    void OnTriggerEnter2D(Collider2D collider) {
        Load("Failure Screen -- NightMountain");
    }
}
