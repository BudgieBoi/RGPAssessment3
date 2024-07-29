using UnityEngine;

public class OpponentController : MonoBehaviour
{
	public PlayerController player;
	public PlayerController opponent;

	public void TakeTurn()
	{
		int action = Random.Range(0, 3);
		if (opponent.crossUsed)
		{
			opponent.Shoot(player);
			opponent.crossUsed = false;
		}
		else
		{
			if (action == 0 && opponent.crossPrefab != null)
			{
				opponent.UseCross(player);
				if (opponent.crossUsed)
				{
					return; // End turn if cross is used
				}
			}
			else if (action == 1 && opponent.syringePrefab != null)
			{
				opponent.UseSyringe();
				if (opponent.crossUsed)
				{
					return; // End turn if cross is used
				}
			}
			else
			{
				opponent.Shoot(player);
			}
		}
	}
}