using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RC_PickUpUIMove : MonoBehaviour
{

    [Range(-1000f, 1000f)]
	public float TargetPositionLeft = -450f;
	[Range(-1000f, 1000f)]
	public float TargetPositionTop = 160f;
	[Range(0.001f, 1000f)]
	public float Speed = 1.0f;
	public float closeEnough;

	private Vector2 targetPosition;
	private Vector2 currentPosition;
	private RectTransform objTrans;
	private float distanceToTarget;

	public GameObject ResourceImage;
	public GameObject ResourceText;
	public string ResourceTypeName;
	public int textAmount;
	public string getText;

	// Use this for initialization
	void Start ()
	{
		//Get a reference to the UI object
		objTrans = GetComponent<RectTransform> ();

		//Get its current position
		currentPosition = objTrans.anchoredPosition;

		//Get a reference to where we want it to go
		targetPosition = new Vector2(TargetPositionLeft, TargetPositionTop);

		//Run the UpdateTotal, which updates the UI Text for the number of this resource
		UpdateTotal ();
	}

	//This Sets the Resource Type
	public void SetResourceType(string resourceType)
	{
		ResourceTypeName = resourceType;

		switch (ResourceTypeName)
		{
		case "Cherry":
			ResourceImage = GameObject.FindGameObjectWithTag ("Cherry_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("Cherry_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
		case "Pear":
			ResourceImage = GameObject.FindGameObjectWithTag ("Pear_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("Pear_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
		case "Apple":
			ResourceImage = GameObject.FindGameObjectWithTag ("Apple_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("Apple_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
        case "Orange":
			ResourceImage = GameObject.FindGameObjectWithTag ("Orange_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("Orange_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
        case "Poison":
			ResourceImage = GameObject.FindGameObjectWithTag ("Poison_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("Poison_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
        case "BigSurf":
			ResourceImage = GameObject.FindGameObjectWithTag ("BigSurf_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("BigSurf_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
        case "Parley":
			ResourceImage = GameObject.FindGameObjectWithTag ("Parley_Icon");
			ResourceText = GameObject.FindGameObjectWithTag ("Parley_Text");
            getText = ResourceText.GetComponent<TMP_Text>().text;
			break;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		//Get a position that is a little bit closer to our goal position
		objTrans.anchoredPosition = Vector2.Lerp(currentPosition, targetPosition, Speed * Time.deltaTime);

		//Set our object to that new position
		currentPosition = objTrans.anchoredPosition;

		//How far are we from our goal?
		distanceToTarget = Vector2.Distance (currentPosition, targetPosition);
	}

	void LateUpdate()
	{
		//If we are close enough and we want the icon to disappear...
		if (distanceToTarget < closeEnough)
		{
			//Bonus: Make the default icon animate as the new resource is brought in
			//Swell the resource icon

			//Destroy the object, we are done with it!
			Destroy (gameObject);
		}
	}

	void UpdateTotal()
	{
		//Increase the resource count

		//Turn the displayed text into an integer (int) (a number)
		int.TryParse (getText, out textAmount);
		//Increase this number by 1
		textAmount++;

		//Turn this number back into text
		getText = textAmount.ToString ();

		//Update the text object's display
		ResourceText.GetComponent<TMP_Text> ().text = getText;

		//Force a refresh of the mesh display
		ResourceText.GetComponent<TMP_Text> ().ForceMeshUpdate ();
	}
}
