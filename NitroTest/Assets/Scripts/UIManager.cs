using UnityEngine;
using System.Collections;

public class UIManager
{

    public InventoryPanel InvPanel;
    public CharacterPanel CharPanel;
    // Use this for initialization
    public UIManager()
    {
        var invenCanvas = GameObject.Instantiate(Resources.Load("Prefabs/InventoryCanvas")) as GameObject;
        InvPanel = invenCanvas.AddComponent<InventoryPanel>();
        InvPanel.initialize();

        var charCanvas = GameObject.Instantiate(Resources.Load("Prefabs/InventoryCanvas")) as GameObject;
        CharPanel = charCanvas.AddComponent<CharacterPanel>();
        CharPanel.initialize();
    }


    public void EnableDisableInventory()
    {
        if (InvPanel.gameObject.activeSelf)
            InvPanel.gameObject.SetActive(false);
        else
        {
            InvPanel.gameObject.SetActive(true);
            InvPanel.Refresh();
        }
    }

    public void EnableDisableCharPanel()
    {
        if (CharPanel.gameObject.activeSelf)
            CharPanel.gameObject.SetActive(false);
        else
        {
            CharPanel.gameObject.SetActive(true);
            CharPanel.Refresh();
        }
    }
}
