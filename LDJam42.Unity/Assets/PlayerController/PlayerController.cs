using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BodController))]
public partial class PlayerController : MonoBehaviour
{
	public float excessWeight = 0f;

	public float speed = 5;

	public Vector2 clampZ = new Vector2(-5f, 5f);


	public void OnObstacle(Collider c)
	{
		Debug.Log("Clink");
	}

}

partial class PlayerController
{
	private BodType _bod = BodType.Lean;
	private BodController _bodController = null;

	private void Awake()
	{
		_bodController = GetComponent<BodController>();
	}

	private void Update()
	{
		// update bod
		EvaluateBod();
		// update position
		UpdatePosition();
	}

	

	private void EvaluateBod()
	{
		_bod = TubbyAnalytics.Eval(excessWeight);
		_bodController.SetBod(_bod);
		_bodController.speed = speed;
	}

	private void UpdatePosition()
	{
		Vector2 delta = CalculateDelta();

		Vector3 pos = transform.position + new Vector3(delta.x, 0, delta.y);
		float radius = TubbyAnalytics.GetRadius(excessWeight);

		Vector2 range = clampZ;

		range.x += radius;
		range.y -= radius;

		pos.z = Clamp(pos.z, range);


		transform.position = pos;
	}

	private Vector2 CalculateDelta()
	{
		Vector2 mul = Vector2.zero;
		if (InputManager.up) { mul.y += -1; }
		if (InputManager.down) { mul.y += 1; }
		mul.y *= speed * Time.deltaTime;
		return mul;
	}

	private float Clamp(float v, Vector2 range)
	{
		return Mathf.Clamp(v, Mathf.Min(range.x, range.y), Mathf.Max(range.x, range.y));
	}
}