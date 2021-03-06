﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    public string[] scenes;

    private GameObject _player;
    private GameObject _playerUI;
    private GameObject _audioManager;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerUI = GameObject.Find("PlayerUI");
        _audioManager = GameObject.Find("AudioManager");

        DontDestroyOnLoad(_player);
        DontDestroyOnLoad(_playerUI);
        DontDestroyOnLoad(_audioManager);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var currentScene = _player.GetComponent<LevelSystem>().GetCurrentLevel();
            var nextScene = _player.GetComponent<LevelSystem>().GetNextLevel();

            if (currentScene == "SampleScene")
                DontDestroyOnLoad(GameObject.Find("Main Camera"));
            else
                Destroy(GameObject.Find("Main Camera"));

            SceneManager.LoadScene(nextScene);

        }
    }
}
