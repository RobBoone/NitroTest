using UnityEngine;
using System.Collections;

public class EnemyShootTrigger : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay(Collider other)
    {
        if (GetComponentInParent<VisualCharacter>().charProperties.SyndicateLevel < 100)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<VisualCharacter>().WeaponOfChar.GetType().ToString() != "Persuader")
                {
                    GetComponentInParent<VisualCharacter>().WeaponOfChar.ShootBehaviour(other.gameObject, 1.0f, transform.parent.GetComponent<VisualCharacter>().charProperties.Att);
                }
            }
        }
    }
}
