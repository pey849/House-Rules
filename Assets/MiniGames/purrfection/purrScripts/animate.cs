using UnityEngine;
using System.Collections;

public class animate : MonoBehaviour {

	public Animator anim;

	public void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void PlayAnimation(string shape)
	{
		anim.Play (shape + "win", -1, 0.0f);
	}
}
