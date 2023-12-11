using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector3 direction;

	public float rotateSpeed = 10;
    public float gravity = -9.85f;
	public float strength = 5f;

	public int rotateDegrees = 30;

	private void Update()
	{
		// get user input and fly
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			this.Jump();
		}
		// in phone check touchCount
		if(Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began) {
				this.Jump();
			}
		}

		direction.y += gravity * Time.deltaTime;
		transform.position += direction * Time.deltaTime;

		float currentAngle = transform.eulerAngles.z;
		if(currentAngle > 180) currentAngle -= 360;

		float targetAngle = direction.y > 0 ? this.rotateDegrees : -this.rotateDegrees;
		float angle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * rotateSpeed);
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		if(transform.position.y >= 4.75) {
			transform.position = new Vector3(transform.position.x, 4.75f, transform.position.z);
		}
	}

	private void OnEnable()
	{
		transform.position = Vector3.zero;
		direction = Vector3.zero;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
	}

	private void Jump() => this.direction = Vector3.up * strength;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Obstacle") {
			GameManager.instance.GameOver();
		} else if(collision.tag == "Scoring") {
			GameManager.instance.IncreaseScore();
		}
	}
}
