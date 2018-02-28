using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject coin;
    private List<GameObject> obstaclesForSpawning = new List<GameObject>();

    void Start()
    {
        initializeObstacles();
        StartCoroutine(spawnObstacle());
        StartCoroutine(spawnCoin());
    }

    private void initializeObstacles() {
        for (int i = 0; i < obstacles.Length; i++) {
            int obstacleIndex = i % obstacles.Length;
            GameObject newObstacle = Instantiate(obstacles[obstacleIndex], obstacles[obstacleIndex].transform.position, Quaternion.identity);
            newObstacle.SetActive(false);
            obstaclesForSpawning.Add(newObstacle);
        }

        Shuffle();
    }

    private void Shuffle()
    {
        for (int i = 0; i < obstaclesForSpawning.Count; i++) {
            GameObject temp = obstaclesForSpawning[i];
            int randomIndex = Random.Range(i, obstaclesForSpawning.Count);
            obstaclesForSpawning[i] = obstaclesForSpawning[randomIndex];
            obstaclesForSpawning[randomIndex] = temp;
        }
    }

    private IEnumerator spawnObstacle()
    {
        if (obstaclesForSpawning.Count == 0) {
            initializeObstacles();
        }

        float randomTime = Random.Range(4f, 6f);
        yield return new WaitForSeconds(randomTime);


        int index = Random.Range(0, obstaclesForSpawning.Count);
        while (true) {
            if (!obstaclesForSpawning[index].activeInHierarchy) {
                obstaclesForSpawning[index].SetActive(true);
                obstaclesForSpawning.RemoveAt(index);
                break;
            }
            else {
                index = Random.Range(0, obstaclesForSpawning.Count);
            }
        }

        StartCoroutine(spawnObstacle());
    }

    private IEnumerator spawnCoin()
    {
        Debug.Log("New coin");
        float spawnerX = gameObject.transform.position.x;
        float coinY = Random.Range(-3f, 2.5f);
        Debug.Log(spawnerX);
        Debug.Log(coinY);
        GameObject newCoin = Instantiate(coin, new Vector3(spawnerX, coinY, 0f), Quaternion.identity);
        newCoin.SetActive(true);

        float randomTime = Random.Range(2f, 6f);
        yield return new WaitForSeconds(randomTime);

        StartCoroutine(spawnCoin());
    }
}
