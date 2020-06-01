using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public GameObject objeto;
    public static GameController instace;

    [SerializeField] private List<Transform> spawnBateryPoints = new List<Transform>();
    public Player player;
    private void Awake()
    {
        if (instace != null)
        {
            Destroy(this);
        }
        else {
            instace = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            PointToSpawnBatery();
        }
    }
    void PointToSpawnBatery() {
        Transform pointSpawn = null;

        foreach (Transform point in spawnBateryPoints)
        {
            GameObject bloco = Instantiate(objeto, point.transform.position, Quaternion.identity);
            Debug.Log((point.transform.position.x - player.transform.position.x));
            if ((point.transform.position.x - player.transform.position.x) > 30) {
                if (pointSpawn != null)
                {
                    if (point.transform.position.x < pointSpawn.transform.position.x) {
                        pointSpawn = point; 
                    }
                }
                else { pointSpawn = point; }


            }
        }
        Debug.Log(pointSpawn);
    }
}
