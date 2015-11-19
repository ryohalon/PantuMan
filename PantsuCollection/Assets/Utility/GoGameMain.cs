using UnityEngine;
using System.Collections;

public class GoGameMain : MonoBehaviour {

    [SerializeField]
    float sceneFadeTime = 3.0f;

    [SerializeField]
    string nextSceneName = "GameMain";

    bool alreadyChangedScene = false;

	// Update is called once per frame
	void Update () {
        if (!alreadyChangedScene && Input.GetMouseButtonDown(0))
        {
            alreadyChangedScene = true;
            StartCoroutine(LoadNextScene());
        }


	}

    [SerializeField]
    GameObject blackScreen = null;
    
    IEnumerator LoadNextScene()
    {
        var screen = GameObject.Find("Canvas").transform;
        var clone = Instantiate(blackScreen);
        clone.transform.SetParent(screen);

        yield return new WaitForSeconds(sceneFadeTime);

        Application.LoadLevel(nextSceneName);


    }
}
