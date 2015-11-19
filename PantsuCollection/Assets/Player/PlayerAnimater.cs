using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimater : MonoBehaviour {

    [SerializeField]
    List<Sprite> spriteList = new List<Sprite>();

    Image thisImage = null;

    enum AnimationID
    {
        waiting,
        attack01,
        attack02
    }


	// Use this for initialization
	void Start () {
        thisImage = GetComponent<Image>();

        if (spriteList.Count <= 0)
        {
            Debug.Log("playerAnimation is empty");
        }

        Initialize();
	}

    void Initialize()
    {
        thisImage.sprite = spriteList[0];
    }

    [SerializeField, Tooltip("攻撃中の画像を表示する時間")]
    float attackingTime = 1.0f;

    bool isAttacking = false;

    float animationTime = 0.0f;

	// Update is called once per frame
	void Update () {
        if (!isAttacking && Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            thisImage.sprite = spriteList[(int)AnimationID.attack01];

        }

        if (isAttacking)
        {
            animationTime += Time.deltaTime;
            if (animationTime >= attackingTime)
            {
                isAttacking = false;
                animationTime = 0f;

                thisImage.sprite = spriteList[(int)AnimationID.waiting];
            }


        }



    }
}
