using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public static int playerCurrentCurrency;
    [SerializeField] int startingCurrency = 500;
    public static CurrencyManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one CurrencyManager in scene");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentCurrency = startingCurrency;
    }
    public void AddCurrency(int currencyToAdd)
    {
        // Add currency function
        GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("MoneyGet");
        playerCurrentCurrency += currencyToAdd;
    }
    public bool SubtractCurrency(int currencyToSubtract)
    {
        // Subtract money and return a bool if player can afford.
        if (playerCurrentCurrency - currencyToSubtract < 0)
        {
            return false;
        } else
        {
            playerCurrentCurrency -= currencyToSubtract;
            return true;
        }
    }
    public bool CanPlayerAfford(int currencyToCheck)
    {
        // Returns a bool if the player can afford 
        if (playerCurrentCurrency <= currencyToCheck)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public int GetPlayerCurrency()
    {
        return playerCurrentCurrency;
    }
    public void SetPlayerCurrency(int setCurrency)
    {
        playerCurrentCurrency = setCurrency;
    }
}
