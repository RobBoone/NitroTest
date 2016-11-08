using UnityEngine;
using System.Collections;

public class CameraFolloActivePlayer : MonoBehaviour {

    private Camera cam;
	void Start () {

        cam = GetComponent<Camera>();
	}
	
	//Follows the active player
	void Update ()
    {
        if (GameManager.CharMan.SelectedChar != null)
        {
            Vector3 pos = GameManager.CharMan.SelectedChar.transform.position;
            Vector3 campos = cam.transform.position;
            cam.transform.position = new Vector3(pos.x, campos.y, pos.z - 35);
        }

	}
}
