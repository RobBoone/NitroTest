using UnityEngine;
using System.Collections;

public class Character {

    //private string Name;
    private float Hp;
    private float Att;
    private float Def;

    private VisualCharacter CharVisualObj;

    // Use this for initialization
    public Character(float hp, float att, float def)
    {
        Hp = hp;
        Att = att;
        Def = def;

	}
	
	// Update is called once per frame
	public void Hit(float amount)
    {
        Hp -= amount - (amount / Def);
        Debug.Log(Hp);
    }

    public void SetAtt(float amount)
    {
        Att = amount;
    }

    public float GetHp()
    {
        return Hp;
    }


   
}
