using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int health;

    public void loseHealth(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void gainHealth(int heal)
    {
        health = health + heal;
    }
}
