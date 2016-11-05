using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    // Use this for initialization
    public Character charProperties;
    public Weapon WeaponOfChar;
    private NavMeshAgent agent;
    void Start()
    {
        WeaponOfChar = new Gun();
        agent = GetComponent<NavMeshAgent>();
        charProperties = new Character(100.0f, WeaponOfChar.Damage, 10);
        
    }


    public void Move(Vector3 moveDirection)
    {
        agent.SetDestination(moveDirection);

    }

    public void Shoot(GameObject enemy, float shoot)
    {
        WeaponOfChar.ShootBehaviour(enemy, shoot, charProperties.Att);
    }

}
