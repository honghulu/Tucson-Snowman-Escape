using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public string nextLevelName;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        SaveGame savegame = new SaveGame();
        // victory animation
        Destroy(collision.gameObject);

        savegame.ClearSerializedInfo();
        SceneManager.LoadScene(nextLevelName);
    }
}
