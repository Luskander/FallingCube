using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PlatformPrefab;
    [SerializeField] private GameObject SpikePlatform;
    [SerializeField] private GameObject[] MovingPlatform;
    [SerializeField] private GameObject BreakablePlatform;
    [SerializeField] private GameObject Star;
    [SerializeField] private GameObject[] Buff;

    public float PlatformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public int ChanceToSpawnStar = 10;
    public int ChanceToSpawnBuff = 10;

    public float Min_X = -2f, Max_X = 2f;
    void Start()
    {
        currentPlatformSpawnTimer = PlatformSpawnTimer;
    }

    void Update()
    {
        SpawnObjects();
    }

    void SpawnObjects()
	{
        currentPlatformSpawnTimer += Time.deltaTime;

        if(currentPlatformSpawnTimer >= PlatformSpawnTimer)
		{
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(Min_X, Max_X);

            GameObject newPlatform = null;
            GameObject newStar = null;
            GameObject newBuff = null;

            if(platformSpawnCount < 2)
			{
                newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);

                if (Random.Range(0, 25) < ChanceToSpawnStar)
                {
                    newStar = Instantiate(Star, new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                }

                else
                {
                    if (Random.Range(0, 100) < ChanceToSpawnBuff)
                    {
                        newBuff = Instantiate(Buff[Random.Range(0, Buff.Length)], new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                    }
                }
            }

            else if(platformSpawnCount == 2)
			{
                if(Random.Range(0,2) > 0)
				{
                    newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);

                    if (Random.Range(0, 50) < ChanceToSpawnStar)
                    {
                        newStar = Instantiate(Star, new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                    }

                    else
                    {
                        if (Random.Range(0, 100) < ChanceToSpawnBuff)
                        {
                            newBuff = Instantiate(Buff[Random.Range(0, Buff.Length)], new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                        }
                    }
                }
                else
				{
                    newPlatform = Instantiate(MovingPlatform[Random.Range(0, MovingPlatform.Length)], temp, Quaternion.identity);

                    if (Random.Range(0, 50) < ChanceToSpawnStar)
                    {
                        newStar = Instantiate(Star, new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                    }

                    else
                    {
                        if (Random.Range(0, 100) < ChanceToSpawnBuff)
                        {
                            newBuff = Instantiate(Buff[Random.Range(0, Buff.Length)], new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                        }
                    }
                }
            }

            else if(platformSpawnCount == 3)
			{
                if (Random.Range(0, 5) > 0)
                {
                    newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);

                    if (Random.Range(0, 75) < ChanceToSpawnStar)
                    {
                        newStar = Instantiate(Star, new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                    }

                    else
                    {
                        if (Random.Range(0, 100) < ChanceToSpawnBuff)
                        {
                            newBuff = Instantiate(Buff[Random.Range(0, Buff.Length)], new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                        }
                    }
                }

                else
                {
                    newPlatform = Instantiate(SpikePlatform, temp, Quaternion.identity);
                }
            }

            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);

                    if (Random.Range(0, 100) < ChanceToSpawnStar)
                    {
                        newStar = Instantiate(Star, new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
                    }

                    else
					{
                        if(Random.Range(0, 100) < ChanceToSpawnBuff)
						{
                            newBuff = Instantiate(Buff[Random.Range(0, Buff.Length)], new Vector2(temp.x, temp.y + 0.5f), Quaternion.identity);
						}
					}
                }

                else
                {
                    newPlatform = Instantiate(BreakablePlatform, temp, Quaternion.identity);
                }

                platformSpawnCount = 0;
            }

            if(newPlatform)
			{
                newPlatform.transform.parent = transform; // добавляет все созданные платформы в иерархию к спавнеру
            }

            if(newStar)
			{
                newStar.transform.parent = transform;
			}

            if (newBuff)
            {
                newBuff.transform.parent = transform;
            }

            currentPlatformSpawnTimer = 0f;
        }
    } // создание платформ
}
