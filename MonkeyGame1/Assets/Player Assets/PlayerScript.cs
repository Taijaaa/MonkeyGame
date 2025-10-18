using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float moveStepY = 5f;
    public float moveStepX = 6f;
    public float minY = 0f;
    public float maxY = 15f;
    public float minX = -12f;
    public float maxX = 16f;

    public int maxBananas = 10;

    private int lives = 3;
    private int collectedBananas = 0;
    


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
            Debug.Log("Lives left: " + lives);

            if (lives <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }

        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            collectedBananas++;
            Debug.Log("Total Bananas: " +  collectedBananas);

            if (collectedBananas >= maxBananas)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
