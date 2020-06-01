using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public List<GameObject> plataformas = new List<GameObject>();

    public GameObject objeto;

    [SerializeField] private List<GameObject> plataformasOn = new List<GameObject>();
   [SerializeField] private List<GameObject> plataformasOff = new List<GameObject>();

    private Vector2 lastEndPoint;
    private Vector2 initialPoint;
    public Player player;

    public float distanceToSpawn;

    public float distanceToDisarme;
    public static NewSpawner instance;
    void Start()
    {
        instance = this;
        SpawnStart();
        CheckSpawnsListBatery();

        player = FindObjectOfType(typeof(Player)) as Player;
    }
    private void SpawnStart()
    {
        GameObject plataform = GameObject.Instantiate(plataformas[0], new Vector3(0, 0, 0), Quaternion.identity);
        plataformasOn.Add(plataform);
        lastEndPoint = plataform.GetComponent<SolosBehaviour>().finishPoint.transform.position;
        initialPoint = plataform.GetComponent<SolosBehaviour>().initialPoint.transform.position;

        for (int i = 1; i < plataformas.Count; i++)
        {
             plataform = GameObject.Instantiate(plataformas[i], lastEndPoint, Quaternion.identity);
            plataformasOn.Add(plataform);
            lastEndPoint = plataform.GetComponent<SolosBehaviour>().finishPoint.transform.position;

        }
    }
    // Update is called once per frame
    void Update()
  
    {
        if (Vector2.Distance(player.transform.position, lastEndPoint)<distanceToSpawn)
        {
            SpawnPlataforms();
        }
        if (Vector2.Distance(player.transform.position, initialPoint) > distanceToDisarme)
        {
            DisarmePlataforms();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            for (int i = 0; i < plataformasOn.Count; i++)
            {
               // plataformasOn[i].SetActive(false);
                Debug.Log(plataformasOn[i].GetComponent<SolosBehaviour>().finishPoint.transform.position);
            }
        }
    }
    private void SpawnPlataforms() {
       GameObject plataform = plataformasOff[Random.Range(0, plataformasOff.Count)];
        plataform.transform.position = (lastEndPoint);
        plataform.SetActive(true);
       /* if (plataform.GetComponent<SolosBehaviour>().coletaveis.Count != 0)
        {
            int coinsCount = plataform.GetComponent<SolosBehaviour>().coletaveis.Count;
            for (int i = 0; i < coinsCount; i++)
            {
                plataform.GetComponent<SolosBehaviour>().coletaveis[i].gameObject.SetActive(true);
            }
        }*/
        lastEndPoint = plataform.GetComponent<SolosBehaviour>().finishPoint.transform.position;
        plataformasOn.Add(plataform);
        plataformasOff.Remove(plataform);
    }
    private void DisarmePlataforms() {
        plataformasOn[0].SetActive(false);
        plataformasOff.Add(plataformasOn[0]);
        plataformasOn.Remove(plataformasOn[0]);
        initialPoint = plataformasOn[0].GetComponent<SolosBehaviour>().initialPoint.transform.position;
    }
    void CheckSpawnsListBatery()
    {
        for (int i = 0; i < plataformas.Count; i++) {
           Debug.Log( plataformas[i].GetComponent<SolosBehaviour>().pointBaterySpawn.transform.position);
        }/*
        foreach (GameObject plataform in plataformas)
        {
          Vector3 spawn=  plataform[i].GetComponent<SolosBehaviour>().pointBaterySpawn.transform.position;
            Debug.Log(spawn);
            Instantiate(objeto, spawn, Quaternion.identity);
            i++;
              if (plataform.GetComponent<SolosBehaviour>().coletaveis.Count != 0)
              {
                  Vector3 spawn = plataform.GetComponent<SolosBehaviour>().coletaveis[0].gameObject.transform.position;
                  Debug.Log(spawn);
                  Instantiate(objeto, spawn, Quaternion.identity);

                  // spawnBateryPoints.Add(spawn);
              }*/

        
    }
}
