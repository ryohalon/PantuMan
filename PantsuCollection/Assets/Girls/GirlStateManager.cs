using UnityEngine;
using System.Collections;

public class GirlStateManager : MonoBehaviour {

    public enum State
    {
        walking,    //こっちに向かってい
        running     //逃げている
    }

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

	}
	
	// Update is called once per frame
	void Update () {

        //! 斬られる処理
        if (state == State.walking && true /*斬られる範囲内*/ && Input.GetMouseButtonDown(0))
        {
            GetComponent<PantsuManager>().canDropped = true;
            state = State.running;
        }

    }
}
