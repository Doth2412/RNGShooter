using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D body;
	private BoxCollider2D boxCollider;
	private Vector2 jumpForce;
	private Animator anim;
	private static bool isPause = false;
	private float speedUpTime = 0f;
	
	public PhysicsMaterial2D basePhysics;
	public PhysicsMaterial2D onWall;
	public float playerBaseGravity;
	[SerializeField] private float baseSpeed;
	[SerializeField] private LayerMask ground;

	private float speed;

	bool canFly = true;
	bool canJump = true;
	private int key = 0;

	private bool justTeleport = false;

	public AudioSource audioJump;
	
	
	public bool checkIsGrounded;
	private void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
		jumpForce = Vector2.up * baseSpeed * 2;
		playerBaseGravity = body.gravityScale;

		speed = baseSpeed;
	}

	public bool IsGrounded()
	{
		Bounds bounds = boxCollider.bounds;
		RaycastHit2D hit = Physics2D.BoxCast(bounds.center, new Vector2(bounds.size.x, bounds.size.y), 
		0f, Vector2.down, 0.05f, ground);
		return hit.collider!=null;
	}

	private void Move()
	{
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			speedUpTime += Time.deltaTime;
			// Vector2 position = transform.position;
			Vector3 scale = transform.localScale;
			anim.SetBool("run", true);
			if (Input.GetKey(KeyCode.A))
			{
				if (Mathf.Sign(transform.localScale.x) > 0)
				{
					scale.x = -scale.x;
				}
			}
			else if (Input.GetKey(KeyCode.D))
			{
				if (Mathf.Sign(transform.localScale.x) < 0)
				{
					scale.x = -scale.x;
				}
			}
			transform.localScale = scale;
			
			if(speedUpTime <= 0.5f)
			{
				body.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * speed * 2 * speedUpTime, body.velocity.y);
			}
			else
			{
				body.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * speed, body.velocity.y);
			}
		}
		else
		{
			anim.SetBool("run", false);
			speedUpTime = 0f;
		}
		
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			Jump();
		}
	}

	private void Jump()
	{
		if(canJump)
		{
			audioJump.Play();
			body.AddForce(jumpForce, ForceMode2D.Impulse);
		}
		else
		{
			body.AddForce(new Vector2(0,0), ForceMode2D.Impulse);
		}
		
	}
	
	public bool FacingWall()
	{
		// Bounds bounds = boxCollider.bounds;
		// RaycastHit2D hitWallLeft = Physics2D.BoxCast(transform.position, new Vector2(bounds.size.x, bounds.size.y/2),
		// 0f, Vector2.left, 0.1f, ground);
		// RaycastHit2D hitWallRight = Physics2D.BoxCast(transform.position, new Vector2(bounds.size.x, bounds.size.y/2),
		// 0f, Vector2.right, 0.1f, ground);
		// return hitWallLeft.collider != null || hitWallRight.collider != null;
		return false;
	}

	private void Update()
	{
		if(FacingWall())
		{
			body.sharedMaterial = onWall;
		}
		else
		{
			body.sharedMaterial = basePhysics;
		}
		if(GameObject.Find("PauseMenu")==null)
			Move();
		checkIsGrounded = IsGrounded();
	}

	public void Die()
	{
		//Destroy(gameObject);
	}

	public void SetReduceSpeed(bool value)
	{
		if (value == true)
		{
			speed = baseSpeed / 1.5f;
		}
		else
		{
			speed = baseSpeed;
		}
	}

	public void ChangeKey(int amount)
	{
		key += amount;
	}

	public bool HaveKey()
	{
		if (key > 0) return true;
		else return false;
	}

	public void Teleport(Vector2 pos)
	{
		transform.position = pos;
	}

	public bool GetJustTeleport()
	{
		return justTeleport;
	}

	public void SetJustTeleport(bool value)
	{
		justTeleport = value;
	}

	public void SetCanJump(bool value)
	{
		this.canJump = value;
	}

}
