using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public int scoreValue = 1;
    public bool IsBadFruit = false;
    public LogicScript Logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsBadFruit)
        {
            Logic.LoseLife();
        }
        else
        {
            Logic.addScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
