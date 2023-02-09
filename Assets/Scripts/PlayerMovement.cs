using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.MovePosition(rb.position + direction.normalized * Time.fixedDeltaTime * speed);
    }
    public Vector2 GetDirection()
    {
        return direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy/Ground")
        {
            Debug.Log("I can hit that");
        } else if(collision.transform.tag == "Enemy/Flying")
        {
            Debug.Log("I can't hit that");
        } else
        {
            Debug.Log("WTF is that");
            Debug.Log(collision.transform.tag);

        }
    }
}
