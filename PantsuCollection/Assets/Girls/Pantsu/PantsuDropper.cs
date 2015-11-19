using UnityEngine;
using System.Collections;

public class PantsuDropper : MonoBehaviour
{

    public bool isFalling { get; set; }

    
  
	[SerializeField]
	private float dropSpeed_x = 1.0f;

	[SerializeField]
	private float dropSpeed_y = 50.0f;

	[SerializeField]
	private float speed_x = 1.0f;

	[SerializeField]
	private float speed_y = 1.0f;
   
	[SerializeField]
	float pant_curve_power_x=0.0f;

	[SerializeField]
	float pant_curve_power_y=-50.0f;

	[SerializeField]
	float pant_slide_power_x=0.0f;

	[SerializeField]
	float pant_slide_power_y=0.0f;

	float destroyTime = 0.0f;

	Animater anime = null;

    // Use this for initialization
    void Start()
    {
		defaultLocalPosition = transform.localPosition =new Vector3 (pant_slide_power_x, pant_slide_power_y, 0f);
		anime = GetComponent<Animater>();
		if (anime == null) {
			Debug.Log ("anime ない");
		} else {
			anime.IsPlay = false;
		}
    }

  
    [SerializeField]
    float shakeValue = 50f;


   
    Vector3 defaultLocalPosition = Vector3.zero;

	public Bezier myBezier;
	private float t = 0f;

    bool isStartFalling = false;

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            if (isStartFalling == false)
            {
				anime.IsPlay = true;
				Pant_Curve();
				destroyTime += Time.deltaTime;

				if(destroyTime >= 1.5f)Destroy(gameObject);

            }

            //gameObject.transform.localPosition = new Vector3(defaultLocalPosition.x + Mathf.Sin(shakingTime) * shakeValue,
                                                             //transform.localPosition.y, transform.localPosition.z);
        }

    }

	void Pant_Curve(){


		transform.Translate (Vector3.down * dropSpeed_y);
		transform.Translate (Vector3.right * dropSpeed_x);

		dropSpeed_x += speed_x;
		dropSpeed_y -= speed_y;
	
	}

}