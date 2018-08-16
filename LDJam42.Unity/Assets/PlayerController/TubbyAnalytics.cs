using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodType
{
	Lean,
	Chub,
	HumanBender
}

public static class TubbyAnalytics
{
	private static float[] _bodRadius = { 0.4f, 0.6f, 1.5f };
	private static Vector3[] _bodScale = { new Vector3(0.8f, 1, 0.8f), new Vector3(1.2f, 1.1f, 1.2f), Vector3.one * 3 };
	private static float[] _weightBarrier = { 0f, 5f, 20f };

	public static BodType Eval(float excessWeight)
	{
		int index = 0;
		for(int i = 0; i < _weightBarrier.Length - 1; i++)
		{
			if(excessWeight >= _weightBarrier[i + 1]) { index = i + 1;  }
		}
		return (BodType) index;
	}

	public static Vector3 GetScale(BodType type)
	{
		return _bodScale[(int) type];
	}

	public static float GetRadius(float excessWeight)
	{
		return _bodRadius[(int) Eval(excessWeight)];
	}

	public static float GetRadius(BodType type)
	{
		return _bodRadius[(int) type];
	}
}
