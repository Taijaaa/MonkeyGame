using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public Transform[] spawnSpots;
    public GameObject bananaPrefab;
    public GameObject goldenBananaPrefab;

    [Header("Timing Settings")]
    public float spawnEverySeconds = 1.5f;
    public float goldenChance = 0.3f;

    [Header("Golden Frenzy Settings")]
    public float frenzyDuration = 5f;
    public float frenzySpawnRate = 0.3f; // spawn faster during frenzy

    private float timer;
    private float frenzyEnd;
    private bool inFrenzy = false;

    void Update()
    {
        timer += Time.deltaTime;
        float currentSpawnRate = inFrenzy ? frenzySpawnRate : spawnEverySeconds;

        if (timer < currentSpawnRate) return;
        timer = 0f;

        // Check if frenzy should end
        if (inFrenzy && Time.time > frenzyEnd)
            inFrenzy = false;

        SpawnOne();
    }

    void SpawnOne()
    {
        if (spawnSpots.Length == 0) return;

        Transform spot = spawnSpots[Random.Range(0, spawnSpots.Length)];

        bool spawnGolden;

        if (inFrenzy)
        {
            // During frenzy, always spawn golden bananas
            spawnGolden = true;
        }
        else
        {
            spawnGolden = Random.value < goldenChance && goldenBananaPrefab != null;
        }

        GameObject prefab = spawnGolden ? goldenBananaPrefab : bananaPrefab;
        if (!prefab) return;

        Instantiate(prefab, spot.position, Quaternion.identity);

        // If a golden banana spawns outside of frenzy, trigger frenzy
        if (!inFrenzy && spawnGolden)
        {
            inFrenzy = true;
            frenzyEnd = Time.time + frenzyDuration;
        }
    }
}
