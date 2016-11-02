using UnityEngine;
using System.Collections;

public class Gun : Weapon {

	// Use this for initialization
	override public int Ammo{get;set;}
    override public int ReloadTime { get; set; }

    private bool OneShot = false;

    override public void ShootBehaviour(GameObject enemy, float shoot)
    {

        if (shoot > 0 && OneShot == false)
            OneShot = true;
        else if (shoot == 0)
            OneShot = false;
        else
            return;
        
        if (OneShot)
        {
            Debug.Log("shoot");
        }
  
    }
}
