using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    [SerializeField]
    Canvas screenCanvas = null;

    [SerializeField]
    GameObject slashEffect = null;


	// Use this for initialization
	void Start () {

        if (screenCanvas == null)
        {
            Debug.Log("screenCanvas is null");
        }

        if (slashEffect == null)
        {
            Debug.Log("slashEffect is null");
        }


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var clone = Instantiate(slashEffect);
            clone.transform.SetParent(screenCanvas.gameObject.transform);
            clone.transform.localPosition = Vector3.zero;
        }
        
	}
}
