using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMeleeAttackManager : MonoBehaviour
{
    [SerializeField] GameObject meleeAttackPrefab;
    public float enemyAttackSpeed;
    private float lastAttack = 0;
    private List<Collider2D> collidersInside = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(collidersInside.Count);
        if (Time.time > lastAttack + enemyAttackSpeed)
        {
            lastAttack = Time.time;
            var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
            if (target.Any(item => item.tag == "Tower"))
            {
                //Debug.Log(target.IndexOf(target.Where(x => x.tag == "Tower").FirstOrDefault()));
                Debug.Log(target[target.IndexOf(target.Where(x => x.tag == "Tower").FirstOrDefault())].transform.position);
            }
        }

        //Debug.Log(target[0].name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
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
