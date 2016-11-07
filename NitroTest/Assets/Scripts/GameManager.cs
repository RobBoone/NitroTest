using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static Inventory InventoryForChar;
    public static CharacterManager CharMan;
    public static UIManager UiMan;
    // Use this for initialization
    void Start () {
        InventoryForChar = new Inventory();
       
        CharMan = new CharacterManager();
        UiMan = new UIManager();
        

        GameManager.InventoryForChar.add(new Rifle());
        GameManager.InventoryForChar.add(new Gun());
        GameManager.InventoryForChar.add(new Enhancements(Enhancements.EnhancementType.Att));
        GameManager.InventoryForChar.add(new Enhancements(Enhancements.EnhancementType.Def));
        GameManager.InventoryForChar.add(new Enhancements(Enhancements.EnhancementType.hp));

        UiMan.EnableDisableCharPanel();
        UiMan.EnableDisableInventory();
    }
	
	// Update is called once per frame
	void Update () {

        CheckForInput();
        CharMan.Update();
    }

    void CheckForInput()
    {
        float shoot = Input.GetAxis("Fire1");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        CharMan.updateSelected(horizontal, vertical, shoot);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CharMan.Switch();
            
        }


        if (Input.GetKeyDown(KeyCode.U))
        {

            UiMan.EnableDisableCharPanel();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UiMan.EnableDisableInventory();
        }

    }


    static public void PickupItem()
    {
        int rand = Random.RandomRange(0, 4);
        switch (rand)
        {
            case 0:
                GameManager.InventoryForChar.add(new Gun());
                break;
            case 1:
                GameManager.InventoryForChar.add(new Rifle());
                break;
            case 2:
                GameManager.InventoryForChar.add(new Enhancements(Enhancements.EnhancementType.Att));
                break;
            case 3:
                GameManager.InventoryForChar.add(new Enhancements(Enhancements.EnhancementType.Def));
                break;
            case 4:
                GameManager.InventoryForChar.add(new Enhancements(Enhancements.EnhancementType.hp));
                break;
        }
            
    }
}
