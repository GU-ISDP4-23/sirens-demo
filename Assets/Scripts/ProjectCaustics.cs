using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectCaustics : MonoBehaviour
{
	public Texture2D[] frames;
	
	private int frameIdx;
	private Projector projector;

	void Start()
	{
		projector = GetComponent<Projector> ();
	}

	void Update()
	{
		projector.material.SetTexture("_ShadowTex", frames[frameIdx]);
		frameIdx = (frameIdx+1) % frames.Length;
	}
}
