using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Invoke("MakeDecision", 2f); // AI takes a decision after a short delay
    }

    void MakeDecision()
    {
        if(gameManager.opponentHasSingleAction)
        {
            // If the opponent can only perform one action, make a decision and reset the flag
            if(!UseHealingOrDefensiveItem())
            {
                ShootPlayer(); // Default action if no healing/defensive item is used
            }

            gameManager.opponentHasSingleAction = false; // Reset the flag after the single action
        }
        else
        {
            // Normal decision-making process
            if(gameManager.opponentHealth <= 1)
            {
                if(UseHealingOrDefensiveItem()) return;
            }

            if(gameManager.currentShells > 3)
            {
                if(UseRandomItem()) return;
            }

            ShootPlayer();
        }

        bool UseHealingOrDefensiveItem()
        {
            Item opponentItem = gameManager.opponentItemSlot.GetComponentInChildren<Item>();

            if(opponentItem != null)
            {
                if(opponentItem.itemType == ItemType.Syringe && gameManager.opponentHealth < 3)
                {
                    opponentItem.UseItem();
                    Debug.Log("Opponent used Syringe.");

                    return true;
                }
                else if(opponentItem.itemType == ItemType.Cross)
                {
                    opponentItem.UseItem();
                    Debug.Log("Opponent used Cross.");

                    return true;
                }
                else if(opponentItem.itemType == ItemType.Mirror)
                {
                    opponentItem.UseItem();
                    Debug.Log("Opponent used Mirror.");

                    return true;
                }
            }

            return false;
        }

        bool UseRandomItem()
        {
            Item opponentItem = gameManager.opponentItemSlot.GetComponentInChildren<Item>();

            if(opponentItem != null)
            {
                if(opponentItem.itemType == ItemType.Coin || opponentItem.itemType == ItemType.Mirror)
                {
                    opponentItem.UseItem();
                    Debug.Log("Opponent used " + opponentItem.itemType + ".");

                    return true;
                }
            }

            return false;
        }

        void ShootPlayer()
        {
            gameManager.Shoot(false);
            Debug.Log("Opponent shot the player.");
        }
    }
}
