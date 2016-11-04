using UnityEngine;
using System.Collections;

abstract public class Item {

	public enum ItemType
    {
        Enhancements,
        Weapon
    };

    public ItemType TypeOfItem;
    private int Amount;


}
