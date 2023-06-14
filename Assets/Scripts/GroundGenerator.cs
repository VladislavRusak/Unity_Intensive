using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{   

    public GameObject[] GroundPrefabs;
    private List<GameObject> activeGround = new List<GameObject>();
    private float spawnPos = 0;
    private float GroundLength = 100;//Это длина платформы
    [SerializeField] private Transform player;
    private int startGround = 6;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startGround; i++)
        {
            SpawnGround(Random.Range(0,GroundPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 60 > spawnPos - (startGround * GroundLength))
        {
            SpawnGround(Random.Range(0,GroundPrefabs.Length));
            DeleteGround();
        }
           
    }

    private void SpawnGround(int GroundIndex)
    {
        GameObject nextGround =  Instantiate(GroundPrefabs[GroundIndex], transform.forward * spawnPos, transform.rotation);
        activeGround.Add(nextGround);
        spawnPos += GroundLength;

    }

    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }

}   
//      obstacle