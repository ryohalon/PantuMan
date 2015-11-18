using UnityEngine;
using System.Collections;

public class GirlSpawnerManager : MonoBehaviour {

    [SerializeField]
    KeyCode spawnKey = KeyCode.A;

    [SerializeField]
    Vector3 spawnPosition = Vector3.zero;

    [SerializeField]
    Transform girlsList = null;

    [SerializeField]
    GameObject girlObject = null;



	// Use this for initialization
	void Start () {
        if (girlObject == null)
        {
            Debug.Log("GirlObject is null");
        }


	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(spawnKey))
        {
            var clone = Instantiate(girlObject);
            clone.transform.SetParent(girlsList);

            var rectTrans = clone.GetComponent<RectTransform>();
            rectTrans.localPosition = spawnPosition;
            rectTrans.localScale = Vector3.one;// new Vector3(1,1,1);    

        }
	}
}
