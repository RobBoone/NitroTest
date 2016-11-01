using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    // Use this for initialization
    public Character charProperties;
    private CharacterController CharCont;
    void Start()
    {
        
        CharCont = gameObject.AddComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update() {

    }



    public void Move(Vector3 moveDirection)
    { 
        CharCont.Move(moveDirection* Time.deltaTime);   
    }
   

    
}
