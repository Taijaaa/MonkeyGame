using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    // these are the exact spots bananas can appear at (add all your vine points here)
    public Transform[] spawnSpots;

    // assign your normal banana prefab and golden banana prefab
    public GameObject bananaPrefab;
    public GameObject goldenBananaPrefab;

    // basic timing and rare golden chance
    public float spawnEverySeconds = 1.2f;
    public float goldenChance = 0.12f;

    // "banana storm" spawns a ton of bananas for a few seconds (press G to test)
    public int stormBananasPerTick = 5;
    public float stormDuration = 3f;

    float timer;
    float stormEnd;

    void Update()
    {
        // press G to trigger the storm just for fun
        if (Input.GetKeyDown(KeyCode.G))
            stormEnd = Time.time + stormDuration;

        timer += Time.deltaTime;
        if (timer < spawnEverySeconds) return;
        timer = 0f;

        // if storm is active, spawn a bunch, otherwise just one
        int count = Time.time < stormEnd ? stormBananasPerTick : 1;
        for (int i = 0; i < count; i++) SpawnOne();
    }

    void SpawnOne()
    {
        if (spawnSpots.Length == 0) return;

        // pick a random vine spot to drop a banana
        var spot = spawnSpots[Random.Range(0, spawnSpots.Length)];

        // decide if this one’s golden or not
        var prefab = (Random.value < goldenChance && goldenBananaPrefab)
            ? goldenBananaPrefab
            : bananaPrefab;

        if (!prefab) return;

        Instantiate(prefab, spot.position, Quaternion.identity);
    }
}