using UnityEngine;
using System.Collections;

public class PantsuManager : MonoBehaviour {

    Transform droppedPantsuList = null;

    public bool canDropped { get; set; }

    void Awake()
    {
        canDropped = false;
    }

	// Use this for initialization
	void Start () {

        droppedPantsuList = transform.parent.GetComponent<GirlsToPantsuLinker>().droppedPantsuList;

	    if(droppedPantsuList == null)
        {
            Debug.Log("droppedPantsuList is null");
        }



	}
	
	// Update is called once per frame
	void Update () {
	    if(canDropped)
        {
            var pantsu = transform.GetChild(0);

            if (pantsu != null)
            {
                pantsu.SetParent(droppedPantsuList);
                pantsu.position = gameObject.transform.position;
                pantsu.GetComponent<PantsuDropper>().isFalling = true;
            }

            Destroy(this);
         }
	}

    void OnDestroy()
    {
        if (transform.childCount >= 1 && !GetComponent<GirlStateManager>().IsOssan)
        {
            --HPManager.NowHP;
        }

    }

}
