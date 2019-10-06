using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_mod_fader : MonoBehaviour {
    private Image image;
    public static int fadeSpeed;
    public static Color alpha;
    public static float speed = 0.030f;
    public static bool active = false;
    public static string next;

    public static GameObject owner;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        active = false;
        owner = null;
        fadeSpeed = -1;
        //Time.timeScale = 1;
        image.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeSpeed == 1)
        {
            image.CrossFadeAlpha(1, .30f, false);
            StartCoroutine(FadeScreen());
        }
        if (fadeSpeed == -1)
        {
            image.CrossFadeAlpha(0, .30f, false);
        }
    }
    public IEnumerator FadeScreen()
    {
        if (fadeSpeed == 1)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(next, LoadSceneMode.Single);
            active = true;
            fadeSpeed = -1;
        }
        if (fadeSpeed == -1)
        {
            fadeSpeed = 0;
        }
    }
}
