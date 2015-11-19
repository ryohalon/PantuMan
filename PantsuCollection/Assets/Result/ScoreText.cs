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
       thisText.text = Score.PantsuCount.Count + "枚";
	}
}
