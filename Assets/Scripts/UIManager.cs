using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    [SerializeField] private Text coinsText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        coinsText.text = "Coins: 0";
    }

    public void UpdateCoins(int numCoins)
    {
        coinsText.text = "Coins: " + numCoins;
    }
}
