using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class InventoryPanel : SyndicatePanel {

    private GameObject invenCanvas;
    private List<GameObject> buttonList;
    private List<Item> itemsForInv;
    override public void initialize()
    {
        invenCanvas = this.gameObject;
        buttonList = new List<GameObject>();
    }


    //Redraw all buttons so when an item is used yhe button goes away and the order is restored
    override public void Refresh()
    {
        if (buttonList.Count != 0)
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                Destroy(buttonList[i]);
            }
            buttonList.Clear();
        }

        //Make a button for each item
        itemsForInv = GameManager.InventoryForChar.InventoryList;
        int orderHelp=0;
        if (itemsForInv.Count != 0)
        {
            for (int i = 0; i < itemsForInv.Count; i++)
            {
                if (i != 0 && i % 4 == 0)
                    orderHelp++;
                GameObject Button = GameObject.Instantiate(Resources.Load("Prefabs/Button")) as GameObject;
                if (Button != null)
                {
                    if (itemsForInv[i].TypeOfItem == Item.ItemType.Weapon)
                    {
                        Button.GetComponentInChildren<Text>().text = itemsForInv[i].ToString();
                    }
                    else
                    {
                        var enhancements = itemsForInv[i] as Enhancements;
                        if (enhancements != null)
                            Button.GetComponentInChildren<Text>().text =enhancements.TypeOfEnhancement.ToString();
                    }

                    Button.transform.SetParent(invenCanvas.transform);
                    Item tempItem = itemsForInv[i];
                    Button.GetComponent<Button>().onClick.AddListener(() => CallOnWeaponChange(tempItem, Button));
                        //using itemsForInv[i] instead of temp item gave errors

                    Button.GetComponent<RectTransform>().anchoredPosition =
                        new Vector3(
                            ((-(Screen.width/2) + Button.GetComponent<RectTransform>().rect.width/2) + i*50) -
                            (orderHelp*200), -(Button.GetComponent<RectTransform>().rect.height/2) - (orderHelp*50), 0);


                    buttonList.Add(Button);
                }
            }
        }
    }

    public void CallOnWeaponChange(Item k,GameObject buttonToRemove)
    {
        //switch weapon
        GameManager.CharMan.ApplyItem(k);
        //Delete from inventory because it's used
        GameManager.InventoryForChar.Remove(k);
        //Refresh inventory look
        Refresh();
    }
}
