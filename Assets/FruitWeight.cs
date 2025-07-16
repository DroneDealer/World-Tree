using UnityEngine;

[System.Serializable]
public struct FruitWeight
{
    public GameObject fruitPrefab;
    public float weight;
}
// Thought of combining FruitWeight and FruitScript but chose to keep them separate because one is a predestiend spawn rate and the other really only comes into play when you grab a fruit - its running is conditional, while the fruit weight is not.
// I probably could have combined this with FrutiSpawnScript but it didn't seem so important to do so. Also the fruit spawn cript is attached to a game object offscreen and I have to attach the fruit weight to each fruit