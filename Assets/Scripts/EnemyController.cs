using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemySpawn;
    public float timeBetweenWaves;
    public float countdown;
    private int waveNumber = 0;




    /*NOTES FROM CODY!
     
    For this we want to have the wave controller spawn an enemy spawner
    The enemy spawner should despawn after spawning a certain amount of enemies
    When the wave controller spawns the enemy spawner, it should give a number to the enemy spawn that is the amount it should spawn

    To control this, we want 8 Arrays (One for each Orthagonal and Diagonal Direction (N,NE,E,etc.))
    The array would store the type of enemy we want to spawn
    The array would also have a mirrored array, one that has the same amount of elements, to be used as the amount of those enemy types to spawn
    
    Ask me any questions you have about this. Thanks!
     
     */


    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawn Wave");
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            //Wait 0.5 seconds before spawning next enemy
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
        Debug.Log("Spawn Enemy");
    }
}
