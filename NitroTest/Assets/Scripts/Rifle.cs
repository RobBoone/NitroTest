using UnityEngine;
using System.Collections;

public class Rifle : Weapon {

    override public int Ammo { get; set; }
    override public int ReloadTime { get; set; }
    override public int Damage { get; set; }

    private float timer = 0.0f;

    public Rifle()
    {
        TypeOfItem = ItemType.Weapon;
        Damage =8;
    }

    override public void ShootBehaviour(GameObject enemy, float shoot)
    {
        if (shoot > 0)
        {
            if (timer > 0.2f)
            {
                enemy.GetComponent<VisualCharacter>().charProperties.Hit(Damage);
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }
}
