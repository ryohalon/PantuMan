using UnityEngine;
using System.Collections;

public class PantsuDropper : MonoBehaviour
{

    public bool isFalling { get; set; }

    
  
	[SerializeField]
	private float dropSpeed_x = 1.0f;

	[SerializeField]
	private float dropSpeed_y = 200.0f;
   
	[SerializeField]
	float pant_curve_power_x=0.0f;

	[SerializeField]
	float pant_curve_power_y=-50.0f;

	[SerializeField]
	float pant_slide_power_x=0.0f;

	[SerializeField]
	float pant_slide_power_y=0.0f;



    // Use this for initialization
    void Start()
    {
		defaultLocalPosition = transform.localPosition =new Vector3 (pant_slide_power_x, pant_slide_power_y, 0f);


    }

  
    [SerializeField]
    float shakeValue = 50f;


   
    Vector3 defaultLocalPosition = Vector3.zero;

    float shakingTime = 0.0f;

	public Bezier myBezier;
	private float t = 0f;

    bool isStartFalling = false;

    // Update is called once per frame
    void Update()
    {

        shakingTime += Time.deltaTime;
        if (isFalling)
        {
            if (isStartFalling == false)
            {
				Pant_Curve();
            }

            //gameObject.transform.localPosition = new Vector3(defaultLocalPosition.x + Mathf.Sin(shakingTime) * shakeValue,
                                                             //transform.localPosition.y, transform.localPosition.z);
        }

    }

	void Pant_Curve(){

		//transform.Rotate (pant_curve_power_x,pant_curve_power_y,0);
		//transform.Translate (pant_curve_power_x,pant_curve_power_y ,0,0);
		transform.Translate (Vector3.down * dropSpeed_y);
		transform.Translate (Vector3.right * dropSpeed_x);
		pant_curve_power_x += 0.1f;
		pant_curve_power_y += 0.16f;
		pant_curve_power_y *= -1.0f;

		dropSpeed_x += 0.07f;
		dropSpeed_y -= 0.05f;
	
	}

	void Pant_Slider(){

		if (transform.localPosition.y <= 50) {

			pant_slide_power_x += 1.0f;
			//pant_curve_power_y -= 2.0f;

		}

	}

}