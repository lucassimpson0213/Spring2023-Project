using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class level
{

    
    //Place holder amounts, need to change to get base stats dynamicly.
    private int health = 100;
    private int attack = 50;
    private int aps = 1;
    private int range = 10;

    public void setupLevel(int hp, int atk, int speed, int range)
    {
        this.health = hp;
        this.attack = atk;
        this.aps = speed;
        this.range = range;
    }
    public void setHealth(int hp)
    {
        this.health = hp;
    }
    public int getHealth()
    {
        return this.health;
    }
    public void setAttack(int atk)
    {
        this.attack = atk;
    }
    public int getAttack()
    {
        return this.attack;
    }
    public void setAttackRate(int aps)
    {
        this.aps = aps;
    }
    public int getAttackRate()
    {
        return this.aps;
    }
    public void setRange(int rng)
    {
        this.range = rng;
    }
    public int getRange()
    {
        return this.range;
    }
}


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
    //ToDo:referance currancyManager and add costs to level

    public int max_level = 5;
    //ToDo: Find out how stats will increase from level to level
    public int statMultiplier = 2;
    public double multiplierIncrease = .5;
    private int curr_level = 0;
    level[] towerLevels;


    // Start is called before the first frame update
    void Start()
    {
        towerLevels = new level[max_level];

        for (int x = 1; x < max_level; x++ )
        {
            towerLevels[x].setupLevel(
                towerLevels[x - 1].getHealth() * statMultiplier,
                towerLevels[x - 1].getAttack() * statMultiplier,
                towerLevels[x - 1].getAttackRate() * statMultiplier,
                towerLevels[x - 1].getRange() * statMultiplier);

            //not working quest yet

            //statMultiplier = (double)statMultiplier + multiplierIncrease;
        }
    }
    
    public void levelUp()
    {
        curr_level++;
    }
    public int getCurrHealth()
    {
        return towerLevels[curr_level].getHealth();
    }
    public int getCurrAttack()
    {
        return towerLevels[curr_level].getAttack();
    }
    public int getCurrAttackRate()
    {
        return towerLevels[curr_level].getAttackRate();
    }
    public int getCurrRange()
    {
        return towerLevels[curr_level].getRange();
    }
}

