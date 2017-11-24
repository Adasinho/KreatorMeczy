using UnityEngine;
using System.Collections;

public class ChangeCanvas : MonoBehaviour {

	public GameObject oldCanvas;
	public GameObject newCanvas;

	public void changeCanvas()
	{
		oldCanvas.GetComponent<Animator>().Play("Move");
		//oldCanvas.SetActive (false);

		//newCanvas.SetActive (true);
		newCanvas.GetComponent<Animator>().Play("Back");
	}
}
