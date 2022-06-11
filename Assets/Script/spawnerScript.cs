using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject[] spawnees;
    public bool stopspawning = false;
    public float spawnTime;
    public float spawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulity", 0) + 1;
        spawnDelay = spawnDelay / difficulty;

        //Fire the provided method, after spawnTime seconds, every spawnDelay seconds
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        var position = Random.Range(transform.position.x + -3f, transform.position.x + 5.5f);



        int randomIndex = Random.Range(0, spawnees.Length);
        GameObject spawnee = spawnees[randomIndex];

        // Creates clone of the spawnee object, at a given position and rotation
        Instantiate(spawnee, new Vector3(position, transform.position.y - 1), transform.rotation);


        if (stopspawning)
        {
            // Stop the thread from running
            CancelInvoke("SpawnObject");
        }
    }
}
