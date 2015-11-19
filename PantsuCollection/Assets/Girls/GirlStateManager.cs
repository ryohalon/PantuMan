using UnityEngine;
using System.Collections;

public class GirlStateManager : MonoBehaviour {

    public bool isOssan { get;set; }

    public enum State
    {
        walking,    //こっちに向かってい
        running     //逃げている
    }

    [SerializeField]
    private float lifeTime = 2.0f;

    private float totalTime = 0.0f;

    [SerializeField]
    public float attainmentLevel = 0.0f;

    [SerializeField]
    private float girlMoveSpeed = 1.0f;

    [SerializeField]
    private float beginKillZone = 80.0f;

    [SerializeField]
    private float endKillZone = 90.0f;

    public State state = State.walking;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime+0.1f);

        totalTime = 0.0f;
	}

    void Awake(){
        GetComponent<GirlsMover>().positionTime = lifeTime;
    }
	
	// Update is called once per frame
	void Update () {

        totalTime += Time.deltaTime;

        //! 斬られる処理
        if (state == State.walking && IsKillingTime() && Input.GetMouseButtonDown(0))
        {
            GetComponent<PantsuManager>().canDropped = true;
            state = State.running;
            Score.PantsuCount += 1;
        }

    }

    public bool IsKillingTime(){

        if (totalTime <= lifeTime * (beginKillZone / 100.0f)) return false;
        if (totalTime >= lifeTime * (endKillZone / 100.0f)) return false;

        return true;
    }

}
