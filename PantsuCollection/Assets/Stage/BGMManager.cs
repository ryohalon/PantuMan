using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {
    [SerializeField]
    AudioClip playingBGM = null;

    TimeManager timeManager = null;
     
    //Use this for initialization
	void Start () {
        timeManager = GetComponent<TimeManager>();
             
	}
	
	// Update is called once per frame
	void Update () {
        if (!timeManager.IsWaiting)
        {

            var audioSource = GetComponent<AudioSource>();

            audioSource.clip = playingBGM;
            audioSource.Play();

            Destroy(this);
        }

	}
}
