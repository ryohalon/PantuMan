using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Score : MonoBehaviour {

    [System.Serializable]
    public class scoreMessage
    {
        public int count;
        public string message;
    }

    [SerializeField]
    List<scoreMessage> messageList = new List<scoreMessage>();

    public static List<int> PantsuCount = new List<int>(); 


    GameObject screenCanvas = null;

	// Use this for initialization
	void Start () {
        PantsuCount.Clear();
        screenCanvas = GameObject.Find("ScreenCanvas");
	}

    [SerializeField]
    GameObject scoreMessageText = null;

	// Update is called once per frame
	void Update () {
        foreach (var message in messageList)
        {
            if (message.count == PantsuCount.Count)
            {
                var clone = Instantiate(scoreMessageText);
                clone.transform.SetParent(screenCanvas.transform);
                clone.transform.localScale = Vector3.one;
                clone.transform.localPosition = Vector3.zero + new Vector3(0,200,0);
                var text = clone.GetComponent<Text>();
                text.text = message.message;

                Destroy(clone, 1.0f);

                break;
            }

        }



	}
}
