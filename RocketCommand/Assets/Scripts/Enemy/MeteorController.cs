using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [Header("Meteors")]
    [SerializeField] private float meteorSpeed;
    [SerializeField] private List<Meteor> meteors;
    [SerializeField] private List<Meteor> currentMeteors;
    [SerializeField] private Transform explosion;

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

    public void InitializeController()
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

    public void UpdateController()
    {
        RemoveAllNullMeteorsFromList();

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

    public void RemoveAllNullMeteorsFromList()
    {
        if (currentMeteors.Count > 0)
        {
            currentMeteors.RemoveAll(Meteor => Meteor == null);
        }
    }


    public void DestroyAllMeteors()
    {
        StartCoroutine(KillThemAll(0.2f));
    }

    private IEnumerator KillThemAll(float delay)
    {
        int temporary = currentMeteors.Count;

        for (int i = temporary - 1; i >= 0; i--)
        {
            currentMeteors[i]?.MeteorExplosion();
            currentMeteors[i]?.GetPointsFromMeteors();
            yield return new WaitForSeconds(delay);
            temporary = currentMeteors.Count;
        }
    }
}
