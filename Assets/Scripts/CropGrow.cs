using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrow : MonoBehaviour
{
    public float growTime = 10;
    private float growRate = 0;
    [SerializeField] Sprite[] growStageSprites;
    float plantStageTimer = 0;
    bool cropIsFull = false;
    int cropStages;
    int currentStage = -1;
    [SerializeField] cropEffect cropPickupEffect;
    [SerializeField] int healthValue = 0;
    [SerializeField] int moneyValue = 0;
    enum cropEffect
    {
        money,
        health
    }
    // Start is called before the first frame update
    void Start()
    {
        if(growStageSprites.Length <= 0)
        {
            Debug.LogError("Crop does not have any grow stages in its array (Check Grow Stage Sprites)");
        }
        cropStages = growStageSprites.Length;
        growRate = growTime / growStageSprites.Length;
    }

    // Update is called once per frame
    void Update()
    {
        plantStageTimer += Time.deltaTime;
        if (growRate <= plantStageTimer && !(currentStage >= (cropStages - 1)))
        {
            plantStageTimer = 0;
            currentStage++;
            gameObject.GetComponent<SpriteRenderer>().sprite = growStageSprites[currentStage];
        }
        if (currentStage >= (cropStages - 1))
        {
            cropIsFull = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() && (cropIsFull))
        {
            switch (cropPickupEffect)
            {
                case cropEffect.money:
                    //Give player Money Here
                    break;
                case cropEffect.health:
                    collision.GetComponent<PlayerHealth>().gainHealth(healthValue);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
