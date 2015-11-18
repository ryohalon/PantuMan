using UnityEngine;
using System.Collections;

public class GirlStateManager : MonoBehaviour {

    public enum State
    {
        walking,    //こっちに向かってい
        running     //逃げている
    }

    public State state = State.walking;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //! 斬られる処理
        if (state == State.walking && true /*斬られる範囲内*/ && Input.GetMouseButtonDown(0))
        {
            Debug.Log("kita");
            GetComponent<PantsuManager>().canDropped = true;
            state = State.running;
        }

    }
}
