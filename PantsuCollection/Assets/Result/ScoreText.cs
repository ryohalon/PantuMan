using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

    Text thisText = null;

	// Use this for initialization
	void Start () {
        thisText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        thisText.text = "もぎ取ったパンツの数" + Score.PantsuCount.ToString();
	}
}
