using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static Inventory InventoryForChar;
    public CharacterManager CharMan;
	// Use this for initialization
	void Start () {
        CharMan = new CharacterManager();


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

    }
}
