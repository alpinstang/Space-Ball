using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m/s")] [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xRange = 17f;
    [SerializeField] float yMin = -33f;
    [SerializeField] float yMax = -23f;

    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
        }
    }

    private void ProcessTranslation()
    {
        print("controls...");
        float xThrow, yThrow;
        xThrow = Input.GetAxis("Horizontal") * controlSpeed * Time.deltaTime; // get result of AD keys in X
        yThrow = Input.GetAxis("Vertical") * controlSpeed * Time.deltaTime; // get result of WS keys in Z
                                                                       // move this object at frame rate independent speed:
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNewYPos, yMin, yMax);

        transform.position = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void OnPlayerDeath() // called by string reference in OnCollisionHandler.cs
    {
        print("Death");
        isControlEnabled = false;
    }

    void OnShipHit() // called by string reference in OnCollisionHandler.cs
    {
        print("Ship Shot");
    }
}
