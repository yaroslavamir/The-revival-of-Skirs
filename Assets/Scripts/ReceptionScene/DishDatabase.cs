using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dish
{
    public string name;
    public string description;
    public int price;
    public float timeForWait; //під питанням
    public GameObject[] ingredients;
}

[CreateAssetMenu(fileName = "DishDatabase", menuName = "Game/Dish Database")]
public class DishDatabase : ScriptableObject
{
    public List<Dish> dishes = new List<Dish>();
}

