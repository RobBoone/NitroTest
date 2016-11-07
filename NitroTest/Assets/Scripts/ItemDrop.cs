using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.PickupItem();
            GameObject.Destroy(this.gameObject);
        }
    }
}
