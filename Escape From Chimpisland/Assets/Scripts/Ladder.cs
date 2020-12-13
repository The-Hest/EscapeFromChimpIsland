using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    public string[] scenes;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
        DontDestroyOnLoad(_player);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var scene = _player.GetComponent<LevelSystem>().GetNextLevel();
            SceneManager.LoadScene(scene);

        }
    }
}
