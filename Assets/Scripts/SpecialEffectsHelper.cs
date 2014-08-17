using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {

	public static SpecialEffectsHelper Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		// register singleton
		if (Instance != null)
		{
			Debug.LogError ("Multiple instances of SpecialEffectsHelper!");
		}

		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate (smokeEffect, position);
		instantiate (fireEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate (prefab
		                                               , position
		                                               , Quaternion.identity) as ParticleSystem;

		Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);

		return newParticleSystem;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
