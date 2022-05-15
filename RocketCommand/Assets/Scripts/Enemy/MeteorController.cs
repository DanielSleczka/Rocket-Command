using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [Header("Meteors")]
    [SerializeField] private float meteorSpeed;
    [SerializeField] private List<Meteor> meteors;
    [SerializeField] private List<Meteor> currentMeteors;

    [Header("Respawn Position")]
    [SerializeField] private float minPositionToRespawn;
    [SerializeField] private float maxPositionToRespawn;
    private float xPositionToRespawn;

    [Header("Respawn Rotate")]
    [SerializeField] private float minRotate;
    [SerializeField] private float maxRotate;
    private float zRotate;

    [Header("Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float timeToRespawn;

    private void Start()
    {
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        StartCoroutine(RespawnNewMeteor(timeToRespawn));

    }

    public void RespawnMeteors()
    {
        xPositionToRespawn = Random.Range(minPositionToRespawn, maxPositionToRespawn);
        zRotate = Random.Range(minRotate, maxRotate);

        Meteor newMeteor = Instantiate(meteors[Random.Range(0, meteors.Count)]);
        newMeteor.transform.position = new Vector3(xPositionToRespawn, 11f, 0);
        newMeteor.transform.Rotate(0, 0, zRotate);
        currentMeteors.Add(newMeteor);
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        StartCoroutine(RespawnNewMeteor(timeToRespawn));
    }

    private void Update()
    {
        RemoveAllNullMeteors();

        for (int i = currentMeteors.Count - 1; i >= 0; i--)
        {
            currentMeteors[i].transform.Translate(Vector3.right * meteorSpeed * Time.deltaTime);
        }
    }
    private IEnumerator RespawnNewMeteor(float delay)
    {
        yield return new WaitForSeconds(delay);
        RespawnMeteors();
    }

    public void RemoveAllNullMeteors()
    {
        if (currentMeteors.Count > 0)
        {
            currentMeteors.RemoveAll(Meteor => Meteor == null);
        }
    }

}
