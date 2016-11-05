using UnityEngine;
using System.Collections;

abstract public class Weapon : Item {

    //public ItemType TypeOfItem= ItemType.Weapon;
    abstract public int Ammo { get; set; }
    abstract public int ReloadTime { get; set; }
    abstract public int Damage { get; set; }
    abstract public void ShootBehaviour(GameObject Enemy, float shoot, float charDamage);

    

}
