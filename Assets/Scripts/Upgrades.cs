using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Upgrades : MonoBehaviour
{

    [SerializeField] int max_level = 5;
    [SerializeField] int curr_level = 0;
    [SerializeField] int[] health;
    [SerializeField] int[] attack;
    [SerializeField] int[] attackRate;
    [SerializeField] int[] range;
    [SerializeField] int[] upgradeCost;
    /// /////////////////////////////////////////////////
        // Code for testing remove before normal use.
    private bool canFire;
    private int booletcooldown;
    /// /////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        /// /////////////////////////////////////////////////
        // Code for testing remove before normal use.
        canFire = true;
        booletcooldown = 1;
        /// /////////////////////////////////////////////////
        health = new int[max_level];
        attack = new int[max_level];
        attackRate = new int[max_level];
        range = new int[max_level];
        upgradeCost = new int[max_level];

        for (int x = 0; x < max_level; x++ )
        {
            //Set stat arrays to 0, they'll be filled later.
            health[x] = 0;
            attack[x] = 0;
            attackRate[x] = 0;
            range[x] = 0;
            upgradeCost[x] = 0;
        }
    }
  
    /// /////////////////////////////////////////////////
    // Code for testing remove before normal use.
    private void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            levelUp();
            Debug.Log("LEVEL UP to " + curr_level + " max_level is supposed to be " + max_level);
            canFire = false;
            StartCoroutine(fireWait());
        }
    }
    IEnumerator fireWait()
    {
        yield return new WaitForSeconds(booletcooldown);
        canFire = true;
    }

    /// /////////////////////////////////////////////////

    public void levelUp()
    {
        if(CurrencyManager.instance.SubtractCurrency(upgradeCost[curr_level]) 
            && curr_level < max_level-1 )
        {
            curr_level++;
            gameObject.GetComponent<TowerHealth>().levelUpHealth();
        }
    }
    public int getCurrentLevel()
    {
        return curr_level + 1;
    }
    public int getHealth()
    {
        return health[curr_level];
    }
    public int getPrevHealth()
    {
        if (curr_level > 0)
            return health[curr_level - 1];
        else
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

