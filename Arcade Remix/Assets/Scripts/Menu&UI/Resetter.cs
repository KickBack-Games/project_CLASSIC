using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resetter : MonoBehaviour {
    Button button;

    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnPress);
    }

    void OnPress()
	{
        SceneManager.LoadScene("DEBUG", LoadSceneMode.Single);
    }
}
