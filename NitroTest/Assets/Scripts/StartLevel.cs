using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

    public void LoadLevel()
    {
        SceneManager.LoadScene("Test");
    }
}
