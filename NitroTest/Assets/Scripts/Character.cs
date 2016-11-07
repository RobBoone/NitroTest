using UnityEngine;
using System.Collections;

public class Character {

    //private string Name;
    public float Hp;
    public float Att;
    public float Def;
    public float SyndicateLevel;
    bool syndicateSquad = false;
    // Use this for initialization
    public Character(float hp, float att, float def,float synd)
    {
        Hp = hp;
        Att = att;
        Def = def;
        SyndicateLevel = synd;
    }
	
	// Update is called once per frame
	public void Hit(float amount)
    {
        Hp -= amount - (amount / Def);
        //Debug.Log(Hp);
        if (Hp < 0)
            GameManager.CharMan.CheckHp();

        GameManager.UiMan.CharPanel.Refresh();
    }
    public void Persuade(float amount)
    {
        if (!syndicateSquad)
        {
            SyndicateLevel += amount;
            //Debug.Log(Hp);
            if (SyndicateLevel > 100)
            {
                GameManager.CharMan.CheckSyndicate();
                syndicateSquad = true;
            }

            GameManager.UiMan.CharPanel.Refresh();
        }
    }

    public void SetAtt(float amount)
    {
        Att = amount;
    }

    public void IncreaseAtt()
    {
        Att += 10;
    }

    public void IncreaseDef()
    {
        Def += 10;
    }

    public void IncreaseHp()
    {
        Hp += 10;
    }



}
