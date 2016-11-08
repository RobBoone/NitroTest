using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{


    public List<GameObject> CharList = new List<GameObject>();

    public List<GameObject> EnemyList = new List<GameObject>();

    public List<GameObject> PersuadeList = new List<GameObject>();

    public List<GameObject> PedestrianList = new List<GameObject>();

    public GameObject SelectedChar;
    private float timer=0;
    private VisualCharacter scriptOfSelectedChar;
    public int SelectedCharNumber = 0;
    public int Kills = 0;
    public bool FollowMode = true;
    // Use this for initialization
    public CharacterManager()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int a = 0; a < 2; a++)
            {
                var obj = GameObject.Instantiate(Resources.Load("Prefabs/PlayerAgent"), new Vector3(2 * i, 5, 2 * a), Quaternion.identity) as GameObject;
                CharList.Add(obj);
            }

        }
  
        for (int i = 0; i < 8; i++)
        {
            var obj = GameObject.Instantiate(Resources.Load("Prefabs/EnemyAgent"), RandomPosition(25,50), Quaternion.identity) as GameObject;
            EnemyList.Add(obj);
        }

        for (int i = 0; i < 8; i++)
        {
            var obj = GameObject.Instantiate(Resources.Load("Prefabs/PedestrianAgent"), RandomPosition(10,50), Quaternion.identity) as GameObject;
            PedestrianList.Add(obj);
        }


        SelectedChar = CharList[SelectedCharNumber];
        scriptOfSelectedChar = SelectedChar.GetComponent<VisualCharacter>();
       
    }


    public void Update()
    {
        if (FollowMode)
        {
            if(CharList.Count!=0)
            LoopAndMove(CharList);

            LoopAndMove(PersuadeList);
        }

        PedestrianMove();


    }

    //movement and shooting
    public void UpdateSelected(float shoot)
    {

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


    //switch to next character in charList
    public void Switch()
    {
        if (SelectedCharNumber < CharList.Count-1)
            SelectedCharNumber++;
        else
            SelectedCharNumber = 0;
            
            SelectedChar = CharList[SelectedCharNumber];
            scriptOfSelectedChar = SelectedChar.GetComponent<VisualCharacter>();
        GameManager.UiMan.HudPanel.UpdateText();
    }

    //switch to character by id
    public void SwitchByID(int Id)
    {
        
            if(Id<CharList.Count)
            SelectedChar = CharList[Id];
            SelectedCharNumber = Id;
            scriptOfSelectedChar = SelectedChar.GetComponent<VisualCharacter>();
        
        GameManager.UiMan.HudPanel.UpdateText();
    }

    //equip item from inventory
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

        GameManager.UiMan.HudPanel.UpdateText();
    }

    public void ApplyEnhancment(Enhancements enhancement )
    {
        switch(enhancement.TypeOfEnhancement)
        {
            case Enhancements.EnhancementType.Att:
                scriptOfSelectedChar.CharProperties.IncreaseAtt();
                break;
            case Enhancements.EnhancementType.Def:
                scriptOfSelectedChar.CharProperties.IncreaseDef();
                break;
            case Enhancements.EnhancementType.hp:
                scriptOfSelectedChar.CharProperties.IncreaseHp();
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

    //Checks if someone died only gets called when someones health goes below 0
    public void CheckHp()
    {
        LoopAndCheckHp(CharList);
        LoopAndCheckHp(EnemyList);
        LoopAndCheckHp(PersuadeList);
    }
    //Checks if someone was persuade only called when syndicatelevel is above a hundred
    public void CheckSyndicate()
    {
        LoopAndCheckSyndicate(EnemyList);
    }

    private void LoopAndCheckHp(List<GameObject> list)
    {
        if (list.Count != 0)
        {
            GameObject tempObj = new GameObject();
            foreach (var k in list)
            {
                VisualCharacter charScript = k.GetComponent<VisualCharacter>();
                if (charScript.CharProperties.Hp < 0)
                {
                    if (k == SelectedChar&&CharList.Count>1)
                        Switch();

                    tempObj = k;

                    var obj =
                        GameObject.Instantiate(Resources.Load("Prefabs/ItemDrop"), tempObj.transform.position,
                            Quaternion.identity) as GameObject;
                    break;
                }
            }
            if (tempObj.CompareTag("Enemy"))
                Kills++;
            list.Remove(tempObj);
            GameObject.Destroy(tempObj);

            GameManager.UiMan.CharPanel.Refresh();
        }
    }

    private void LoopAndCheckSyndicate(List<GameObject> list)
    {

        if (list.Count != 0)
        {
            GameObject tempObj = new GameObject();
            foreach (var k in list)
            {
                VisualCharacter charScript = k.GetComponent<VisualCharacter>();
                if (charScript.CharProperties.SyndicateLevel > 100)
                {

                    PersuadeList.Add(k);
                    tempObj = k;
                }
            }

                list.Remove(tempObj);
        }

    }

    private void LoopAndMove(List<GameObject> list)
    {
        
            foreach (var k in list)
            {
                if(SelectedChar!=null)
                if (k != SelectedChar)
                {
                    if (Vector3.Distance(k.transform.position, SelectedChar.transform.position) > 2.5f)
                    {
                        k.GetComponent<VisualCharacter>().Move(SelectedChar.transform.position);
                    }
                }
            }
        
    }

    private Vector3 RandomPosition(int rangeA, int rangeB)
    {
        int a = Random.Range(-1, 2);
        int b = Random.Range(-1, 2);
        if (a == 0)
            a++;

        if (b == 0)
            b++;

        return new Vector3(a * Random.Range(rangeA, rangeB), 5, b * Random.Range(rangeA, rangeB));

    }

    //Pedestrians walk around in the scene
    private void PedestrianMove()
    {

        if (timer > 12)
        {
            
            foreach (var k in PedestrianList)
            {            
                    k.GetComponent<VisualCharacter>().Move(RandomPosition(10,60));   
            }
            timer = 0;
        }

        timer += Time.deltaTime;
    }

}