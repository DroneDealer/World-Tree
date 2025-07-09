using System.Collections;
using UnityEngine;

public class BasicMovements : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    private bool IsDead = false;
    private SpriteRenderer spriteRenderer;
    private bool _autoWalking;
    public bool AutoWalking
        {
            get => _autoWalking;
            set
            {
                _autoWalking = value;
                Debug.Log($"[AutoWalking SET] New value: {_autoWalking}");
            }
        }
    public Transform shopEntranceTarget;
    void Start()
    {
        Debug.Log($"[BasicMovements] Start on: {gameObject.name}, instance ID: {GetInstanceID()}");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Debug.Log("Update running");
        Debug.Log($"[Update] AutoWalking: {AutoWalking}, Target null? {shopEntranceTarget == null}");
        Debug.Log($"Update running - AutoWalking: {AutoWalking}, Target: {shopEntranceTarget}");
        if (IsDead)
        {
            return;
        }
        if (AutoWalking && shopEntranceTarget == null)
        {
            Debug.LogWarning("AutoWalking is true but shopEntranceTarget is STILL null!");
        }
        //Debug.Log("AutoWalking: " + AutoWalking);
        //Debug.Log("shopEntranceTarget: " + (shopEntranceTarget != null));
        if (AutoWalking && shopEntranceTarget != null)
        {
            Debug.Log("Autowalking block running");
            Vector3 TargetPos = new Vector3(shopEntranceTarget.position.x, transform.position.y, transform.position.z);
            Debug.Log($"Target position: {TargetPos}, Player position: {transform.position}");
            if (TargetPos.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else if (TargetPos.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            animator.SetFloat("Speed", 1f);
            Debug.Log($"Moving player from {transform.position} towards {TargetPos}");

            transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
            Debug.Log("player is autowalking");
            if (Vector3.Distance(transform.position, TargetPos) < 0.15f)
            {
                Debug.Log("Re3ached shop entrance");
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
            Debug.Log($"Checking object: {obj.name} with tag: {obj.tag}");
            if (obj.CompareTag("GameController") || obj.CompareTag("GameOverUI") || obj.CompareTag("MainCamera") || obj.name == "EventSystem" || obj.CompareTag("ShopWindowUI") || obj.CompareTag("Player") || obj.name == "ShopWindow")
            {
                Debug.Log($"Skipping: {obj.name}");
                continue;
            }
            if (obj != gameObject)
            {
                Debug.Log($"Disabling: {obj.name}");
                obj.SetActive(false);
            }
        }
        FindObjectOfType<GameOver>().GameOverNow();
    }
}
