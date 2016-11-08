using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    // Use this for initialization
    public Character CharProperties;
    public Weapon WeaponOfChar;
    private NavMeshAgent agent;
    public ParticleSystem Hit;
    public ParticleSystem Persuade;

    void Start()
    {
        WeaponOfChar = new Rifle();
        agent = GetComponent<NavMeshAgent>();
        CharProperties = new Character(100.0f, WeaponOfChar.Damage, 10,0);
       
        var obj = GameObject.Instantiate(Resources.Load("Prefabs/HitParticle"), this.transform.position,Quaternion.Euler(new Vector3(-90.0f,0,0))) as GameObject;
        if (obj != null)
        {
            obj.transform.SetParent(this.transform);
            Hit = obj.GetComponent<ParticleSystem>();
        }

        var objPers = GameObject.Instantiate(Resources.Load("Prefabs/PersuadeParticle"), this.transform.position, Quaternion.Euler(new Vector3(-90.0f, 0, 0))) as GameObject;
        if (objPers != null)
        {
            objPers.transform.SetParent(this.transform);
            Persuade = objPers.GetComponent<ParticleSystem>();
        }
    }


    public void Move(Vector3 moveDirection)
    {
        if(agent!=null)
        agent.SetDestination(moveDirection);

    }

    public void Shoot(GameObject enemy, float shoot)
    {
        WeaponOfChar.ShootBehaviour(enemy, shoot, CharProperties.Att);
    }


    public void HitCharacter(float amount)
    {
        Hit.Play();
        CharProperties.Hit(amount);
       
    }

    public void PersuadeCharacter(float amount)
    {
        Persuade.Play();
        CharProperties.Persuade(amount);

    }

}
