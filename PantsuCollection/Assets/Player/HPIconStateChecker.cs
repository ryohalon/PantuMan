using UnityEngine;
using System.Collections;

public class HPIconStateChecker : MonoBehaviour {

    public int DeadLineHP { get; set; }

    HPManager playerHP = null;

	// Use this for initialization
	void Start () {
        playerHP = transform.parent.GetComponent<HPManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHP.NowHP < DeadLineHP)
        {
            DeadEvent();
        }

	}

    [SerializeField]
    float dyingTime = 1.0f;

    [SerializeField]
    iTween.EaseType easeType = iTween.EaseType.linear;

    void DeadEvent()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("y", 0.0f, "easetype", easeType, "time", dyingTime - 0.1f));

        Destroy(gameObject,dyingTime);
    }


}

