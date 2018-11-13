using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_debug_scenes : MonoBehaviour {
    public string scene;
    private Button button;
    public Text title;
	// Use this for initialization
	void Start () {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnLoad);
        title.text = this.gameObject.name;
    }

    void OnLoad() {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
