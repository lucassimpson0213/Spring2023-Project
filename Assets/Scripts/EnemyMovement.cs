using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    [SerializeField] float speed;
    public GameObject point;
    Rigidbody2D rb;
    Vector2 pos;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        pos = point.transform.position - (Vector3)(rb.position);
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);


    }
}
