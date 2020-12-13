﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    public string[] scenes;

    private GameObject _player;
    private GameObject _playerUI;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _playerUI = GameObject.Find("PlayerUI");
        DontDestroyOnLoad(_player);
        DontDestroyOnLoad(_playerUI);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var scene = _player.GetComponent<LevelSystem>().GetNextLevel();
            if (scene == "SampleScene")
                DontDestroyOnLoad(GameObject.Find("Main Camera"));
            SceneManager.LoadScene(scene);

        }
    }
}
