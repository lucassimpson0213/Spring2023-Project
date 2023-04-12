using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrow : MonoBehaviour
{
    public float growRate = 10;
    [SerializeField] Sprite[] growStageSprites;
    float plantStageTimer = 0;
    bool cropIsFull = false;
    int cropStages;
    int currentStage = -1;
    // Start is called before the first frame update
    void Start()
    {
        if(growStageSprites.Length <= 0)
        {
            Debug.LogError("Crop does not have any grow stages in its array (Check Grow Stage Sprites)");
        }
        cropStages = growStageSprites.Length;
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
        Debug.Log(collision.name);
        if (collision.GetComponent<PlayerHealth>() && (cropIsFull))
        {
            //Give player Money Here
            Destroy(this.gameObject);
        }
    }
}
