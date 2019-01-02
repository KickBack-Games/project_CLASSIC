using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_mod_fader : MonoBehaviour {
    private Image image;
    public static int fadeSpeed;
    public static Color alpha;
    public static float speed = 0.010f;
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
    }

    // Update is called once per frame
    void Update()
    {
        alpha = image.color;
        if (fadeSpeed == 1 && alpha.a < 1)
        {
            image.enabled = true;
            image.color = new Color(alpha.r, alpha.g, alpha.b, alpha.a += speed);
        }

        if (fadeSpeed == -1)
        {
            image.color = new Color(alpha.r, alpha.g, alpha.b, alpha.a -= speed);
        }

        if (alpha.a > .9f && fadeSpeed == 1)
        {
            active = true;
        }

        if (alpha.a < .10f && fadeSpeed == -1)
        {
            image.enabled = false;
            fadeSpeed = 0;
            active = false;
            owner = null;
        }
    }

}
