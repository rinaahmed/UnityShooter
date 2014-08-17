using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private WeaponScript[] weapons;

	private bool hasSpawn;
	private MoveScript moveScript;

	// Use this for initialization
	void Start () 
	{
		EnableActions (false);
	}

	void Awake()
	{
		weapons = GetComponentsInChildren<WeaponScript> ();
		moveScript = GetComponent<MoveScript> ();
	}

	// Update is called once per frame
	void Update () {


		if (hasSpawn == false)
		{
			//check if enemy is visible
			if (renderer.IsVisibleFrom(Camera.main))
			{
				//Spawn
				Spawn ();
			}
		}
		else
		{
			// auto fire
			foreach (WeaponScript weapon in weapons)
			{
				if (weapon != null && weapon.CanAttack)
				{
					SoundEffectsHelper.Instance.MakeEnemyShotSound();
					weapon.Attack (true);
				}
			}

			// if enemy is outside of camera -> destroy
			if (renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy (gameObject);
			}
		}
	}

	void Spawn()
	{
		EnableActions (true);
	}

	void EnableActions(bool enable)
	{
		hasSpawn = enable;

		// enable / disable collision and enemy movement
		collider2D.enabled = enable;
		moveScript.enabled = enable;

		// enable / disable weapons
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = enable;
		}
	}
}
