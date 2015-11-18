using UnityEngine;
using System.Collections;

public class PantsuDropper : MonoBehaviour {

    public bool isFalling { get; set; }

    [SerializeField,Range(0.0f,10.0f)]
    float fallingSpeed = 10;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (isFalling)
        {
            //            iTween.MoveTo(gameObject, iTween.Hash());
            transform.localPosition = transform.localPosition - new Vector3(0f, fallingSpeed, 0f);

        }    

	}
}
