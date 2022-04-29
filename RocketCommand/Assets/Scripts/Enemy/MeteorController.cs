using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] private List<Meteor> meteors;
    [SerializeField] private List<Meteor> currentMeteors;

    [SerializeField] private float minPositionToRespawn;
    [SerializeField] private float maxPositionToRespawn;
    private float xPositionToRespawn;

    [SerializeField] private float minRotate;
    [SerializeField] private float maxRotate;
    private float zRotate;

    [SerializeField] private float meteorSpeed;

    private void Start()
    {
        StartCoroutine(RespawnNewMeteor(2f));
    }

    [ContextMenu("RespawnMeteor")]
    public void RespawnMeteors()
    {
        xPositionToRespawn = Random.Range(minPositionToRespawn, maxPositionToRespawn);
        zRotate = Random.Range(minRotate, maxRotate);

        Meteor newMeteor = Instantiate(meteors[Random.Range(0, meteors.Count)]);
        newMeteor.transform.position = new Vector3(xPositionToRespawn, 11f, 0);
        newMeteor.transform.Rotate(0, 0, zRotate);
        currentMeteors.Add(newMeteor);

        StartCoroutine(RespawnNewMeteor(2f));
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
