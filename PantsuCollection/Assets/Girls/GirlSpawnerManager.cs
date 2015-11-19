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

    [SerializeField]
    GameObject girlIcon = null;

    [SerializeField]
    GameObject ossanObject = null;

    [SerializeField]
    GameObject ossanIcon = null;

    [SerializeField]
    TimeManager timeManager = null;

    private float arrivalProbability = 0.0f;

    [SerializeField]
    private float girlArrivalProbability = 70.0f;

    [SerializeField]
    private float probabilityMin = 0.0f;

    [SerializeField]
    private float probabilityMax = 100.0f;

    [SerializeField]
    Transform enemyBar = null;

    [SerializeField]
    private int charachange = 0;


    // Use this for initialization
    void Start () {
        if (girlObject == null)
        {
            Debug.Log("GirlObject is null");
        }

        if (timeManager == null)
        {
            Debug.Log("timeManager is null");
        }

        coolTime = spawnInterval;
	}
    [SerializeField]
    float spawnInterval = 5.0f;

    [SerializeField]
    float minSpawnInterval = 0.5f;
    [SerializeField]
    float maxSpawnInterval = 5.0f;

    float coolTime = 0.0f;
	// Update is called once per frame
	void Update () {
        if (timeManager.IsWaiting) return;



        if (spawnInterval <= minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }
        else
        {
            spawnInterval -= ((maxSpawnInterval - minSpawnInterval) / 60f) * Time.deltaTime;
        }



        coolTime += Time.deltaTime;
        if (coolTime >= spawnInterval)
        {
            coolTime = 0f;
            Spawn();
        }

    }

    void CharaChange(GameObject obj)
    {

        var animaters = obj.GetComponents<Animater>();

        if (animaters == null) return;

        charachange = Random.Range(0, animaters.Length);
        Destroy(animaters[charachange]);

    }

    void Spawn()
    {
        arrivalProbability = Random.Range(probabilityMin, probabilityMax);

        GameObject clone = null;

        if (arrivalProbability <= girlArrivalProbability)
        {
            clone = Instantiate(girlObject);
            var girlIconClone = Instantiate(girlIcon);
            girlIconClone.transform.SetParent(enemyBar);
            girlIconClone.transform.localScale = Vector3.one;
            girlIconClone.GetComponent<IconMover>().moveTime = clone.GetComponent<GirlStateManager>().lifeTime;

            CharaChange(clone);

        }
        else
        {
            clone = Instantiate(ossanObject);
            var ossanIconClone = Instantiate(ossanIcon);
            ossanIconClone.transform.SetParent(enemyBar);
            ossanIconClone.transform.localScale = Vector3.one;
            ossanIconClone.GetComponent<IconMover>().moveTime = clone.GetComponent<GirlStateManager>().lifeTime;


            clone.GetComponent<GirlStateManager>().IsOssan = true;
        }

        clone.transform.SetParent(girlsList);

        var rectTrans = clone.GetComponent<RectTransform>();
        rectTrans.localPosition = spawnPosition;
        rectTrans.localScale = spawnScale;


    }

}
