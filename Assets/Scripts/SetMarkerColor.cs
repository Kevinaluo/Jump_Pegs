using UnityEngine;
using System.Collections;

public class SetMarkerColor : MonoBehaviour {
	void Awake() 
	{
		renderer.material.color = Color.black;
	}
	void OnDestroy() 
	{
		DestroyImmediate(renderer.material);
	}
}

