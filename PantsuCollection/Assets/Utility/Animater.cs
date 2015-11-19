using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Animater : MonoBehaviour {

    [System.Serializable]
    public class AnimationData
    {
        public Sprite sprite;
        public float animationTime;
    }

    [SerializeField]
    List<AnimationData> animationDataList = new List<AnimationData>();

    Image thisImage = null;

    [SerializeField]
    int nowAnimationIndex = 0;

    float playingTime = 0.0f;

	public bool IsPlay { get; set;}

	void Awake()
	{
		IsPlay = true;
	}

	// Use this for initialization
	void Start () {
        thisImage = GetComponent<Image>();
        if (thisImage == null)
        {
            Debug.Log("thisImage is null");
            Destroy(this);
        }

        if (animationDataList.Count <= 0)
        {
            Debug.Log("animationDataList is empty");
        }

        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
		if (IsPlay == false)
			return;

        playingTime += Time.deltaTime;
        if (playingTime >= animationDataList[nowAnimationIndex].animationTime)
        {
            ++nowAnimationIndex;
            nowAnimationIndex %= animationDataList.Count;

            thisImage.sprite = animationDataList[nowAnimationIndex].sprite;

            playingTime = 0.0f;
        }

    }

    void Initialize()
    {
        nowAnimationIndex = 0;
        thisImage.sprite = animationDataList[nowAnimationIndex].sprite;
    }

}
