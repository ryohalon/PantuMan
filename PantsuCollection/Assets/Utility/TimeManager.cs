using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public bool IsWaiting { get; private set; }

    //開始してからの時間
    public float NowTime { get; private set; }

    /// <summary>
    /// シーン開始からのスタートまでの時間
    /// </summary>
    [SerializeField]
    float waitingTime = 5.0f;
    public float WaitingTime { get { return waitingTime; } }

	// Use this for initialization
	void Start () {
        IsWaiting = true;
        NowTime = 0.0000f;
	}
	
	// Update is called once per frame
	void Update () {
        if(IsWaiting)
        {
            NowTime += Time.deltaTime;
            if (NowTime >= waitingTime)
            {
                IsWaiting = false;
            }
        }
    }
}
