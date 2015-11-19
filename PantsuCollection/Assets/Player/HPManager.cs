using UnityEngine;
using System.Collections;

public class HPManager : MonoBehaviour {

    public static int NowHP { get; set; }

    [SerializeField]
    int maxHP = 10;

    PlayerStateManager stateManager = null;

    void Awake()
    {
        NowHP = maxHP;

        stateManager = GetComponent<PlayerStateManager>();
        if (stateManager == null)
        {
            Debug.Log("stateManager is null");
        }

    }


	// Use this for initialization
	void Start () {
	    
	}

    [SerializeField]
    KeyCode damageKey = KeyCode.S;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(damageKey))
        {
            --NowHP;
        }


        if (NowHP <= 0)
        {
            NowHP = 0;
            stateManager.state = PlayerStateManager.State.dead;
        }

	}
}
