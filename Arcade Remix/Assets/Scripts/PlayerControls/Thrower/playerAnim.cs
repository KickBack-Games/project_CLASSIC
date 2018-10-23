using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour 
{

	private Animator anim;

	public GameObject pow;
	private power scri;

	private int count = 0;
	// Use this for initialization
	void Start () 
	{

		anim = GetComponent<Animator>();
		scri = pow.GetComponent<power>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (scri.second == 0)
		{
			if (count > 50)
				anim.SetBool("THROW", false);
			else
			{
				anim.SetTrigger("THROW");
				count++;
			}
			print(count);
		}
	}
}
