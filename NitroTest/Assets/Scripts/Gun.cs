using UnityEngine;
using System.Collections;

public class Gun : Weapon {

	// Use this for initialization
	override public int Ammo{get;set;}
    override public int ReloadTime { get; set; }
    override public int Damage { get; set; }

    private bool OneShot = false;

    public Gun()
    {
        TypeOfItem = ItemType.Weapon;
        Damage = 10;
    }

    override public void ShootBehaviour(GameObject enemy, float shoot, float charDamage)
    {

        if (shoot > 0 && OneShot == false)
            OneShot = true;
        else if (shoot == 0)
            OneShot = false;
        else
            return;
        
        if (OneShot)
        {
            enemy.GetComponent<VisualCharacter>().charProperties.Hit(charDamage);
        }
  
    }
}
