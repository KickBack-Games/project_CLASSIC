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
    public Image baseimage;
    public GameObject image;
    public Transform canvas;

    private void Start()
    {
        image.SetActive(false);
    }

    public void OnRefresh (int count) {
        GameObject[] imagecopy;

        imagecopy = GameObject.FindGameObjectsWithTag("ImageCopy");

        foreach (GameObject food in imagecopy)
        {
            Destroy(food);
        }

        for (int i = 0; i < count; i++)
        {
            GameObject copy = Instantiate(image);
            copy.SetActive(true);
            copy.gameObject.tag = "ImageCopy";
            copy.transform.SetParent(canvas, false);
            copy.transform.position = image.transform.position + new Vector3(baseimage.sprite.rect.width * i, 0, 0);
        }
	}
}
