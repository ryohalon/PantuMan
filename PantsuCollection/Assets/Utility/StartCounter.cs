using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartCounter : MonoBehaviour {

    [SerializeField]
    TimeManager timeManager = null;

    [SerializeField]
    string waitingMessage = "Waiting...";

    [SerializeField]
    int waitingMessageSize = 82;


    [SerializeField]
    string startMessage = "START!!";

    [SerializeField]
    int startMessageSize = 108;


    Text thisText = null;

	// Use this for initialization
	void Start () {
        thisText = GetComponent<Text>();
        if (thisText == null)
        {
            Debug.Log("thisText is null");
        }

        if (timeManager == null)
        {
            Debug.Log("timeManager is null");
        }


    }

    bool alreadyCallDestroy = false;

    // Update is called once per frame
    void Update () {

        if(timeManager.IsWaiting)
        {
            thisText.text = waitingMessage;
            thisText.fontSize = waitingMessageSize;

            thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, timeManager.WaitingTime + 0.1f - timeManager.NowTime % timeManager.WaitingTime);
        }
        else 
        {
            if (!alreadyCallDestroy)
            {
                Destroy(gameObject, 1.0f);
                alreadyCallDestroy = true;
                thisText.fontSize = startMessageSize;
            }

            thisText.text = startMessage;
            thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, 1f);

        }
    }
}
