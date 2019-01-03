using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_mod_fader : MonoBehaviour {
    private Image image;
    public static int fadeSpeed;
    public static Color alpha;
    public static float speed = 0.030f;
    public static bool active = false;

    public static GameObject owner;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        active = false;
        owner = null;
        fadeSpeed = 0;
        Time.timeScale = 1;
        image.canvasRenderer.SetAlpha(0.01f);
    }

    // Update is called once per frame
    void Update()
    {       
        if (fadeSpeed == 1)
        {
            image.enabled = true;
            image.CrossFadeAlpha(1, .30f, false);
            StartCoroutine(FadeScreen());
        }
    }
    public IEnumerator FadeScreen()
    {
        yield return new WaitForSeconds(.50f);
        active = true;
    }
}
