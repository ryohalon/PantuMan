using UnityEngine;
using System.Collections;

public class PantsuDropper : MonoBehaviour
{

    public bool isFalling { get; set; }

    [SerializeField, Range(0.0f, 10.0f)]
    float fallingSpeed = 12;
    [SerializeField]
    float fallingLandingTimer_Y = 1.0f;
    float fallingLandingTimer_X = 1.2f;

    [SerializeField]
    iTween.EaseType D_MoveType = iTween.EaseType.easeInOutQuad;

    [SerializeField]
    iTween.EaseType h_MoveType = iTween.EaseType.easeInOutBounce;

    // Use this for initialization
    void Start()
    {
        defaultLocalPosition = transform.localPosition;
    }

    [SerializeField]
    float fallSpeed = -100f;

    [SerializeField]
    float shakeValue = 50f;

    [SerializeField]
    float shakeTimeSpan = 0.5f;

    Vector3 defaultLocalPosition = Vector3.zero;

    float shakingTime = 0.0f;

    bool isStartFalling = false;

    // Update is called once per frame
    void Update()
    {

        shakingTime += Time.deltaTime;
        if (isFalling)
        {
            if (isStartFalling == false)
            {
                iTween.MoveAdd(gameObject, iTween.Hash("y", fallSpeed, "time", fallingLandingTimer_Y, "easetype", D_MoveType));
                iTween.MoveTo(gameObject, iTween.Hash("x", transform.localPosition.x + 500f, "y", transform.localPosition.y + 250, "delay", fallingLandingTimer_X, "time", fallingLandingTimer_X, "easetype", h_MoveType));
                isStartFalling = true;
            }


            gameObject.transform.localPosition = new Vector3(defaultLocalPosition.x + Mathf.Sin(shakingTime) * shakeValue,
                                                             transform.localPosition.y, transform.localPosition.z);

        }

    }
}