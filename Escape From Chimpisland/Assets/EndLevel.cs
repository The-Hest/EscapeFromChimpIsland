using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string levelName;
    public int preBossLevels;
    public GameObject player;

    private int currentLevel;

    private void Start()
    {
        DontDestroyOnLoad(player);
    }

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
