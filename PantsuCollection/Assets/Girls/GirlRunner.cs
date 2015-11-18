using UnityEngine;
using System.Collections;

public class GirlRunner : MonoBehaviour {

    GirlStateManager stateManager = null;

	// Use this for initialization
	void Start () {
        stateManager = GetComponent<GirlStateManager>();
        if (stateManager == null)
        {
            Debug.Log("stateManager is null");
        }

	}

    [SerializeField]
    float runningSpeed = 5.0f;

	// Update is called once per frame
	void Update () {
        if (stateManager.state == GirlStateManager.State.running)
        {
            transform.localPosition = transform.localPosition - new Vector3(runningSpeed, 0f, 0f);
        }

    }
}
