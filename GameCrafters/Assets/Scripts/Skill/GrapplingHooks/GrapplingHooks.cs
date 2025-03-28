using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHooks : ASkill
{
    
    public GameObject grapplingHooksBulletPrefab;
    private Quaternion initRotation;
    public Transform player;
    public float shootingForce = 50f;
    public AudioSource audioShoot;
    public AudioSource audioHit;

    void Awake()
    {
        AmmoMax = 1;
        AmmoCurrent = AmmoMax;
    }

    public override void Shoot(Vector3 shootingPosition)
    {
        if (AmmoCurrent > 0)
        {
            AmmoCurrent--;
          
            RaycastHit2D hit = Physics2D.Raycast(player.position, shootingPosition, Mathf.Infinity, LayerMask.GetMask("ground"));
            Debug.Log(hit.collider);
            // Kiểm tra xem có va chạm với layer "ground" hay không
            // if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
            // {
                Debug.Log("ban");
                // Có va chạm với đối tượng có layer "ground", do đó, tạo vật thể
                SetInitRotation(shootingPosition);
                GameObject bullet = Instantiate(grapplingHooksBulletPrefab, shootingPosition, initRotation);
                bullet.GetComponent<GrapplingHooksBullet>().SetPlayer(player);
                bullet.GetComponent<GrapplingHooksBullet>().SetVelocity((shootingPosition - player.position)* 20);
            // }
            bullet.GetComponent<GrapplingHooksBullet>().audioHit = audioHit;
            audioShoot.Play();
        }
        else
        {
            Debug.Log("OutOfAmmo");
        }
    }
   	private void SetInitRotation(Vector3 shootingPosition)
	{
		Quaternion totalRotation = Quaternion.Euler(Vector3.zero);
		Vector2 direction = shootingPosition - player.position;
		Debug.Log(direction);
		if (direction.x < 0)
		{
			totalRotation *= Quaternion.Euler(Vector3.up * 180f);
		}
		if (direction.y < 0)
		{
			totalRotation *= Quaternion.Euler(Vector3.forward * -70f);
		}
		else if (direction.y > 0)
		{
			totalRotation *= Quaternion.Euler(Vector3.forward * 70f);
		}
		initRotation = totalRotation;
	}

    void Update()
    {
       
    }
}
