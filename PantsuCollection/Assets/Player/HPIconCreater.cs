using UnityEngine;
using System.Collections;

public class HPIconCreater : MonoBehaviour {

    [SerializeField]
    GameObject hpIconObj = null;

    [SerializeField]
    Vector3 iconBasePosition = new Vector3(400f, 300f, 0f);

    [SerializeField]
    float iconXDistance = 90f;

    HPManager hpManager = null;

	// Use this for initialization
	void Start () {
        hpManager = GetComponent<HPManager>();
        if(hpManager == null)
        {
            Debug.Log("hpManager is null");
        }

        for (int iconNumber = 0; iconNumber < HPManager.NowHP; ++iconNumber)
        {
            var clone = Instantiate(hpIconObj);
            clone.transform.SetParent(transform);
            clone.name = "HPIcon" + (iconNumber + 1);
            clone.transform.localScale = Vector3.one;
            clone.transform.localPosition = iconBasePosition - new Vector3(iconXDistance * iconNumber, 0f, 0f);
            clone.GetComponent<HPIconStateChecker>().DeadLineHP = iconNumber + 1;
        }


	}
	
}
