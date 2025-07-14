using System.Collections;
using UnityEngine;

public class BasicMovements : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    private bool IsDead = false;
    private SpriteRenderer spriteRenderer;
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
        Debug.Log("Die called. IsDead param set to true");

        animator.Play("DeathAnimation", 0, 0f);
        Debug.Log("Forced animation play");

        speed = 0f;
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
        yield return new WaitForSeconds(1f);

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("GameController") || obj.CompareTag("GameOverUI") || obj.CompareTag("MainCamera") || obj.name == "EventSystem" || obj.CompareTag("WorldTreeUI") || obj.CompareTag("Managers"))
            {
                continue;
            }
            if (obj != gameObject)
            {
                obj.SetActive(false);
            }
        }
        gameObject.SetActive(false);

        FindObjectOfType<GameOver>().GameOverNow();
    }
}