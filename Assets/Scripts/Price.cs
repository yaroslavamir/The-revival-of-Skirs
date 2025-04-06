using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Price : MonoBehaviour
{
    public string ProductName { get; private set; }
    public float Cost { get; private set; }

    public Price(string productName, float cost)
    {
        ProductName = productName;
        Cost = cost;
    }
}

public class ProductPrices : MonoBehaviour
{
    public Price Bread, GreenApple, RedApple, Meat, Rice;
    void Start()
    {
        Bread = new Price("Bread", 2);
        GreenApple = new Price("Green Apple", 1);
        RedApple = new Price("Red Apple", 1);
        Meat = new Price("Meat", 5);
        Rice = new Price("Rice", 3);
    }
}
