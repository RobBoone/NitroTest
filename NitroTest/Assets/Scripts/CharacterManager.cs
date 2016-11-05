using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{


    public List<GameObject> CharList = new List<GameObject>();

    public List<GameObject> EnemyList = new List<GameObject>();

    public GameObject SelectedChar;

    private VisualCharacter scriptOfSelectedChar;
    public int SelectedCharNumber = 0;

    public bool FollowMode = true;
    // Use this for initialization
    public CharacterManager()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int a = 0; a < 2; a++)
            {
                var caps = GameObject.Instantiate(Resources.Load("Prefabs/PlayerAgent"), new Vector3(2 * i, 5, 2 * a), Quaternion.identity) as GameObject;
                CharList.Add(caps);
            }

        }
        

        SelectedChar = CharList[SelectedCharNumber];
        scriptOfSelectedChar = SelectedChar.GetComponent<VisualCharacter>();
       
    }

    // Update is called once per frame
    public void Update()
    {
        if (FollowMode)
        {
            foreach (var k in CharList)
            {
                if (k != SelectedChar)
                {
                    if (Vector3.Distance(k.transform.position, SelectedChar.transform.position) > 2.5f)
                    {
                        VisualCharacter CharScript = k.GetComponent<VisualCharacter>();
                        CharScript.Move(SelectedChar.transform.position);
                    }
                }
            }
        }
    }


    public void updateSelected(float horizontal, float vertical, float shoot)
    {


        Vector3 moveDirection = Vector3.zero;

        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())       //This checks if pointer is hovering over ui element to avoid raycasting when hovering over ui
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Level"))
                {
                    if (shoot > 0)
                        scriptOfSelectedChar.Move(hit.point);
                }
                else if (hit.transform.CompareTag("Enemy"))
                    scriptOfSelectedChar.Shoot(hit.transform.gameObject, shoot);

            }
        }




    }

    public void Switch()
    {
        if (SelectedCharNumber < 3)
            SelectedCharNumber++;
        else
            SelectedCharNumber = 0;

        SelectedChar = CharList[SelectedCharNumber];
        scriptOfSelectedChar= SelectedChar.GetComponent<VisualCharacter>(); 
        GameManager.UiMan.HudPanel.UpdateText();
    }

    public void SwitchByID(int Id)
    {
        SelectedChar = CharList[Id];
        SelectedCharNumber = Id;
        scriptOfSelectedChar = SelectedChar.GetComponent<VisualCharacter>(); 
        GameManager.UiMan.HudPanel.UpdateText();
    }


    public void ApplyItem(Item item)
    {
        if (item.TypeOfItem == Item.ItemType.Weapon)
            ChangeWeapon(item as Weapon);
        else if (item.TypeOfItem == Item.ItemType.Enhancements)
            ApplyEnhancment(item as Enhancements);

        GameManager.UiMan.CharPanel.Refresh();
    }

    public void ChangeWeapon(Weapon wep)
    {
        scriptOfSelectedChar.WeaponOfChar = wep;
        Debug.Log("wepswitch");

        GameManager.UiMan.HudPanel.UpdateText();
    }

    public void ApplyEnhancment(Enhancements enhancement )
    {
        switch(enhancement.TypeOfEnhancement)
        {
            case Enhancements.EnhancementType.Att:
                scriptOfSelectedChar.charProperties.IncreaseAtt();
                break;
            case Enhancements.EnhancementType.Def:
                scriptOfSelectedChar.charProperties.IncreaseDef();
                break;
            case Enhancements.EnhancementType.hp:
                scriptOfSelectedChar.charProperties.IncreaseHp();
                break;
        }
    }

    public void FollowRemainMode()
    {
        if (FollowMode)
            FollowMode = false;
        else
            FollowMode = true;

        GameManager.UiMan.HudPanel.UpdateText();
    }
}