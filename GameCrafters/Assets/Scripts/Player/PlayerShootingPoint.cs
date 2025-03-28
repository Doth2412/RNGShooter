using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerShootingPoint : MonoBehaviour
{
	public Transform shootingPoint;
	private Vector3 defaultAimVector;
	private Vector3 aimDiagonalVector;
	private Animator anim;
	// Start is called before the first frame update
	void Awake()
	{
		defaultAimVector = Vector3.right *0.4f;
		Vector3 tempVector = new Vector3(1.5f,3,0);
		aimDiagonalVector = tempVector.normalized * 0.5f;
		anim = GetComponent<Animator>();
	}
	
	void HandleDirection()
	{
		Vector3 position;
		
		if (Input.GetKey(KeyCode.W))
		{
			position = transform.position + new Vector3(aimDiagonalVector.x * Mathf.Sign(transform.localScale.x), aimDiagonalVector.y, 0f);
			anim.SetBool("up", true);
			anim.SetBool("down", false);
		}
		else if(Input.GetKey(KeyCode.S))
		{
			position = transform.position + new Vector3(aimDiagonalVector.x * Mathf.Sign(transform.localScale.x), -aimDiagonalVector.y, 0f);
			anim.SetBool("up", false);
			anim.SetBool("down", true);
		}
		else 
		{
			position = transform.position + new Vector3(defaultAimVector.x * Mathf.Sign(transform.localScale.x), defaultAimVector.y, 0f);
			anim.SetBool("up", false);
			anim.SetBool("down", false);
		}
		
		shootingPoint.transform.position = position;
	}

	// Update is called once per frame
	void Update()
	{
		if(GameObject.Find("PauseMenu") == null)
			HandleDirection();
	}
}
