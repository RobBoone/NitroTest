using UnityEngine;
using System.Collections;
using System;

public class Persuader : Weapon {

    override public int Ammo { get; set; }
    override public int ReloadTime { get; set; }

    public override int Damage{ get; set;}

    override public void ShootBehaviour(GameObject enemy, float shoot)
    {

    }
}
