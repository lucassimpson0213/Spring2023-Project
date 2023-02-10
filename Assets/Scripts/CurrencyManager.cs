using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public static int Money;
    [SerializeField] int startingMoney = 500;
    // Start is called before the first frame update
    void Start()
    {
        Money = startingMoney;
    }
}
