using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 3;
    private int currentHealth;

    private Rigidbody2D myRigidbody;
    private Vector2 moveInput;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Movimiento del jugador
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        // Aplicar movimiento
        myRigidbody.linearVelocity = moveInput * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        // Implementar lógica adicional para el fin del juego
    }
}
