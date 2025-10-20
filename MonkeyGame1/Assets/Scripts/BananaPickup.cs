using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    // how many points this banana gives (golden = 5, normal = 1)
    public int points = 1;

    // super simple static score counter (replace later with your actual score system)
    public static int Score = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        // make sure it’s the player grabbing the banana
        if (!other.CompareTag("Player")) return;

        // give points and destroy the banana
        Score += points;
        Destroy(gameObject);
    }
}