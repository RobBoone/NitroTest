﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class CharacterPanel : SyndicatePanel {


    private GameObject invenCanvas;
    private List<GameObject> buttonList;
    private List<GameObject> charList;

    //initialize the characterpanels
    override public void initialize()
    {
        invenCanvas = this.gameObject;
        buttonList = new List<GameObject>();


        charList = GameManager.CharMan.CharList;
        int orderHelp = 0;
        if (charList.Count != 0)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                if (i != 0 && i % 2 == 0)
                    orderHelp++;

                GameObject Button = GameObject.Instantiate(Resources.Load("Prefabs/ButtonPlaye")) as GameObject;

                if (Button != null)
                {
                    Button.GetComponentInChildren<Text>().text = "Player " + (i + 1);// + "\n" + "HP: " + charList[i].GetComponent<VisualCharacter>().CharProperties.GetHp();
                    Button.transform.SetParent(invenCanvas.transform);
                    int id = i;
                    Button.GetComponent<Button>().onClick.AddListener(() => Switch(id));

                    Button.GetComponent<RectTransform>().anchoredPosition = new Vector3(((-(Screen.width / 2) + Button.GetComponent<RectTransform>().rect.width / 2) + i * 50) - (orderHelp * 100), ((Screen.height / 2) - Button.GetComponent<RectTransform>().rect.height / 2) - (Button.GetComponent<RectTransform>().rect.height * orderHelp), 0);


                    buttonList.Add(Button);
                }
            }
        }
    }

    //Refresshes the panels when something changes
    override public void Refresh()
    {

        //if (charList.Count != 0)
        //{
        //    for (int i = 0; i < charList.Count; i++)
        //    {         
        //
        //        buttonList[i].GetComponentInChildren<Text>().text = "Player " + (i + 1) + "\n" + "HP: " + charList[i].GetComponent<VisualCharacter>().CharProperties.Hp;
        //    }
        //}
        if (buttonList.Count != 0)
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                Destroy(buttonList[i]);
            }
            buttonList.Clear();
        }

        int orderHelp = 0;
        if (charList.Count != 0)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                if (i != 0 && i % 2 == 0)
                    orderHelp++;

                GameObject Button = GameObject.Instantiate(Resources.Load("Prefabs/ButtonPlaye")) as GameObject;

                if (Button != null)
                {
                    Button.GetComponentInChildren<Text>().text = "Player " + (i + 1) + "\n" + "HP: " + charList[i].GetComponent<VisualCharacter>().CharProperties.Hp;
                    Button.transform.SetParent(invenCanvas.transform);
                    int id = i;
                    Button.GetComponent<Button>().onClick.AddListener(() => Switch(id));

                    Button.GetComponent<RectTransform>().anchoredPosition = new Vector3(((-(Screen.width / 2) + Button.GetComponent<RectTransform>().rect.width / 2) + i * 50) - (orderHelp * 100), ((Screen.height / 2) - Button.GetComponent<RectTransform>().rect.height / 2) - (Button.GetComponent<RectTransform>().rect.height * orderHelp), 0);


                    buttonList.Add(Button);
                }
            }
        }

    }

    public void Switch(int ID)
    {
        //switch Character
        GameManager.CharMan.SwitchByID(ID);
        
    }
}

