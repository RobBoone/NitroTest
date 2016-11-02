using UnityEngine;
using System.Collections;

public class Rifle : Weapon {

    override public int Ammo { get; set; }
    override public int ReloadTime { get; set; }


    override public void ShootBehaviour(GameObject enemy, float shoot)
    {

    }
}
