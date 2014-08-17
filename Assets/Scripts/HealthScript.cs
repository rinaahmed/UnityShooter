using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;
	public bool isEnemy = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null)
		{
			if (shot.isEnemyShot != isEnemy)
			{
				DoDamage(shot.damage);

				Destroy (shot.gameObject); 
			}
		}
	}

	public void DoDamage(int damageVal)
	{
		hp -= damageVal;
		if (hp <= 0)
		{
			SoundEffectsHelper.Instance.MakeExplosionSound();
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy (gameObject);
		}
	}
}
