using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text text;

	private Rigidbody rb;
	private bool isJumping = false;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
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

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			text.text = "Score: " + count.ToString ();
		}
	}
}


