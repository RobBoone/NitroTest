using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    // Use this for initialization
    public Character charProperties;
    public Weapon WeaponOfChar;
    private NavMeshAgent agent;
    public ParticleSystem Hit;
    void Start()
    {
        WeaponOfChar = new Rifle();
        agent = GetComponent<NavMeshAgent>();
        charProperties = new Character(100.0f, WeaponOfChar.Damage, 10,0);
       
        var obj = GameObject.Instantiate(Resources.Load("Prefabs/HitParticle"), this.transform.position,Quaternion.Euler(new Vector3(-90.0f,0,0))) as GameObject;
        obj.transform.SetParent(this.transform);
        Hit = obj.GetComponent<ParticleSystem>();

    }


    public void Move(Vector3 moveDirection)
    {
        agent.SetDestination(moveDirection);

    }

    public void Shoot(GameObject enemy, float shoot)
    {
        WeaponOfChar.ShootBehaviour(enemy, shoot, charProperties.Att);
    }


    public void HitCharacter(float amount)
    {
        Hit.Play();
        charProperties.Hit(amount);
       
    }

}
