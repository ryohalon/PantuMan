using UnityEngine;
using System.Collections;

public class GirlsMover : MonoBehaviour {

    [SerializeField]
    private float positionTime = 2.0f;

    [SerializeField]
    private float scaleTime = 1.7f;

    [SerializeField]
    private float girlScleMax = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //移動速度（省）
        //iTween.MoveTo(gameObject, iTween.Hash("x", -50.0f, "time", time, "easetype", iTween.EaseType.easeInCubic));
        //移動速度（中）
        iTween.MoveTo(gameObject, iTween.Hash("x", -100.0f, "time", positionTime, "easetype", iTween.EaseType.easeInQuart));
        //移動速度（大）
        //iTween.MoveTo(gameObject, iTween.Hash("x", -50.0f, "time", time, "easetype", iTween.EaseType.easeInQuint));

        iTween.ScaleTo(gameObject, iTween.Hash("y", girlScleMax, "x", girlScleMax, "time", scaleTime, "easetype", iTween.EaseType.easeInQuart));

    }
}
