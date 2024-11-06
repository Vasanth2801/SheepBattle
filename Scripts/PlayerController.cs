using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
  
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

   
    public int playerNumber; 
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreUI();
    }

    private void Update()
    {
        HandleMovement();
    }

    
    private void HandleMovement()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (playerNumber == 1) // Sheep (Arrow keys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else if (playerNumber == 2) // Cat (WASD keys)
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            score++;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}
