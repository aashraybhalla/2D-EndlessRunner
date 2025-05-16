using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance;

	public float distance;
	public int coins;
	public int lives = 3;

	private bool isGameOver;

	public float scoreMultiplier = 1f;
	public Transform player;

	public TextMeshProUGUI distanceText;
	public TextMeshProUGUI coinsText;
	public TextMeshProUGUI livesText;

	void Awake()
	{
		Instance = this;
		distanceText.text = "Score: " + Mathf.FloorToInt(distance);
		coinsText.text = "Coins: " + coins;
		livesText.text = "Lives: " + lives;
	}

	void Update()
	{
		distanceText.text = "Score: " + Mathf.FloorToInt(distance);
		
		if (!isGameOver)
			distance += Time.deltaTime * scoreMultiplier;
	}

	public void CollectCoin()
	{
		coins++;
		coinsText.text = "Coins: " + coins;
		Debug.Log("Coins: " + coins);
	}

	public void TakeDamage()
	{
		
		lives--;
		livesText.text = "Lives: " + lives;
		Debug.Log("Lives: " + lives);
		if (lives <= 0)
			GameOver();
	}

	private void GameOver()
	{
		isGameOver = true;
		Debug.Log("GAME OVER");
		Time.timeScale = 0f; // Pause game
	}
}