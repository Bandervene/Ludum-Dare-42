using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ColliderEvent : UnityEvent<Collider> { }

public class Trigger : MonoBehaviour
{
	public ColliderEvent onTriggerEnter = default(ColliderEvent);

	private void OnTriggerEnter(Collider c)
	{
		Debug.Log("Eh");
		onTriggerEnter.Invoke(c);
	}
}
