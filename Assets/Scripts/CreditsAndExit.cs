using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAndExit : MonoBehaviour
{
	public GameObject creditsPanel;

	public void OnCreditsClick()
	{
		if(creditsPanel.activeSelf)
		{
			creditsPanel.gameObject.SetActive(false);
		}
		else
		{
			creditsPanel.gameObject.SetActive(true);
		}
		
	}

	public void OnExitClick()
	{
		Application.Quit();
	}
}
