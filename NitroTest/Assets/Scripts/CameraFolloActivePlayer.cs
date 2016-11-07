using UnityEngine;
using System.Collections;

public class CameraFolloActivePlayer : MonoBehaviour {

    Camera cam;
	// Use this for initialization
	void Start () {

        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.CharMan.SelectedChar != null)
        {
            Vector3 pos = GameManager.CharMan.SelectedChar.transform.position;
            Vector3 campos = cam.transform.position;
            cam.transform.position = new Vector3(pos.x, campos.y, pos.z - 20);
        }

	}
}
