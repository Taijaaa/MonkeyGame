using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{

    public GameObject coconutPrefab;
    public Transform[] spawnPoints;
    public float minDelay = 1.5f;
    public float maxDelay = 4f;
    public float resetY = -6f;
    public float gravityScale = 3f;

    private GameObject[] coconuts;
    private float[] timers;
    private float[] delays;
    private Vector3[] startPositions;

    // Start is called before the first frame update
    void Start()
    {
        int n = spawnPoints.Length;
        coconuts = new GameObject[n];
        timers = new float[n];
        delays = new float[n]; 
        startPositions = new Vector3[n];

        for (int i = 0; i < n; i++)
        {
            startPositions[i] = spawnPoints[i].transform.position;
            SpawnOne(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < coconuts.Length; i++)
        {
            if (coconuts[i] == null) SpawnOne(i);

            timers[i] += Time.deltaTime;

            // waiting until the delay is reached and then dropping the coconut
            if (timers[i] >= delays[i])
            {
                coconuts[i].GetComponent<Rigidbody2D>().gravityScale = gravityScale;

            }

            // respawn if it falls below the screen
            if (coconuts[i].transform.position.y < resetY)
            {
                Destroy(coconuts[i]);
            }
        }


    }

    void SpawnOne(int i)
    {
        coconuts[i] = Instantiate(coconutPrefab, startPositions[i], Quaternion.identity);
        Rigidbody2D rb = coconuts[i].GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // start frozen 
        timers[i] = 0f; 
        delays[i] = Random.Range(minDelay, maxDelay);
    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}


