using UnityEngine;
using System.Collections;

public class PlayerStateManager : MonoBehaviour {

    public enum State
    {
        live,
        dead
    }

    public State state { get; set; }

	// Use this for initialization
	void Start () {
	
	}

    bool alreadySceneChanged = false;

	// Update is called once per frame
	void Update () {
        if (state == State.dead && !alreadySceneChanged)
        {

            //! 死亡時の処理
            alreadySceneChanged = true;
            StartCoroutine(LoadNextScene());

        }

	}

    [SerializeField]
    GameObject blackScreen = null;

    [SerializeField]
    float sceneFadeTime = 3.0f;

    IEnumerator LoadNextScene()
    {
        var screen = GameObject.Find("ScreenCanvas").transform;
        var clone = Instantiate(blackScreen);
        clone.transform.SetParent(screen);

        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(sceneFadeTime);

        Application.LoadLevel("Result");


    }

}
