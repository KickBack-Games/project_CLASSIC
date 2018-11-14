using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_color_movement : MonoBehaviour {
    public int speedX;
    public int speedY;

    private int num;

    public float[] red;
    public float[] blue;
    public float[] green;
    // Use this for initialization
    void Start()
    {
        num = Random.Range(0, 2);
        Mathf.RoundToInt(num);
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = new Color(red[num], blue[num], green[num]);

        speedX = Random.Range(2, 4);
        speedY = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speedX);
        transform.Translate(Vector2.up * Time.deltaTime * speedY);
        if (transform.position.x >= 2.3)
        {
            speedX = Mathf.Abs(speedX) * -1;
            num = Random.Range(0, 2);
            Mathf.RoundToInt(num);
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.color = new Color(red[num], blue[num], green[num]);
        }
        if (transform.position.x <= -2.6)
        {
            speedX = Mathf.Abs(speedX);
            num = Random.Range(0, 2);
            Mathf.RoundToInt(num);
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.color = new Color(red[num], blue[num], green[num]);
        }

        if (transform.position.y >= 3.80)
        {
            speedY = Mathf.Abs(speedY) * -1;
            num = Random.Range(0, 2);
            Mathf.RoundToInt(num);
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.color = new Color(red[num], blue[num], green[num]);
        }
        if (transform.position.y <= -4.50)
        {
            speedY = Mathf.Abs(speedY);
            num = Random.Range(0, 2);
            Mathf.RoundToInt(num);
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.color = new Color(red[num], blue[num], green[num]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shield")
        {
            if (collision.gameObject.transform.parent.GetComponent<scr_player_color_controls>().num == num)
            {
                speedX *= -1;
                speedY *= -1;
            }
        }
    }
}
