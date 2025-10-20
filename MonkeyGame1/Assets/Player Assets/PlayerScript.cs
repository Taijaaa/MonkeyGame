using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float moveStepY = 5f;
    public float moveStepX = 6f;
    public float minY = 0f;
    public float maxY = 15f;
    public float minX = -12f;
    public float maxX = 16f;
    public int bananas = 0;

    private int lives = 3;

    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesText();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pos.y + moveStepY <= maxY)
                pos.y += moveStepY;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pos.y -= moveStepY;

            if (pos.y < minY)
            {
                SceneManager.LoadScene("LoseScreen");
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pos.x - moveStepX >= minX)
                pos.x -= moveStepX;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pos.x + moveStepX <= maxX)
                pos.x += moveStepX;
        }

        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coconut"))
        {
            Destroy(collision.gameObject);
            lives--;
            UpdateLivesText();
            Debug.Log("Lives left: " + lives);

            if (lives <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }

    }
  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Banana"))
        {
            Destroy(other.gameObject);
            bananas++;
            Debug.Log("banana: " + bananas);

            if (bananas >= 30000000)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }



}
