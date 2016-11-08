using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {
    public List<Item> InventoryList;
    public Inventory()
    {
        InventoryList = new List<Item>();
    }


    public void add(Item k)
    {
        InventoryList.Add(k);
        GameManager.UiMan.InvPanel.Refresh();
    }


    public void Remove(Item k)
    {
        InventoryList.Remove(k);

    }

}
