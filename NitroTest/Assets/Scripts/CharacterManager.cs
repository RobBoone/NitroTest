using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{


    public List<GameObject> CharList = new List<GameObject>();

    public List<GameObject> EnemyList = new List<GameObject>();

    public GameObject SelectedChar;

    private int selectedCharNumber = 0;

    public bool FollowMode = true;
    // Use this for initialization
    public CharacterManager()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int a = 0; a < 2; a++)
            {
                var caps = GameObject.Instantiate(Resources.Load("Prefabs/PlayerAgent"), new Vector3(2 * i, 5, 2 * a), Quaternion.identity) as GameObject;
                CharList.Add(caps);
            }

        }

        SelectedChar = CharList[selectedCharNumber];

    }

    // Update is called once per frame
    public void Update()
    {
        if (FollowMode)
        {
            foreach (var k in CharList)
            {
                if (k != SelectedChar)
                {
                    if (Vector3.Distance(k.transform.position, SelectedChar.transform.position) > 2.5f)
                    {
                        VisualCharacter CharScript = k.GetComponent<VisualCharacter>();
                        CharScript.Move(SelectedChar.transform.position);
                    }
                }
            }
        }
    }


    public void updateSelected(float horizontal, float vertical, float shoot)
    {


        Vector3 moveDirection = Vector3.zero;

        VisualCharacter CharScript = SelectedChar.GetComponent<VisualCharacter>();


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Level"))
            {
                if (shoot > 0)
                    CharScript.Move(hit.point);
            }
            else if (hit.transform.CompareTag("Enemy"))
                CharScript.Shoot(hit.transform.gameObject, shoot);

        }




    }

    public void Switch()
    {
        if (selectedCharNumber < 3)
            selectedCharNumber++;
        else
            selectedCharNumber = 0;
        SelectedChar = CharList[selectedCharNumber];
    }
}