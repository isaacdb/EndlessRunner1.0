using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float initialSpeed;
    private float currentSpeed;
    public float forceJump;
    private bool Running;
    public float velocityMultiply;

    public float initialEnergy;
    private float totalEnergy;
    public float downEnergyFactor;
   [SerializeField] private float currentEnergy;

    private Vector2 startPosition;
    private float currentDistance;
    private float nextDistance;
    public float distanceToAtt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        currentEnergy = initialEnergy;
        totalEnergy = initialEnergy;

        UiController.instance.SetEnergySlideValue(currentEnergy, totalEnergy);
    }


    void Update()
    { 
        currentDistance = Vector2.Distance(startPosition, transform.position);

        UiController.instance.SetEnergySlideValue(currentEnergy, totalEnergy);

        if (Input.GetKeyDown(KeyCode.K)) {
            currentSpeed = initialSpeed;
            Running = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) { 
            rb.velocity =new Vector2( rb.velocity.x , forceJump);
        }

        if (currentEnergy <= 0) {
            Time.timeScale = 0;
        }

        if (currentDistance > nextDistance) {
            UiController.instance.SetDistanceValue(currentDistance);
            nextDistance = currentDistance + distanceToAtt;
        }
    }
    public void AddEnergy() {
        currentEnergy += 100;
    }

    private void FixedUpdate()
    {
        rb.velocity =new Vector2 (currentSpeed * Time.deltaTime,rb.velocity.y);
        if (Running)
        {
            currentSpeed *= velocityMultiply;
            currentEnergy -= downEnergyFactor;
        }
    }
}
