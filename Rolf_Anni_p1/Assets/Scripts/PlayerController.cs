using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private bool isJumping = false;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float Jump = Input.GetAxis ("Jump");

		if (Jump > 0 && isJumping == false) {
			rb.AddForce (new Vector3 (0.0f, 100.0f, 0.0f));
			isJumping = true;
		} else {
			if (transform.position.y < 1) {
				isJumping = false;
			}
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


		rb.AddForce(movement * speed);
	}
}
