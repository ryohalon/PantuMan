using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeLooper : MonoBehaviour
{


    [SerializeField]
    private float fadeInTime = 1.0f;

    [SerializeField]
    private iTween.EaseType fadeInType = iTween.EaseType.linear;


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
    void Start()
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0.3f, "time", fadeInTime, "easetype", fadeInType, "onupdate", "UpdateHandler","looptype",iTween.LoopType.pingPong));

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateHandler(float value)
    {
        thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, value);
    }



}
