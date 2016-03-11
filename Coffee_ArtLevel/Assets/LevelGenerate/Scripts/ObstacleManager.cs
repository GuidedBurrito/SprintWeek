using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacleTypes = new List<GameObject>();
    public Transform[] spawnPoints;
    public float minTime;
    public float maxTime;
    //public int maximumObstacles;
    //GameObject[] newObject;

    // Use this for initialization
    void Start()
    {
        NumberMod();
    }

    void NumberMod()
    {
        int pickedLane = Random.Range(0, 4);

        int obstacleRandomizer = Random.Range(0, 100);

        GameObject obstacleToUse = obstacleTypes[0];
        if (obstacleRandomizer > 0 && obstacleRandomizer < 50)
        {
            obstacleToUse = obstacleTypes[0];
        }
        else if (obstacleRandomizer > 49 && obstacleRandomizer < 86)
        {
            obstacleToUse = obstacleTypes[1];
        }
        else if (obstacleRandomizer > 85 && obstacleRandomizer < 101)
        {
            obstacleToUse = obstacleTypes[2];
            pickedLane = 4;

        }
        Transform spawnInLane = spawnPoints[0];

        switch (pickedLane)
        {
            case 4:
                spawnInLane = spawnPoints[4];
                break;
            case 3:
                spawnInLane = spawnPoints[3];
                break;
            case 2:
                spawnInLane = spawnPoints[2];
                break;
            case 1:
                spawnInLane = spawnPoints[1];
                break;
            case 0:
                spawnInLane = spawnPoints[0];
                break;
        }
        float spawnTime = Random.Range(minTime, maxTime);
        StartCoroutine(PickLane(spawnTime, spawnInLane, obstacleToUse));

    }

    IEnumerator PickLane(float variableSpawnTime, Transform spawnInLane, GameObject obstacle)
    {
        Instantiate(obstacle, new Vector3(spawnInLane.transform.position.x, spawnInLane.transform.position.y, spawnInLane.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(variableSpawnTime);
        NumberMod();
    }
}
