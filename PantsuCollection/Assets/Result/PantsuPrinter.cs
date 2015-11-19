using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PantsuPrinter : MonoBehaviour {

    [SerializeField]
    Vector3 startPosition = Vector3.zero;

    [SerializeField]
    float pantsuDistanceX = 5f;

    [SerializeField]
    float pantsuDistanceY = 5f;


    [SerializeField]
    int lineNumber = 10;

    [SerializeField]
    int lowNumber = 5;

    [SerializeField]
    float delayTime = 0;

    [SerializeField]
    float printInterval = 0.1f;

    [SerializeField]
    List<GameObject> graphics = new List<GameObject>();

    [SerializeField]
    Transform canvas = null;

	// Use this for initialization
	void Start () {

        GameObject tmp = null;
        for (int i = 0; i < Score.PantsuCount.Count; ++i)
        {
            tmp = Instantiate(graphics[Score.PantsuCount[i]]);
            tmp.transform.SetParent(canvas);
            tmp.transform.localScale = Vector3.one;
            tmp.transform.localPosition = startPosition
                + new Vector3(pantsuDistanceX * (i % lineNumber),- pantsuDistanceY * (i / lowNumber), 0f);

        }
    }

    // Update is called once per frame
    void Update () {

	}
}
