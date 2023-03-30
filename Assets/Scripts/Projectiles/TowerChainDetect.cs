using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerChainDetect : MonoBehaviour
{
    private List<Collider2D> collidersInside = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
    public GameObject FindClosestEnemy()
    {
        //sorts all of the objects in the array in order by distance.
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (target.Any(item => item.GetComponent<EnemyHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<TowerHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        }
        return null;
    }
    public GameObject FindClosestWhileExlude(GameObject exclude)
    {
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (target.Any(item => item.gameObject == exclude))
        {
            target.Remove(target[target.IndexOf(target.Where(x => x.gameObject == exclude).FirstOrDefault())]);
        }
        if (target.Any(item => item.GetComponent<EnemyHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<EnemyHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        }
        return null;
    }
}
