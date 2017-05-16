using UnityEngine;
using System.Collections;

public class ChangeStates : MonoBehaviour {

	public int currentIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			ChangePlayerState(0);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			ChangePlayerState(1);
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			ChangePlayerState(2);
		}
	}

	void ChangePlayerState(int index) {

		transform.GetChild(index).gameObject.SetActive(true);
		transform.GetChild(index).position = transform.GetChild(currentIndex).position;
		transform.GetChild(index).localScale = transform.GetChild(currentIndex).localScale;
		transform.GetChild(currentIndex).gameObject.SetActive(false);
		currentIndex = index;
	}
}
