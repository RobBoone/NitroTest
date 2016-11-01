using UnityEngine;
using System.Collections;

abstract public class Weapon : Item {

    abstract public int Ammo { get; set; }
    abstract public int ReloadTime { get; set; }


}
