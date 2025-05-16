using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float jumpForce = 12f;
	public Transform groundCheck;
	public LayerMask groundLayer;

	private Rigidbody2D rb;
	private Animator anim;
	private int jumpCount = 0;
	private bool isGrounded;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

		if (isGrounded)
			jumpCount = 0;

		if (Input.GetMouseButtonDown(0) && jumpCount < 1)
		{
			rb.velocity = new Vector2(rb.velocity.x, 0f);
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			jumpCount++;
		}

		// Animator parameters
		if (anim != null)
		{
			anim.SetBool("isGrounded", isGrounded);
			anim.SetFloat("yVelocity", rb.velocity.y);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Obstacle"))
		{
			if (!GameManager.Instance.shieldActive)
			{
				ScoreManager.Instance.TakeDamage();
				// Optional: Add a small bounce effect
				rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
			}
			
			
			Destroy(other.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Coin"))
		{
			ScoreManager.Instance.CollectCoin();
			Destroy(other.gameObject);
		}
		else if (other.CompareTag("PowerUp"))
		{
			other.GetComponent<PowerUp>().Activate();
			Destroy(other.gameObject);
		}
	}
}