using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    private Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player is null");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
