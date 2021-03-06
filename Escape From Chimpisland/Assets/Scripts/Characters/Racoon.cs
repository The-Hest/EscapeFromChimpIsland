﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    public Animator animator;
    public float interactDistance;
    [HideInInspector]
    public bool firstEncounter;
    [HideInInspector]
    public GameObject player;

    private float _distance;

    private void Start()
    {
        player = GameObject.Find("Player");
        firstEncounter = true;
        _distance = 2 * interactDistance; // First time encoutering the racoon say hi from further away
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < _distance)
        {
            animator.SetTrigger("encounter");
        }
    }

    public void FirstInteraction()
    {
        _distance = interactDistance;
        firstEncounter = false;
    }
}
