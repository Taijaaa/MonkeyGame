using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    [Header("Banana Settings")]
    public int points = 1;       // normal banana = 1, golden = more

    [Header("Pickup Settings")]
    public bool isGolden = false;
    public AudioClip pickupSound;

    private void Start()
    {
        if (isGolden)
            points = 3; // bonus for golden bananas
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // Add points through ScoreManager
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddPoints(points);

        // Play sound if assigned
        if (pickupSound)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        // Destroy collected banana
        Destroy(gameObject);
    }
}
