using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChainProjectiles : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] int chains = 1;
    private Rigidbody2D rb;
    private Vector2 pos;
    private bool firedFromTower = true;
    public GameObject lockTarget;
    public int attackDamage;
    public List<GameObject> fireChain = new List<GameObject>();
    [SerializeField] GameObject detectObject;
    private int currentBounce = 0;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //detectObject.GetComponent<TowerChainDetect>().FindClosestEnemy();
        Debug.Log(lockTarget);
        //Debug.Log(fireOrigin[fireOrigin.Count - 1]);
    }

    // Update is called once per frame
    private void Update()
    {
        if (lockTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, lockTarget.transform.position, speed * Time.deltaTime);
            Vector3 vectorToTarget = lockTarget.transform.position - transform.position;
            float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, targetAngle);
            Debug.Log(targetAngle);
        } else
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        //pos = (lockTarget.transform.position) - (Vector3)(rb.position);
        //rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            transform.position = collision.transform.position;
            if (collision.gameObject == lockTarget)
            {
                collision.GetComponent<EnemyHealth>().loseHealth(attackDamage);
            }
            var newTarget = detectObject.GetComponent<TowerChainDetect>().FindClosestWhileExlude(collision.gameObject);
            if (newTarget == null || currentBounce >= chains)
            {
                Destroy(this.gameObject);
            }
            else
            {
                currentBounce++;
                fireChain.Add(newTarget);
                lockTarget = newTarget;
            }
        }
    }
}
