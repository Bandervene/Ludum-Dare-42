using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TextureScroll : MonoBehaviour
{
	public Vector2 speed = Vector2.zero;
	public Vector2 scale = Vector2.one;

	private Renderer _renderer = null;

	private MaterialPropertyBlock _pBlock = null;

	private Vector2 _scroll = Vector2.zero;

	private void Awake()
	{
		_pBlock = new MaterialPropertyBlock();
		_renderer = GetComponent<Renderer>();
		
	}


	private void Update ()
	{
		ScrollTexture();
	}

	private void ScrollTexture()
	{
		_scroll += speed * Time.deltaTime;
		Vector4 v = _renderer.material.GetVector("_MainTex_ST");
		v.z = _scroll.x * scale.x;
		v.w = _scroll.y * scale.y;
		_pBlock.SetVector("_MainTex_ST", v);
		_renderer.SetPropertyBlock(_pBlock);
	}
}
