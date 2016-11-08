using UnityEngine;
using System.Collections;

public class Gun : Weapon {

	// Use this for initialization
	override public int Ammo{get;set;}
    override public int ReloadTime { get; set; }
    override public int Damage { get; set; }

    private bool oneShot = false;

    public Gun()
    {
        TypeOfItem = ItemType.Weapon;
        Damage = 10;
    }

    override public void ShootBehaviour(GameObject enemy, float shoot, float charDamage)
    {

        if (shoot > 0 && oneShot == false)
            oneShot = true;
        else if (shoot == 0)
            oneShot = false;
        else
            return;
        
        if (oneShot)
        {
            enemy.GetComponent<VisualCharacter>().HitCharacter(charDamage);
        }
  
    }
}
