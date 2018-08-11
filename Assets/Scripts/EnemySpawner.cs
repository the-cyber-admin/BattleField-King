using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	public float timeBetweenSpawns = 1f;
	public int enemyCount = 5;

	public float radius = 35f;
	
	bool doneSpawning = true;
	
	void Update ()
	{
		if (doneSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
			StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		doneSpawning = false;

		for (int i = 0; i < enemyCount; i++)
		{
			redo:
			var randomX = Random.Range(-radius, radius);
			var randomZ = Random.Range(-radius, radius);
			
			var position = new Vector3(randomX , transform.position.y ,randomZ);

			var colls = Physics.OverlapSphere(position, 2f);
			if (colls.Length > 2)
				goto redo;
			
			Instantiate(enemy, position, Quaternion.identity, transform);
			yield return new WaitForSeconds(timeBetweenSpawns);
		}
		
		doneSpawning = true;
	}
}
