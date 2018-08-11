using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShotController : MonoBehaviour
{
	public float scaleIncreaseFactor = 0.5f;
	public float maxScale = 2f;
	public float lifetime = 3f;
	private float speed = 1f;
	
	Rigidbody rb;
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	bool release = false;
	public void Shoot(Vector3 dir, float force)
	{
		release = true;
		rb.AddForce(speed * force * dir);
	}

	void OnCollisionEnter(Collision other)
	{
		var damageable = other.collider.GetComponent<Damageable>();
		damageable.AddDamage(
			(other.transform.position - transform.position).normalized
			, speed);
	}

	void Update()
	{
		if(release)
			return;
		Scale();
		speed = Mathf.Clamp(speed  + scaleIncreaseFactor * Time.deltaTime , 0 , maxScale + 1f);
	}
	void Scale()
	{
		var scale = transform.localScale;
		
		scale.x = Mathf.Clamp(scale.x + scaleIncreaseFactor * Time.deltaTime, 0, maxScale);
		scale.y = Mathf.Clamp(scale.y + scaleIncreaseFactor * Time.deltaTime, 0, maxScale);
		scale.z = Mathf.Clamp(scale.z + scaleIncreaseFactor * Time.deltaTime, 0, maxScale);

		transform.localScale = scale;
	}
	void OnBecameInvisible()
	{
		Destroy(gameObject , lifetime);
	}
}
