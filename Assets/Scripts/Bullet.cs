using UnityEngine;

public class Bullet : MonoBehaviour
{
	public PlayerController pc;
	public float bulletLifeDuration = 5f;
	private float timer = 0f;

	void Update()
	{
		timer += Time.deltaTime;
		if(timer > bulletLifeDuration) Die();
	}

	void OnCollisionEnter(Collision collison){

		GameObject hit = collison.gameObject;
		Health health = hit.GetComponent<Health> ();
		if (health != null) {
			health.TakeDamage (10);
		}

		Die();
	}

	void Die()
	{
		pc.BulletDeath(this);
	}

}
