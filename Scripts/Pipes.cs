using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
	public float leftEdge;
	public float offset = 1f;

	private void Start()
	{
		leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - offset;
	}

	private void Update()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
		if(transform.position.x < leftEdge)
			Destroy(gameObject);
	}
}
