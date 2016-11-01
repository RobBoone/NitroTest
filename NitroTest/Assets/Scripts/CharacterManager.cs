using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager  {


    public List<GameObject> CharList = new List<GameObject>();

    public List<GameObject> EnemyList = new List<GameObject>();

    public GameObject SelectedChar;
    // Use this for initialization
    public CharacterManager()
    {
        var caps = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        caps.AddComponent<VisualCharacter>();
        caps.transform.position = new Vector3(0, 5, 0);

        SelectedChar = caps;
        
        CharList.Add(SelectedChar);
    }

    // Update is called once per frame
    void Update ()
    {
	    
	}


    public void updateSelected(float horizontal, float vertical)
    {


        Vector3 moveDirection = Vector3.zero;



        moveDirection = new Vector3(horizontal, 0, vertical);
        // moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= 12.0f;

        moveDirection.y -= -9.81f * Time.deltaTime;

        SelectedChar.GetComponent<VisualCharacter>().Move(moveDirection);
    }
}
