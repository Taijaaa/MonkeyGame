using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float moveStepY = 2f;
    public float moveStepX = 2f;
    public float minY = -4f;
    public float maxY = 4f;
    public float minX = -4f;
    public float maxX = 4f;

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
}
