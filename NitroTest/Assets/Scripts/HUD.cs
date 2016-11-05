using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    private GameObject hudCanvas;
    private GameObject button;
	// Use this for initialization
	void Start () {

        hudCanvas = this.gameObject;
        GameObject Text = GameObject.Instantiate(Resources.Load("Prefabs/HudText")) as GameObject;
        Text.transform.SetParent(hudCanvas.transform);
        hudCanvas.GetComponentInChildren<Text>().text = "Selected player : " + (GameManager.CharMan.SelectedCharNumber+1) + "  Weapon: " + GameManager.CharMan.SelectedChar.GetComponent<VisualCharacter>().WeaponOfChar.ToString();
        Text.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width / 2 - Text.GetComponent<RectTransform>().rect.width / 2, Screen.height / 2 - Text.GetComponent<RectTransform>().rect.height / 2, 0);

        button = GameObject.Instantiate(Resources.Load("Prefabs/FollowRemain")) as GameObject;
        button.transform.SetParent(hudCanvas.transform);
        button.GetComponentInChildren<Text>().text = "FollowMode";
        button.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width / 2 - button.GetComponent<RectTransform>().rect.width / 2, Screen.height / 2 - Text.GetComponent<RectTransform>().rect.height - button.GetComponent<RectTransform>().rect.height / 2, 0);
        button.GetComponent<Button>().onClick.AddListener(() => GameManager.CharMan.FollowRemainMode());
    }
	
	// Update is called once per frame
	public void UpdateText ()
    {
        Debug.Log("UpdateText");
        hudCanvas.GetComponentInChildren<Text>().text = "Selected player : " + (GameManager.CharMan.SelectedCharNumber + 1) + "  Weapon: " + GameManager.CharMan.SelectedChar.GetComponent<VisualCharacter>().WeaponOfChar.ToString();
        if(GameManager.CharMan.FollowMode)
        button.GetComponentInChildren<Text>().text = "FollowMode";
        else
        button.GetComponentInChildren<Text>().text = "RemainMode";
    }
}
