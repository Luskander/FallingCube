using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikedEnemy;
    [SerializeField] private GameObject shooterEnemy;

    public float SpawnTimer = 2f;
    private float currentSpawnTimer;

    private float enemySpawnedCount;

    public float ChanceToSpawn;
    private float lvlModifier;

    public float Min_X = -2.4f, Max_X = 2.4f;

    void Start()
    {
        SetLvlModifier();
    }

	void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        currentSpawnTimer += Time.deltaTime;
        
        if (currentSpawnTimer >= SpawnTimer)
		{
            enemySpawnedCount++;

            Vector2 temp = transform.position;
            temp.x = Random.Range(Min_X, Max_X);

            GameObject newEnemy = null;

            if (enemySpawnedCount < 3)
            {
                if (Random.Range(0, 100) < ChanceToSpawn)
				{
                    newEnemy = Instantiate(spikedEnemy, temp, Quaternion.identity);
                }
            }

            else if (enemySpawnedCount == 3)
            {
                if (Random.Range(0, 100) < ChanceToSpawn)
				{
                    if (Random.Range(0, 2) > 0)
                    {
                        newEnemy = Instantiate(shooterEnemy, temp, Quaternion.identity);
                    }
                    else
                    {

                        newEnemy = Instantiate(spikedEnemy, temp, Quaternion.identity);
                    }
                }                    
            }

            else if (enemySpawnedCount == 4)
			{
                if (Random.Range(0, 100) < ChanceToSpawn)
				{
                    newEnemy = Instantiate(shooterEnemy, temp, Quaternion.identity);
                }
                enemySpawnedCount = 0;
            }

            if (newEnemy)
            {
                newEnemy.transform.parent = transform;
            }

            currentSpawnTimer = 0f;
        }
    }

    void SetLvlModifier()
	{
        if (PlayerPrefs.GetInt("PlayerLVL") > 40)
        {
            ChanceToSpawn = 70;
        }
        else
        {
            lvlModifier = PlayerPrefs.GetInt("PlayerLVL") / 2;
            ChanceToSpawn += lvlModifier;
        }
    }
}
