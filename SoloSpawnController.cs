using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Playables;

public class SoloSpawnController : MonoBehaviour
{
    public Transform startPlataform;
    public List<Transform> soloList;
    [SerializeField] private List<Transform> soloSpawneds;
    private Vector2 lastEndPoint;
    private Vector2 initialPoint;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
        soloSpawneds.Add(startPlataform);
        lastEndPoint = startPlataform.Find("EndPoint").position;
        initialPoint = startPlataform.Find("InitialPoint").position;
        SpawnStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnSelect();
        }
        if (Vector2.Distance(player.transform.position, lastEndPoint) < 30f)
        {
            SpawnSelect();
        }
        if (Vector2.Distance(player.transform.position, initialPoint) > 30f)
        {
            CheckLastPlataform();
            //CheckInitialPlataform(CheckLastPlataform());
        }
    }
    private void SpawnSelect()
    {
        Transform randomSolo = soloList[Random.Range(0, soloList.Count)];
        randomSolo = ControllerPlataforms(randomSolo);
        if (randomSolo != null)
        {
            randomSolo.gameObject.SetActive(true);
            Transform lastPlataform = SpawnPlataforms(randomSolo, lastEndPoint);
            soloSpawneds.Add(randomSolo);
            lastEndPoint = lastPlataform.Find("EndPoint").position;
        }
    }
    private Transform SpawnPlataforms(Transform plataform, Vector2 spawnPoint)
    {
        Transform spawner = Instantiate(plataform, spawnPoint, Quaternion.identity);
        return spawner;
    }
    private void SpawnStart()
    {
        Transform randomSolo = soloList[Random.Range(0, soloList.Count)];
        soloSpawneds.Add(randomSolo);
        randomSolo.gameObject.SetActive(true);
        Transform lastPlataform = SpawnPlataforms(randomSolo, lastEndPoint);
        lastEndPoint = lastPlataform.Find("EndPoint").position;
    }
    private Transform ControllerPlataforms(Transform randomSolo)
    {
        bool repeatPlataform = false;
        foreach (Transform solos in soloSpawneds)
        {
            if (randomSolo.name == solos.name)
            {
                repeatPlataform = true;
            }
        }
        if (!repeatPlataform)
        {
            return (randomSolo);
        }
        return (null);
    }
    private void CheckLastPlataform()
    {
        float distancia = 0;
        float distanciamaxima = 0;
        int positionList = 0;
        Vector2 playerPosition = player.transform.position;
        Transform plataforminitial = null;
        int i = 0;
        /*  foreach (Transform solos in soloSpawneds)
          {
              distancia = Vector2.Distance(solos.Find("InitialPoint").position, playerPosition);
              if (distancia > distanciamaxima)
              {
                  distanciamaxima = distancia;
                  plataforminitial = solos;
                  positionList = i;
              }
              i++;
          }*/
        Debug.Log(initialPoint);
        soloSpawneds.Remove(soloSpawneds[0]);
        initialPoint = soloSpawneds[1].Find("InitialPoint").position;

    }
    private void DestroyPlataform(Transform plataformToDestroy)
    {
        if (plataformToDestroy != null)
        {
            plataformToDestroy.gameObject.SetActive(false);
        }
    }
}
