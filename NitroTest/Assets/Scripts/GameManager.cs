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
        GameManager.InventoryForChar.add(new Rifle());
        GameManager.InventoryForChar.add(new Gun());
        GameManager.InventoryForChar.add(new Rifle());
        GameManager.InventoryForChar.add(new Gun());
        GameManager.InventoryForChar.add(new Rifle());
        GameManager.InventoryForChar.add(new Gun());

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
}
