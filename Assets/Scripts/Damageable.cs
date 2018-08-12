using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damageable : MonoBehaviour
{
	public float points = 0.1f;
	public float stunTime = 1f;
	[HideInInspector]
	public bool stun = false;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void AddDamage(Vector3 dir , float damage)
	{
		rb.AddForce(dir * damage);
		StopAllCoroutines();
		StartCoroutine(Stun());
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Death Bound"))
		{
			var battleField = GameObject.FindGameObjectWithTag("BattleField");
			battleField.GetComponent<Shrink>().ScaleUp(points);
			Destroy(gameObject);
		}
	}

	IEnumerator Stun()
	{
		stun = true;
		yield return new WaitForSeconds(stunTime);
		stun = false;
	}
	
}
