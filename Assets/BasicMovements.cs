using System.Collections;
using UnityEngine;

public class BasicMovements : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    private bool IsDead = false;
    private SpriteRenderer spriteRenderer;
    public bool AutoWalking = false;
    public Transform shopEntranceTarget;
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
        if (AutoWalking && shopEntranceTarget != null)
        {
            Vector3 TargetPos = new Vector3(shopEntranceTarget.position.x, transform.position.y, transform.position.z);
            if (TargetPos.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else if (TargetPos.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            } 
            animator.SetFloat("Speed", 1f);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, TargetPos) < 0.05f)
            {
                AutoWalking = false;
                animator.SetFloat("Speed", 0f);
                FindObjectOfType<ShopWindow>().showShop();
            }
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
        if (IsDead)
        {
            return;
        }
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
            if (obj.CompareTag("GameController") || obj.CompareTag("GameOverUI") || obj.CompareTag("MainCamera") || obj.name == "EventSystem")
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
