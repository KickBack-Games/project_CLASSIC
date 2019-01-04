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
        image.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(image.color.a);
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
        yield return new WaitForSeconds(.50f);
        active = true;
        fadeSpeed = -1;
    }
}
