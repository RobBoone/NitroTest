using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static Inventory InventoryForChar;
    public static CharacterManager CharMan;
    public static UIManager UiMan;
    private int startEnemycount;

    private int killGoals = 3;
    private int persuadeGoals = 1;
    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
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

        startEnemycount = CharMan.EnemyList.Count;
    }
	
	// Update is called once per frame
	void Update () {
        CheckForInput();
        CharMan.Update();
	    CheckObjective();
	}

    void CheckForInput()
    {
        float shoot = Input.GetAxis("Fire1");
        CharMan.UpdateSelected(shoot);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CharMan.Switch();
            
        }


        if (Input.GetKeyDown(KeyCode.U))
        {

            UiMan.EnableDisableCharPanel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UiMan.EnableDisableInventory();
        }

    }


    static public void PickupItem()
    {
        int rand = Random.Range(0, 4);
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


    private void CheckObjective()
    {
        if (killGoals <=CharMan.Kills && persuadeGoals <= CharMan.PersuadeList.Count)
        {
           var obj= GameObject.Instantiate(Resources.Load("Prefabs/WinCanvas")) as GameObject;
            Time.timeScale = 0;
        }

        if (CharMan.CharList.Count==0)
        {
            var obj = GameObject.Instantiate(Resources.Load("Prefabs/LoseCanvas")) as GameObject;
            Time.timeScale = 0;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Test");
    }
}
