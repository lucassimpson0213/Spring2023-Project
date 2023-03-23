using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyDetector : MonoBehaviour
{
    private List<Collider2D> collidersInside = new List<Collider2D>();
    // Update is called once per frame
    // Creates the array of objects inside of the collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if collider already exist inside of the array.
        if (!other.gameObject.GetComponent<TowerProjectile>() && !collidersInside.Contains(other))
        {
            collidersInside.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collidersInside.Remove(other);
    }
    public Transform GetCloseTower()
    {
        //sorts all of the objects in the array in order by distance.
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (target.Any(item => item.GetComponent<TowerHealth>()))
        {
            Transform vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<TowerHealth>()).FirstOrDefault())].transform;
            return vectorToTarget;
        } else if (target.Any(item => item.GetComponent<PlayerHealth>()))
        {
            Transform vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<PlayerHealth>()).FirstOrDefault())].transform;
            return vectorToTarget;
        }
        return null;
    }
}
