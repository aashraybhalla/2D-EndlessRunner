using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	
	public bool shieldActive = false;

	public float gameSpeed = 5f;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}
}