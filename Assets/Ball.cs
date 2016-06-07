using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public GameObject score_1;
	public GameObject score_2;
	public int score_1_i;
	public int score_2_i;
	public float speed = 30;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketHeight) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		GetComponent<AudioSource>().Play();
		switch (col.gameObject.name)
		{
			case "Player_1":
				// Calculate hit Factor
				float y = hitFactor(transform.position,
														col.transform.position,
														col.collider.bounds.size.y);

				// Calculate direction, make length=1 via .normalized
				Vector2 dir = new Vector2(1, y).normalized;

				// Set Velocity with dir * speed
				GetComponent<Rigidbody2D>().velocity = dir * speed;
				break;
			case "Player_2":
				// Calculate hit Factor
				float yy = hitFactor(transform.position,
														col.transform.position,
														col.collider.bounds.size.y);

				// Calculate direction, make length=1 via .normalized
				Vector2 dirr = new Vector2(-1, yy).normalized;

				// Set Velocity with dir * speed
				GetComponent<Rigidbody2D>().velocity = dirr * speed;
				break;
			case "Goal_1":
				Debug.Log("Score to Player 2");
				score_1_i += 1;
				score_1.GetComponent<Text>().text = score_1_i.ToString();
				break;
			case "Goal_2":
				Debug.Log("Score to Player 1");
				score_2_i += 1;
				score_2.GetComponent<Text>().text = score_2_i.ToString();
				break;

		}
	}

}
