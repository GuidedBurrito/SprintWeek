using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tileSet;

    SpriteRenderer rend;
    float tileWidth;

    GameObject newTile;

    float nextXValue;

    void Start()
    {
        tileWidth = tileSet[0].GetComponent<SpriteRenderer>().bounds.size.x;
        nextXValue = this.transform.position.x;
    }

    void Update()
    {
        if (this.transform.position.x > nextXValue)
        {
            SpawnNewFloorTile();
        }
    }


    void SpawnNewFloorTile()
    {

        int tileToSpawn = Random.Range(0, tileSet.Length);
        newTile = (GameObject)Instantiate(tileSet[tileToSpawn], new Vector3(nextXValue, this.transform.position.y, 0), Quaternion.identity);
        float tileStartX = newTile.transform.position.x;
        nextXValue = tileStartX + tileWidth;
    }











































    //    if (spawner.transform.position.x > previousTile.transform.position.x)
    //        {
    //            SpawnNewFloorTile();
    //}



    //void SpawnNewFloorTile()
    //{

    //    int tileToSpawn = Random.Range(0, tileSet.Length);
    //    newTile = (GameObject)Instantiate(tileSet[tileToSpawn], new Vector3(spawner.transform.position.x + nextXValue, spawner.transform.position.y, 0), Quaternion.identity);
    //    print("spawned");
    //    float tileStartX = newTile.transform.position.x;
    //    //print(tileStartX);

    //    float tileWidth = newTile.GetComponent<SpriteRenderer>().bounds.size.x;
    //    //print(tileWidth);

    //    nextXValue = tileStartX + tileWidth;
    //    // print("next x" + nextXValue);
    //    previousTile = newTile;
    //    Spawn(previousTile);
    //}

    //void Spawn(GameObject previousTile)
    //{


    //}

}
