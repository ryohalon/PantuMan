using UnityEngine;
using System.Collections;

public class IconMover : MonoBehaviour {

    public float moveTime { get; set; }

    public iTween.EaseType easeType { get; set; }

    [SerializeField]
    float StartY = -30;

    [SerializeField]
    float GoalY = -680;


    //Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(0, StartY, 0);
        iTween.MoveTo(gameObject, iTween.Hash("islocal" ,true, "y", GoalY, "time", moveTime, "easeType", iTween.EaseType.linear));
        Destroy(gameObject, moveTime + 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
