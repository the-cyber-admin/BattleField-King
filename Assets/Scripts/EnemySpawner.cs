using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	public float timeBetweenSpawns = 1f;
	public int enemyWaveIncreaseCount = 1;
	public int enemyCount = 5;
	public Text roundNumber;

	public float radius = 35f;
	
	bool doneSpawning = true;
	private int round = 0;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		var line = Vector3.forward * radius;
		Gizmos.DrawLine(-line , line);
	}

	void Update ()
	{
		if (doneSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
			StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		roundNumber.text = (++round).ToString();
		doneSpawning = false;
		
		for (int i = 0; i < enemyCount; i++)
		{
			redo:
			var randomCircle = Random.Range(-360, 360);
			var randomRadius = Random.Range(-radius, radius);
			var randomX = Mathf.Sin(randomCircle) * randomRadius;
			var randomZ = Mathf.Cos(randomCircle) * randomRadius;
			
			var position = new Vector3(randomX , transform.position.y ,randomZ);

			var colls = Physics.OverlapSphere(position, 2f);
			if (colls.Length > 2)
				goto redo;
			
			Instantiate(enemy, position, Quaternion.identity, transform);
			yield return new WaitForSeconds(timeBetweenSpawns);
		}

		enemyCount += enemyWaveIncreaseCount;
		doneSpawning = true;
	}
}