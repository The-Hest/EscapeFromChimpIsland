using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    public string levelName;
    public int preBossLevels;

    private int currentLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentLevel > preBossLevels)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}
