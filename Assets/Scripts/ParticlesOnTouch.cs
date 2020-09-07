using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParticlesOnTouch : MonoBehaviour
{
	public GameObject particlesPrefab;

	GameObject clone;
	Touch touch;
	Vector3 touchPosition;

	void Update()
	{
		// if (Input.touchCount > 0) 
		// {
		// 	touch = Input.GetTouch (0);

		// 	if (touch.phase == TouchPhase.Began) 
		// 	{
		// 		touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
		// 		touchPosition.z = 0;

		// 		clone = Instantiate(particlesPrefab, touchPosition, particlesPrefab.transform.rotation);
		// 		clone.GetComponent<ParticleSystem>().Emit(1); //Emit one ripple
		// 		Destroy(clone, 2f); //Destroy instance after 2 seconds
		// 	}
		// }
	}

	public void OnImageClick()
    {
    	touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		touchPosition.z = 0;

		clone = Instantiate(particlesPrefab, touchPosition, particlesPrefab.transform.rotation);
		clone.GetComponent<ParticleSystem>().Emit(1);
		Destroy(clone, 2f);
    }
}
