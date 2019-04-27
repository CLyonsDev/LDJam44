using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory/", menuName = "New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> ItemList = new List<Item>();
    public static Inventory _instance;

    public void AddItem(Item i)
    {
        ItemList.Add(i);
    }

    public void RemoveItem(Item i)
    {
        ItemList.Remove(i);
    }

    public void Clear()
    {
        ItemList.Clear();
    }
}
