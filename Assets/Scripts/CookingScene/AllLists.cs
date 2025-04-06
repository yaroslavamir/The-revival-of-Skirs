using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLists : MonoBehaviour
{
    public DishDatabase dishDatabase;
    public Dictionary<string, List<string>> recipes = new Dictionary<string, List<string>>()
    {
        { "DefaultDish", new List<string> { "Egg", "Bread" } },
        { "Bird-Curd", new List<string> { "Kyrka", "Cheese" } },
        { "TasteMeSoftly", new List<string> { "Egg", "Meat" } },
        { "Fin&Cheese", new List<string> { "FishSteak", "Cheese" } },
        // { "AnotherApple-lyCheesy", new List<string> { "GreenApple", "Cheese" } },
        { "Apple-lyCheesy", new List<string> { "RedApple", "Cheese" } },
        { "SayCheese..Toast", new List<string> { "Bread", "Cheese" } },
        { "TwinApple", new List<string> { "GreenApple", "RedApple" } },
        // { "Earth&FireMedley", new List<string> { "Mushroom", "Meat", "Rice" } },
        // { "ApplewoodRoyale", new List<string> { "GreenApple", "Meat", "Cheese" } },
        // { "WildRoosterRisotto", new List<string> { "Rice", "Kyrka", "Mushroom" } },
        // { "SunriseSupreme", new List<string> { "Egg", "Mushroom", "MisterPomidorka" } },
        // { "Tomatatomata", new List<string> { "MisterPomidorka", "MisterPomidorka", "MisterPomidorka", "MisterPomidorka" } },
        // { "DeliciousSusi", new List<string> { "FishSteak", "Rice" } },
        // { "MeatBoy", new List<string> { "Meat", "Meat", "Meat", "Meat" } },
        // { "Guzzler", new List<string> { "Meat", "Ham", "Kyrka", "MisterPomidorka" } },
        // { "EnchantedGoldenApple", new List<string> { "RedApple", "Cheese", "Egg" } },
        // { "RedDeadRibs", new List<string> { "Meat", "Mushroom", "MisterPomidorka" } },
        // { "SanAndreasSpecial", new List<string> { "Kyrka", "Rice", "MisterPomidorka" } },
        // { "DoomSlayersSnack", new List<string> { "Meat", "Kyrka", "Rice" } },
        // { "KongsJungleToast", new List<string> { "Bread", "RedApple", "Cheese" } },
        // { "TurboDriftFuel", new List<string> { "Egg", "GreenApple", "Bread" } },
        // { "TetrisTower", new List<string> { "Kyrka", "Rice", "Mushroom" } }
    };

    public Dictionary<string, List<string>> ingredients = new Dictionary<string, List<string>>()
    {
        { "BreadSlise", new List<string> { "Slise", "Bread"} },
        { "BreadToast", new List<string> { "Toast", "BreadSlise"} },
        { "GreenAppleSlise", new List<string> { "Slise", "GreenApple"} },
        { "RedAppleSlise", new List<string> { "Slise", "RedApple"} },
        // { "FishFried", new List<string> { "Fried", "Fish"} },
        { "MeatFried", new List<string> { "Fried", "Meat"} },
        // { "KyrkaFried", new List<string> { "Fried", "Kyrka"} },
        // { "MushroomSlise", new List<string> { "Slise", "Mushroom"} },        
        // { "HamFried", new List<string> { "Fried", "Ham"} },        
        // { "MisterPomidorkaSlise", new List<string> { "Slise", "MisterPomidorka"} },
        { "RiceBoiled", new List<string> { "Boiled", "Rice"} },
        // { "EggFried", new List<string> { "Fried", "Egg"} }
    };

    public Dictionary<string, int> prices = new Dictionary<string, int>()
    {
        { "Bread", 1},
        { "GreenApple", 2},
        { "RedApple", 2},
        { "FishSteak", 3},
        { "Meat", 4},
        { "Kyrka", 5},
        { "Mushroom", 1},
        { "Rice", 1},
        { "Egg", 1},
        { "Ham", 2},
        { "MisterPomidorka", 1},
        { "Cheese", 2},
        { "BreadSlise", 3}
    };
}
