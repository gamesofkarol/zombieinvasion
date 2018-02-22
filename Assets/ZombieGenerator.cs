using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    public float spawnDelay;
    public GameObject zombiePrefab;


    private float leftEdge, rightEdge, topEdge, bottomEdge;
    private float spawnX, spawnY;
    private float lastSpawn;

	void Start () {
        lastSpawn = Time.time;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0,0)).x;
        bottomEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        topEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
    }
	

	void Update () {
        if(lastSpawn + spawnDelay < Time.time)
        {
            lastSpawn = Time.time;
            GenerateZombiePos();
            Instantiate(zombiePrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
        }
		
	}

    void GenerateZombiePos()
    {
        if(Random.value > 0.5f)
        {
            //x
            spawnX = Random.RandomRange(leftEdge, rightEdge);
            if (Random.value > 0.5f)
            {
                spawnY = topEdge;
            }
            else
            {
                spawnY = bottomEdge;
            }
                
        }
        else//y
        {
            spawnY = Random.RandomRange(bottomEdge, topEdge);
            if (Random.value > 0.5f)
            {
                spawnX = leftEdge;
            }
            else
            {
                spawnX = rightEdge;
            }
                
        }
    }
}
