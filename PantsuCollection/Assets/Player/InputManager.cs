using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    [SerializeField]
    Canvas screenCanvas = null;

    [SerializeField]
    GameObject slashEffect = null;

    [SerializeField]
    GameObject slashLogoEffect = null;

    [SerializeField]
    private Vector3 srashLogoEffectPosition = new Vector3(0.0f, 0.0f, 0.0f);

    [SerializeField]
    private float randomMin = -100.0f;

    [SerializeField]
    private float randomMax = 100.0f;

    [SerializeField]
    int sourceNumber = 1;

    AudioSource[] audioSources = null;

    [SerializeField]
    AudioClip SlashSE = null;


	// Use this for initialization
	void Start () {

        if (screenCanvas == null)
        {
            Debug.Log("screenCanvas is null");
        }

        if (slashEffect == null)
        {
            Debug.Log("slashEffect is null");
        }

        audioSources = new AudioSource[sourceNumber];
        for (int i = 0; i < sourceNumber; ++i)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }


        for (int i = 0; i < sourceNumber; ++i)
        {
            audioSources[i].Stop();
            audioSources[i].playOnAwake = false;
            audioSources[i].clip = SlashSE;
        }




    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var clone = Instantiate(slashEffect);
            clone.transform.SetParent(screenCanvas.gameObject.transform);
            clone.transform.localPosition = Vector3.zero;

            srashLogoEffectPosition =new Vector3(Random.Range(randomMin, randomMax), Random.Range(randomMin, randomMax));

            var clone2 = Instantiate(slashLogoEffect);
            clone2.transform.SetParent(screenCanvas.gameObject.transform);
            clone2.transform.localPosition = srashLogoEffectPosition;

            //音再生
            for (int i = 0; i < sourceNumber; ++i)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                    break;
                }
            }

            

        }
        
	}
}
