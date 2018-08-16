using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo: 
// make bod controller control transformation of bod
// and make it animate properly according to speed

public class BodController : MonoBehaviour
{
	public float speed = 0;

	public BodType bod = BodType.Lean;


	public GameObject[] bods = null;	


	public void SetBod(BodType type)
	{
		bod = type;
		for(int i = 0; i < bods.Length; i++)
		{
			bods[i].SetActive(false);
		}
		bods[(int)bod].SetActive(true);
	}

	private void Update()
	{
		var bo = bods[(int) bod];
		float rad = TubbyAnalytics.GetRadius(bod);
		bo.transform.localScale = TubbyAnalytics.GetScale(bod);
	}
}
