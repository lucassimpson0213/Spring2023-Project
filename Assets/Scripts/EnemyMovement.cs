using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField] float speed;
    [SerializeField] GameObject towerDetectObject;
    private Rigidbody2D rb;
    Vector2 pos;
    [SerializeField] float bufferDistance;
    private GameObject playerCore;

    /*
     * Hey its cody! 
     * I know you know what to do from here
     * 
     * Michael finished his script for grabbing the closest thing, now just make the position it moves to the closest thing according to the attack script
     * 
     * I believe!
     * 
     * If you have any questions just let me know :D
     * 
     */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCore = GameObject.Find("core");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform NearestObject = towerDetectObject.GetComponent<EnemyDetector>().GetCloseTower();
        if (NearestObject != null)
        {
            pos = (NearestObject.position) - (Vector3)(rb.position);
            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            if (Vector2.Distance(NearestObject.position, rb.position) > bufferDistance)
            {
                rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
            }
        } else
        {
            pos = (playerCore.transform.position) - (Vector3)(rb.position);
            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            if (Vector2.Distance(playerCore.transform.position, rb.position) > bufferDistance)
            {
                rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
            }
        }
    }
}
