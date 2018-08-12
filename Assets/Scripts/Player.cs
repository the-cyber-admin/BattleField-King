using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public GameObject gameover;

	void OnDestroy()
	{
		gameover.SetActive(true);
	}
}
