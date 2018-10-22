using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_golf_goal_spawn : MonoBehaviour {
    public GameObject goal;
    public GameObject ball;
    public GameObject player;

    Collider2D m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;
    // Use this for initialization
    void Start () {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider2D>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        OnSpawn();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSpawn() {
        GameObject n_ball = Instantiate(ball);
        n_ball.SetActive(true);
        n_ball.transform.localScale = ball.transform.lossyScale;
        n_ball.transform.position = ball.transform.position;
        player.GetComponent<scr_player_golf_controls>().ball = n_ball;
        GameObject n_goal = Instantiate(goal);
        n_goal.SetActive(true);
        n_goal.transform.position = new Vector3(Random.Range(m_Min.x, m_Max.x), Random.Range(m_Min.y, m_Max.y), goal.transform.position.z);
        n_goal.transform.localScale = goal.transform.lossyScale;
    }
}
