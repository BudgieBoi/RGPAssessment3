using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public PlayerController opponent;
    public bool isPlayerTurn = true;

    public GameObject endGameScreen;
    public TextMeshProUGUI endGameMessage;
    public Button restartButton;

    void Start()
    {
        player.GetRandomItem();
        opponent.GetRandomItem();
        endGameScreen.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        CheckGameOver();
    }

    public void EndTurn()
    {
        if (isPlayerTurn)
        {
            player.hasTurn = false;
            opponent.hasTurn = true;
            StartCoroutine(HandleTurnDelay());
        }
        else
        {
            opponent.hasTurn = false;
            player.hasTurn = true;
            StartCoroutine(HandleTurnDelay());
        }
    }

    private IEnumerator HandleTurnDelay()
    {
        yield return new WaitForSeconds(2.0f); // 2-second delay
        if (isPlayerTurn)
        {
            isPlayerTurn = false;
            OpponentTurn();
        }
        else
        {
            isPlayerTurn = true;
        }
    }

    void OpponentTurn()
    {
        if (opponent.crossUsed)
        {
            opponent.Shoot(player);
            opponent.crossUsed = false;
        }
        else
        {
            opponent.GetComponent<OpponentController>().TakeTurn();
        }
        EndTurn();
    }

    void CheckGameOver()
    {
        if (player.health <= 0)
        {
            EndGame("Player loses!");
        }
        else if (opponent.health <= 0)
        {
            EndGame("Player wins!");
        }
    }

    void EndGame(string message)
    {
        endGameScreen.SetActive(true);
        endGameMessage.text = message;
        DisableControls();
    }

    void DisableControls()
    {
        player.hasTurn = false;
        opponent.hasTurn = false;
    }

    void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
