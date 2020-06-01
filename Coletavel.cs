using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public Player player;
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RespawnItem() {
        Debug.Log(gameObject);
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
         //   UiController.instance.SetCoinsValue();
            gameObject.SetActive(false);
            player.AddEnergy();
        }
    }
}
