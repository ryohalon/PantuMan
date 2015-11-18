using UnityEngine;
using System.Collections;

public class GirlsToPantsuLinker : MonoBehaviour {

    public Transform droppedPantsuList = null;

	// Use this for initialization
	void Start () {
        if (droppedPantsuList == null)
        {
            Debug.Log("droppedPantsuList is null");
        }

	}
}
