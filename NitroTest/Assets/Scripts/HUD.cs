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
	    if (Text != null)
	    {
	        Text.transform.SetParent(hudCanvas.transform);
	        hudCanvas.GetComponentInChildren<Text>().text = "Selected player : " + (GameManager.CharMan.SelectedCharNumber+1) + "  Weapon: " + GameManager.CharMan.SelectedChar.GetComponent<VisualCharacter>().WeaponOfChar.ToString();
	        Text.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width / 2 - Text.GetComponent<RectTransform>().rect.width / 2, Screen.height / 2 - Text.GetComponent<RectTransform>().rect.height / 2, 0);

	        button = GameObject.Instantiate(Resources.Load("Prefabs/FollowRemain")) as GameObject;
	        if (button != null)
	        {
	            button.transform.SetParent(hudCanvas.transform);
	            button.GetComponentInChildren<Text>().text = "FollowMode";
	            button.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width / 2 - button.GetComponent<RectTransform>().rect.width / 2, Screen.height / 2 - Text.GetComponent<RectTransform>().rect.height - button.GetComponent<RectTransform>().rect.height / 2, 0);
	            button.GetComponent<Button>().onClick.AddListener(() => GameManager.CharMan.FollowRemainMode());

	            var persuadeButton = GameObject.Instantiate(Resources.Load("Prefabs/FollowRemain")) as GameObject;
	            if (persuadeButton != null)
	            {
	                persuadeButton.transform.SetParent(hudCanvas.transform);
	                persuadeButton.GetComponentInChildren<Text>().text = "Equip Persuade";
	                persuadeButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width / 2 - button.GetComponent<RectTransform>().rect.width / 2, Screen.height / 2 - Text.GetComponent<RectTransform>().rect.height - button.GetComponent<RectTransform>().rect.height - button.GetComponent<RectTransform>().rect.height / 2, 0);
	                persuadeButton.GetComponent<Button>().onClick.AddListener(() => GameManager.CharMan.ChangeWeapon(new Persuader()));
	            }
	        }
	    }

	    var objective=GameObject.Instantiate(Resources.Load("Prefabs/Objective")) as GameObject;
	    if (objective != null)
	    {
	        objective.transform.SetParent(hudCanvas.transform);
	        objective.GetComponent<RectTransform>().anchoredPosition = new Vector3(Screen.width / 2 - objective.GetComponent<RectTransform>().rect.width / 2, -Screen.height / 2 + objective.GetComponent<RectTransform>().rect.height / 2, 0);
	    }
	}
	
	//only called when something changed
	public void UpdateText ()
    {
        hudCanvas.GetComponentInChildren<Text>().text = "Selected player : " + (GameManager.CharMan.SelectedCharNumber + 1) + "  Weapon: " + GameManager.CharMan.SelectedChar.GetComponent<VisualCharacter>().WeaponOfChar.ToString();
        if(GameManager.CharMan.FollowMode)
        button.GetComponentInChildren<Text>().text = "FollowMode";
        else
        button.GetComponentInChildren<Text>().text = "RemainMode";
    }
}
