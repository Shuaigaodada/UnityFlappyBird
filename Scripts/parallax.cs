using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
	public float animationSpeed = 0.05f;

	private void Awake() {
		this.meshRenderer = GetComponent<MeshRenderer>();
	}

	private void Update() {
		this.meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
	}
}
