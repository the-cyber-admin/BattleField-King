using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
	public Transform target;
	public float speed = 5f;
	public float angularSpeed = 30f;
	public float power = 10f;
	public float movementSmoothing = 0.05f;

	Rigidbody rb;
	Damageable damageable;
	void Awake()
	{
		damageable = GetComponent<Damageable>();
		
		rb = GetComponent<Rigidbody>();
		if (target == null)
			target = GameObject.FindWithTag("Player").transform;
	}
	
	bool onGround;
	Vector3 velocity;
	void Update()
	{
		if(damageable.stun)
			return;
		if(!onGround)
			return;
		if(target == null)
			return;
		var dir = target.position - transform.position;

		dir.Normalize();
		rb.AddForce(dir * speed);
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("BattleField"))
			onGround = true;
		
		else if (other.collider.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Rigidbody>()
				.AddForce((other.transform.position - transform.position).normalized * power);
		}
	}
	
	void OnCollisionExit(Collision other)
	{
		if (other.collider.CompareTag("BattleField"))
		{
			onGround = false;
		}
	}
	
}
