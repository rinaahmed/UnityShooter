using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;
	public float shootingRate = 0.25f;

	private float shootCooldown;

	// Use this for initialization
	void Start () {

		shootCooldown = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (shootCooldown > 0) 
		{
			shootCooldown -= Time.deltaTime;
		}

	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			//reset cooldown
			shootCooldown = shootingRate;

			//create new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// assign position
			shotTransform.position = transform.position;

			//handly isEnemy
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = transform.right;
			}
		}
	}


	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0.0f;
		}
	}
}
