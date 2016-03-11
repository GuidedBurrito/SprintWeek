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

        int obstacleRandomizer = Random.Range(0, 1000);

        GameObject obstacleToUse = obstacleTypes[0];
        if (obstacleRandomizer > 0 && obstacleRandomizer < 100)
        {
            obstacleToUse = obstacleTypes[0];
        }
        else if (obstacleRandomizer > 99 && obstacleRandomizer < 200)
        {
            obstacleToUse = obstacleTypes[1];
        }
        else if (obstacleRandomizer > 199 && obstacleRandomizer < 300)
        {
            obstacleToUse = obstacleTypes[2];
        }
        else if (obstacleRandomizer > 299 && obstacleRandomizer < 400)
        {
            obstacleToUse = obstacleTypes[3];
        }
        else if (obstacleRandomizer > 399 && obstacleRandomizer < 500)
        {
            obstacleToUse = obstacleTypes[4];
        }
        else if (obstacleRandomizer > 499 && obstacleRandomizer < 600)
        {
            obstacleToUse = obstacleTypes[5];
        }
        else if (obstacleRandomizer > 599 && obstacleRandomizer < 700)
        {
            obstacleToUse = obstacleTypes[6];
        }
        else if (obstacleRandomizer > 699 && obstacleRandomizer < 800)
        {
            obstacleToUse = obstacleTypes[7];
            pickedLane = 4; //7 will be for the car
        }
        else if (obstacleRandomizer > 799 && obstacleRandomizer < 900)
        {
            obstacleToUse = obstacleTypes[8];
        }
        else if (obstacleRandomizer > 899 && obstacleRandomizer < 1000)
        {
            obstacleToUse = obstacleTypes[9];
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
