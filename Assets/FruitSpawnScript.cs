using UnityEngine;

public class FruitSpawnScript : MonoBehaviour
{
    public GameObject[] fruits;
    public float spawnRate = 2;
    private float timer = 0;
    public float widthOffset = 14;

    void Start()
    {
        spawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            //equiavlent to timer = timer + Time.deltaTime;
        }
        else
        {
            spawnFruit();
            timer = 0;
        }
    }
    void spawnFruit()
    {
        float leftmostPoint = transform.position.x - widthOffset;
        float rightmostPoint = transform.position.x + widthOffset;
        int index = Random.Range(0, fruits.Length);
        GameObject chosenFruit = fruits[index];
        Instantiate(chosenFruit, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation);
    }
}
