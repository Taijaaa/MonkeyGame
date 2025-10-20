using UnityEngine;
using TMPro;

public class BananaPickup : MonoBehaviour
{
    public int points = 1;
    public static int Score = 0;

    // Use TextMeshProUGUI for UI Text on Canvas
    public TextMeshProUGUI scoreText;

    // COLLISION VERSION: both colliders are NOT triggers
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        Score += points;
        updateScoreText();
        Destroy(gameObject);
    }


    void updateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Bananas: " + Score;
    }
}