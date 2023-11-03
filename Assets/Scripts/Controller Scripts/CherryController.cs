using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float spawnInterval = 10f;
    public GameObject bonusScoreCherry;
    public Transform levelCenter;

    private Camera mainCamera;
    private Vector3 spawnPos;
    private Vector3 destroyPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnBonusCherry());
    }

    IEnumerator SpawnBonusCherry()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBonusCherry();
        }
    }

    void SpawnNewBonusCherry()
    {
        float randomXPos = Random.Range(0f,1f) > 0.5f ? -1f : 1f;
        float randomYPos = Random.Range(0f,1f) > 0.5f ? -1f : 1f;

        spawnPos = new Vector3(randomXPos * mainCamera.orthographicSize * mainCamera.aspect * 2f, randomYPos * mainCamera.orthographicSize * 2f, 0f);

        GameObject cherry = Instantiate(bonusScoreCherry, spawnPos, Quaternion.identity);

        destroyPos = levelCenter.position - (spawnPos - levelCenter.position).normalized * mainCamera.orthographicSize * mainCamera.aspect * 2f;

        StartCoroutine(MoveCherry(cherry.transform));
    }

    IEnumerator MoveCherry(Transform cherryTransform)
    {
        float travelLength = Vector3.Distance(cherryTransform.position, destroyPos);
        float startTime = Time.time;

        while (cherryTransform.position != destroyPos)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float travelFraction = distanceCovered / travelLength;
            cherryTransform.position = Vector3.Lerp(spawnPos, destroyPos, travelFraction);

            yield return null;
        }

        Destroy(cherryTransform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
