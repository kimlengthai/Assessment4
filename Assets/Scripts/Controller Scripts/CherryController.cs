using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject bonusScoreCherry;
    public Transform levelCenter;
    public float moveSpeed = 5f;
    public float spawnInterval = 10f;

    private Camera mainCamera;
    private Vector3 spawnPos;
    private Vector3 destroyPos;

    // Start is called before the first frame update
    void Start()
    {
    //    mainCamera = Camera.main;
    //    StartCoroutine(SpawnCherry);
    }

    /*IEnumerator SpawnCherry()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnCherry();
        }
    }

    void SpawnNewCherry()
    {
        float randomX = Random.Range(0f,1f) > 0.5f ? -1f : 1f;
        float randomY = Random.Range(0f,1f) > 0.5f ? -1f : 1f;

        spawnPos = new Vector3(randomX * mainCamera.orthographicSize * mainCamera.aspect * 2f, randomY * mainCamera.orthographicSize * 2f, 0f);

        GameObject cherry = Instantiate(bonusScoreCherry, spawnPos, Quaternion.identity);

        destroyPos = levelCenter.position - (spawnPos - levelCenter.position).normalized * mainCamera.orthographicSize * mainCamera.aspect * 2f;

        StartCoroutine(MoveCherry(cherry.transform));
    }

    IEnumerator MoveCherry(Transform cherryTransform)
    {
        float journeyLength = Vector3.Distance(cherryTransform.position, destroyPos);
        float startTime = Time.time;

        while (cherryTransform.position != destroyPos)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            cherryTransform.position = Vector3.Lerp(spawnPos, destroyPos, journeyFraction);

            yield return null;
        }

        Destroy(cherryTransform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
}
