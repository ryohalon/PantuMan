using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartCounter : MonoBehaviour {

    [SerializeField]
    TimeManager timeManager = null;

    [SerializeField]
    string startMessage = "START!!";

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
            thisText.text = (timeManager.WaitingTime - timeManager.NowTime).ToString("N2");

            thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, 1.1f - timeManager.NowTime % 1.0f);
        }
        else 
        {
            if (!alreadyCallDestroy)
            {
                Destroy(gameObject, 1.0f);
                alreadyCallDestroy = true;
            }

            thisText.text = startMessage;
            thisText.color = new Color(thisText.color.r, thisText.color.g, thisText.color.b, 1f);

        }
    }
}
