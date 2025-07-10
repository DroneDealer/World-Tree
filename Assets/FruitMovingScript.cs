using UnityEngine;

public class FruitMovingScript : MonoBehaviour
{
    public LogicScript Logic;
    public float moveSpeed = 3;
    public float deadZone = -3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            //'Debug.Log("Starfruit Deleted")' shows if the console is deleting things

            Destroy(gameObject);
            Logic.LoseLife();
        }
    }
}