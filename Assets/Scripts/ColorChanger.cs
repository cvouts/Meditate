using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChanger : MonoBehaviour
{
	public GameObject startButton, optionsButton, fadeFasterButton, fadeSlowerButton,
		highBrightnessButton, mediumBrightnessButton, lowBrightnessButton,
		creditsButton, creditsPanel, fadeSpeedPanel;

	public GameObject txtmshpro;
	TextMeshProUGUI fadeSpeedText;

   	[SerializeField] float fadeTime, brightness;
	Image imageComponent;
	Color color, startingBrightnessButtonColor, selectedBrightnessButtonColor;
	IEnumerator coroutine;
	float difference, printHelpingVariable;

	void Start()
	{
		imageComponent = GetComponent<Image>();
		color = imageComponent.color;
		coroutine = ChangeColor();
		difference = 0.1f;

		fadeSpeedText = txtmshpro.GetComponent<TextMeshProUGUI>();
		fadeSpeedText.SetText("2x");

		startingBrightnessButtonColor = highBrightnessButton.GetComponent<Image>().color;
		mediumBrightnessButton.GetComponent<Image>().color = new Color(0.097f, 0.636f, 0.981f, 1.0f);
		selectedBrightnessButtonColor = mediumBrightnessButton.GetComponent<Image>().color;
	}

	IEnumerator ChangeColor()
    {
    	float red = color.r;
    	float green = color.g;
    	float blue = color.b;

        while(true)
        {
        	if(red >= brightness && green <= 0f && blue < brightness)
        	{	
    			blue += 1.0f * Time.deltaTime * fadeTime; //1st
        	}
        	else if(blue > 0f)
        	{
        		if(red > 0f)
        		{
        			red -= 1.0f * Time.deltaTime * fadeTime; //2nd
        		}
        		else if(green < brightness)
        		{
        			green += 1.0f * Time.deltaTime * fadeTime; //3rd
        		}
        		else
        		{
        			blue -= 1.0f * Time.deltaTime * fadeTime; //4th
        		}
        	}
        	else if(green > 0f)
        	{
        		if(red < brightness)
        		{
        			red += 1.0f * Time.deltaTime * fadeTime; //5th
        		}
        		else
        		{
        			green -= 1.0f * Time.deltaTime * fadeTime; //6th
        		}
        	}

        	imageComponent.color = new Color(red, green, blue, 1.0f);
        	yield return null;
        }
    }

    public void OnClick()
    {
    	StartCoroutine(coroutine);
    	startButton.gameObject.SetActive(false);
    	optionsButton.gameObject.SetActive(true);
    }

    public void OnOptionsClick()
    {
		if(fadeFasterButton.activeSelf)
		{
			fadeFasterButton.gameObject.SetActive(false);
    		fadeSlowerButton.gameObject.SetActive(false);
    		highBrightnessButton.gameObject.SetActive(false);
    		mediumBrightnessButton.gameObject.SetActive(false);
    		lowBrightnessButton.gameObject.SetActive(false);
    		creditsButton.gameObject.SetActive(false); 
    		creditsPanel.gameObject.SetActive(false);
    		fadeSpeedPanel.gameObject.SetActive(false);
		}
		else
		{
			fadeFasterButton.gameObject.SetActive(true);
    		fadeSlowerButton.gameObject.SetActive(true);
    		highBrightnessButton.gameObject.SetActive(true);
    		mediumBrightnessButton.gameObject.SetActive(true);
    		lowBrightnessButton.gameObject.SetActive(true);
    		creditsButton.gameObject.SetActive(true);	
    		fadeSpeedPanel.gameObject.SetActive(true);
		}
    	
    }

    public void FasterFade()
    {
    	if(fadeTime < 0.5f)
    	{
    		fadeTime += difference;
    		PrintFadeSpeed(fadeTime);
    	}
    }

    public void SlowerFade()
    {
    	if(fadeTime >= 0.2f)
    	{
    		fadeTime -= difference;
    		PrintFadeSpeed(fadeTime);
    	}
    }

    void PrintFadeSpeed(float fadeTime)
    {
    	printHelpingVariable = fadeTime * 10;
		fadeSpeedText.SetText("{0}x", printHelpingVariable);
    }

    public void HightBrightness()
    {
    	brightness = 1.0f;

    	highBrightnessButton.GetComponent<Image>().color = selectedBrightnessButtonColor;
    	mediumBrightnessButton.GetComponent<Image>().color = startingBrightnessButtonColor;
    	lowBrightnessButton.GetComponent<Image>().color = startingBrightnessButtonColor;
    }

    public void MediumBrightness()
    {
    	brightness = 0.78f;

    	highBrightnessButton.GetComponent<Image>().color = startingBrightnessButtonColor;
    	mediumBrightnessButton.GetComponent<Image>().color = selectedBrightnessButtonColor;
    	lowBrightnessButton.GetComponent<Image>().color = startingBrightnessButtonColor;
    }

    public void LowBrightness()
    {
    	brightness = 0.5f;

    	highBrightnessButton.GetComponent<Image>().color = startingBrightnessButtonColor;
    	mediumBrightnessButton.GetComponent<Image>().color = startingBrightnessButtonColor;
    	lowBrightnessButton.GetComponent<Image>().color = selectedBrightnessButtonColor;
    }
}
		//R = 200, G = 0, B = 0 		initial state
		//R = 200, G = 0, B = 200		1st change, Blue goes up
		//R = 0, G = 0, B = 200			2nd change, Red goes down
		//R = 0, G = 200, B = 200		3rd change, Green goes up
		//R = 0, G = 200, B = 0			4th change, Blue goes down
		//R = 200, G = 200, B = 0 		5th change, Red goes up
		//R = 200, G = 0, B = 0		 	6th change, Green goes down, back to initial state
		//https://docs.unity3d.com/ScriptReference/Random.Range.html