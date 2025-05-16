using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public enum PowerType { Shield, Speed, CoinBonus }
	public PowerType type;

	public void Activate()
	{
		switch (type)
		{
			case PowerType.Shield:
				Debug.Log("Shield Activated");
				GameManager.Instance.shieldActive = true;
				break;
			case PowerType.Speed:
				GameManager.Instance.gameSpeed += 2f;
				break;
			case PowerType.CoinBonus:
				ScoreManager.Instance.coins += 10;
				break;
		}
	}
}