using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private CurrencyManager currencyManager;
    public GameObject floatingText;
    public int value = 10;

    // Start is called before the first frame update
    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Instantiate(floatingText, gameObject.transform.position, gameObject.transform.rotation, GameObject.FindGameObjectWithTag("FXCanvas").transform);
            currencyManager.AddCurrency(value);
            Destroy(gameObject);
        }
    }




}
