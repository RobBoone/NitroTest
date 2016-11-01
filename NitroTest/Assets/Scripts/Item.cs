using UnityEngine;
using System.Collections;

abstract public class Item {

	enum ItemType
    {
        Enhancements,
        Weapon
    };

    private ItemType TypeOfItem;
    private int Amount;


}
