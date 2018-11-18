using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///             if (this.GetComponent<scr_mod_iframes>().alarm>-1)
///            {
///                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision, false);
///            }
///            else
///            {
///                this.GetComponent<scr_mod_iframes>().OnStart(60);
///            }
/// </summary>
public class scr_ui_multiIcon : MonoBehaviour {
    public GameObject image;
    public float basewidth;

    private void Start()
    {
        basewidth = image.GetComponent<Image>().sprite.rect.width;
    }

    public void OnRefresh (int count) {
        image.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(basewidth * count, image.GetComponent<Image>().rectTransform.sizeDelta.y);
    }
}
