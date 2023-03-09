using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Upgrades : MonoBehaviour
{
    /*
     * Hey I just wanted to make sure we were on the same track for this script!
     * Level design has expressed their dislike for the idea of managing stat multipliers and incrementing statMultipliers
     * We want to pivot back to the per prefab set arrays of the levels
     * We can do this one of two ways
     * Arrays for each stat
     * or
     * Objects that hold each stat and an array to hold those objects
     * 
     * If you have any questions reach out to me during club or on discord :D
     * 
     */

    public int max_level = 5;
    private int curr_level = 0;
    private int[] health;
    private int[] attack;
    private int[] attackRate;
    private int[] range;
    private int[] upgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        health = new int[max_level];
        attack = new int[max_level];
        attackRate = new int[max_level];
        range = new int[max_level];
        upgradeCost = new int[max_level];

        for (int x = 0; x < max_level; x++ )
        {
            //todo: change this to get stats from prefab.
            health[x] = 0;
            attack[x] = 0;
            attackRate[x] = 0;
            range[x] = 0;
            upgradeCost[x] = 0;
        }
    }
    
    public void levelUp()
    {
        if(CurrencyManager.instance.SubtractCurrency(upgradeCost[curr_level]) 
            && curr_level<max_level)
        {
            curr_level++;
        }
    }
    public int getCurrentLevel()
    {
        return curr_level;
    }
    public int getHealth()
    {
        return health[curr_level];
    }
    public int getAttack()
    {
        return attack[curr_level];
    }
    public int getAttackRate()
    {
        return attackRate[curr_level];
    }
    public int getRange()
    {
        return range[curr_level];
    }
    public int getUpgradeCost()
    {
        return upgradeCost[curr_level];
    }
}

