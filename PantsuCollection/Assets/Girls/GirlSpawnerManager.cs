using UnityEngine;
using System.Collections;

public class GirlSpawnerManager : MonoBehaviour {

    [SerializeField]
    KeyCode spawnKey = KeyCode.A;

    [SerializeField]
    Vector3 spawnPosition = new Vector3(5.0f, 0.0f, 10.0f);

    [SerializeField]
    Vector3 spawnScale = new Vector3(0.1f, 0.1f, 1.0f);

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
            rectTrans.localScale = spawnScale;

        }
	}
}
