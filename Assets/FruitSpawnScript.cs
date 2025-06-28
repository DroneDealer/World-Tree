using UnityEngine;

public class FruitSpawnScript : MonoBehaviour
{
    public FruitWeight[] fruits;
    public float spawnRate = 2;
    private float timer = 0;
    public float widthOffset = 14;

    // Update is called once per frame
    void Update()
    {
        if (fruits == null || fruits.Length == 0)
            return;

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
        if (fruits.Length == 0) return;

        float totalWeight = 0f;
        foreach (var f in fruits)
        {
            totalWeight += f.weight;
        }
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        foreach (var f in fruits)
        {
            cumulativeWeight += f.weight;
            if (randomValue <= cumulativeWeight)
            {
                float leftmostPoint = transform.position.x - widthOffset;
                float rightmostPoint = transform.position.x + widthOffset;
                Vector3 spawnPosition = new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0f);
                Instantiate(f.fruitPrefab, spawnPosition, Quaternion.identity);
                return;
            }
        }
    }
}
