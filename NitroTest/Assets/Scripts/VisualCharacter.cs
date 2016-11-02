using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    // Use this for initialization
    public Character charProperties;
    private CharacterController charCont;
    public Weapon WeaponOfChar;
    private NavMeshAgent agent;
    void Start()
    {
        WeaponOfChar = new Gun();
        charCont = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update() {

    }



    public void Move(Vector3 moveDirection)
    {
        agent.SetDestination(moveDirection);

    }

    public void Shoot(GameObject enemy, float shoot)
    {
        WeaponOfChar.ShootBehaviour(enemy, shoot);
    }

}
