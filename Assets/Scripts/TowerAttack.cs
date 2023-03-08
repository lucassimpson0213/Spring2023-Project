using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerAttack : MonoBehaviour
{
    public float towerAttackSpeed;
    private float lastAttack = 0;
    private List<Collider2D> collidersInside = new List<Collider2D>();
    [SerializeField] GameObject projectilePrefab;
    public int attackDamage;
    // Update is called once per frame
    void Update()
    {
        // This function will fire a Prefab at the direction of a target within its collider.
        // The target will depend on who is closer and what priority.
        // Towers will be targeted first even though the player is closer.
        // It will only attack the player if there is not towers in its collider.
        // Targeting system will use the Tower and Player Tags.
        // Attack target every n seconds.


        /*
         * Hi this is cody! I just want to make a few notes for modifications to this script
         * 
         * we want to avoid looking at time and waiting for a time to pass. instead we should be using coroutines to schedule things to happen for a certain period of time and then allowing that thing to happen again
         * 
         * take a look at the unity doc for StartCoroutine and IEnumerators. Try to make that work with this script
         * 
         * if you have any questions let me know
         */


        if (Time.time > lastAttack + towerAttackSpeed && collidersInside.Count > 0)
        {
            lastAttack = Time.time;
            //sorts all of the objects in the array in order by distance.
            var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
            if (target.Any(item => item.GetComponent<EnemyHealth>()))
            {
                // Gets the first object with the tag of Tower, no matter what postion it is from the array.
                Vector3 vectorToTarget = target[target.IndexOf(target.Where(x => x.tag == "Enemy/Ground").FirstOrDefault())].transform.position - transform.position;
                // Gets the angle of the target from the fireing origin.
                float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
                projectile.GetComponent<TowerProjectile>().attackDamage = attackDamage;
            }
        }
    }
    // Creates the array of objects inside of the collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if collider already exist inside of the array.
        if (!collidersInside.Contains(other))
        {
            collidersInside.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collidersInside.Remove(other);
    }
}
