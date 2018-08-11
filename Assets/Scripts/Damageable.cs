using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damageable : MonoBehaviour
{
	public float points = 0.1f;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void AddDamage(Vector3 dir , float damage)
	{
		rb.AddForce(dir * damage);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Death Bound"))
		{
			var battleField = GameObject.FindGameObjectWithTag("BattleField");
			battleField.GetComponent<Shrink>().ScaleUp(points);
		}
	}
}
