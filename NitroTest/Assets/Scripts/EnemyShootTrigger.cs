using UnityEngine;
using System.Collections;

public class EnemyShootTrigger : MonoBehaviour {

	// Script that enemys use to attack characters
	void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetComponentInParent<VisualCharacter>().CharProperties.SyndicateLevel < 100)
             {
            
                if (other.GetComponent<VisualCharacter>().WeaponOfChar.GetType().ToString() != "Persuader")
                {
                    GetComponentInParent<VisualCharacter>().WeaponOfChar.ShootBehaviour(other.gameObject, 1.0f, transform.parent.GetComponent<VisualCharacter>().CharProperties.Att);
                }
            }
        }
    }
}
