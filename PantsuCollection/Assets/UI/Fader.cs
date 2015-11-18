using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour {


    [SerializeField]
    private float fadeInTime = 1.0f;

    [SerializeField]
    private iTween.EaseType fadeInType = iTween.EaseType.linear;

    [SerializeField]
    private float waitTime = 1.0f;

    [SerializeField]
    private float fadeOutTime = 1.0f;

    [SerializeField]
    private iTween.EaseType fadeOutType = iTween.EaseType.linear;


    Image thisImage = null;

    void Awake()
    {
        thisImage = GetComponent<Image>();
        if (thisImage == null)
        {
            Debug.Log("Image is null");
        }

    }



    // Use this for initialization
    void Start() {
        iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1.0f, "time", fadeInTime,"easetype",fadeInType, "onupdate", "UpdateHandler"));

        StartCoroutine("FadeOut");
    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateHandler(float value)
    {
        thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, value);
    }


    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeInTime + waitTime);

        iTween.ValueTo(gameObject, iTween.Hash("from",1.0f, "to", 0f, "time", fadeOutTime, "easetype", fadeOutType, "onupdate", "UpdateHandler"));

        StartCoroutine(DestroyObject());

    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(fadeOutTime + 0.1f);

        Destroy(gameObject);
    }





}
