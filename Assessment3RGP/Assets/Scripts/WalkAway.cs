using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkAway : MonoBehaviour
{
	public GameObject panel;
	
	void EndGame(string message)
	{
		panel.SetActive(true);
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene("MainGameScene");
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}
}