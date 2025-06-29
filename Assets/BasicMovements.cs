using System.Collections;
using UnityEngine;

public class BasicMovements : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
    public float speed = 5f;
    private bool IsDead = false;
    private SpriteRenderer spriteRenderer;

    // Update is called once per frame

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (IsDead)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }
        Vector3 horizontal = new Vector3(horizontalInput, 0f, 0f);
        transform.position = transform.position + horizontal * speed * Time.deltaTime;
    }

    public void Die()
    {
        Debug.Log("Die() called");
        if (IsDead) return;

        IsDead = true;
        animator.SetBool("IsDead", true);
        speed = 0f;
        animator.Play("DeathAnimation", 0, 0f);

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
        }
        StartCoroutine(DelayedGameOver());
    }
    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(10f);
        FindObjectOfType<GameOver>().GameOverNow();
    }
}
