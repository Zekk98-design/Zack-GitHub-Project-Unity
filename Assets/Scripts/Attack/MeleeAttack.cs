﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Leaderboard lBoard;
    public PlayerStats playerStats;
    public bool isWeapon;

    private void Start()
    {
        GameObject EGO = GameObject.Find("EGO Spawn");
        lBoard = EGO.GetComponent<Leaderboard>();
    }

    private void OnCollisionEnter(Collision collision)                                      // Check collision
    {
        if (collision.gameObject.tag == "Enemy")                                            // Compare collision with tag
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();        // Get stats on collided enemy

            if (isWeapon == true & enemyStats.defence > 0)
            {
                enemyStats.defence = enemyStats.defence - playerStats.damage;
                if (gameObject.CompareTag("Player1"))
                {
                    lBoard.p1Dmg = lBoard.p1Dmg + playerStats.damage;
                }
                if (gameObject.CompareTag("Player2"))
                {
                    lBoard.p2Dmg = lBoard.p2Dmg + playerStats.damage;
                }
            }

            if (isWeapon == true & enemyStats.defence < 0)
            {
                enemyStats.health = enemyStats.health - playerStats.damage;                 // if weapon, deal damage
                if (gameObject.CompareTag("Player1"))
                {
                    lBoard.p1Dmg = lBoard.p1Dmg + playerStats.damage;
                }
                if (gameObject.CompareTag("Player2"))
                {
                    lBoard.p2Dmg = lBoard.p2Dmg + playerStats.damage;
                }
            }

            if (isWeapon == false & playerStats.defence > 0)
            {
                playerStats.defence = playerStats.defence - enemyStats.damage;                // if not weapon, take damage
            }

            if (isWeapon == false & playerStats.defence <= 0)
            {
                playerStats.health = playerStats.health - enemyStats.damage;
            }
        }
    }
}