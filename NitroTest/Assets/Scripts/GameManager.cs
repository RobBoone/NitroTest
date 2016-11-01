using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static Inventory InventoryForChar;
    private CharacterManager CharMan;
	// Use this for initialization
	void Start () {
        CharMan = new CharacterManager();


    }
	
	// Update is called once per frame
	void Update () {

        CheckForInput();
    }

    void CheckForInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       // Debug.Log(horizontal);

        if(horizontal==0.0f && vertical==0.0f)
            return;



        CharMan.updateSelected(horizontal, vertical);
    }
}
