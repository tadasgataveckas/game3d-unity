using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackChildren : MonoBehaviour
{
	[SerializeField]
	GameObject parent;
	[SerializeField]
	TextMeshProUGUI gameovertext;
	private void Start()
	{
		gameovertext.enabled = false;
		List<Transform> children = new List<Transform>();
		for(int i = 0; i<parent.transform.childCount; i++)
		{
			children.Add(parent.transform.GetChild(i));
		}
	}

	private void Update()
	{
		if (parent.transform.childCount <= 0)
		{
			gameovertext.enabled = true;
		}
	}
}
