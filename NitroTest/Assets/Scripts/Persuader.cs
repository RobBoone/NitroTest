using UnityEngine;
using System.Collections;
using System;

public class Persuader : Weapon {

    override public int Ammo { get; set; }
    override public int ReloadTime { get; set; }

    public override int Damage{ get; set;}
    private float timer = 0.0f;


    public Persuader()
    {
        TypeOfItem = ItemType.Weapon;
        Damage = 10;
    }
    override public void ShootBehaviour(GameObject enemy, float shoot, float charDamage)
    {
        if (shoot > 0)
        {
            if (timer > 0.4f)
            {
                enemy.GetComponent<VisualCharacter>().charProperties.Persuade(Damage);
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }
}
