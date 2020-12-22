using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterHandler : MonoBehaviour
{
    public GameObject prefab;

    public float Timer = 1f;
    public float interval = 1f;
    public float xRange = 13.5f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemies(0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int count = Enemies.Length;
            if (count <= 6)
            {
                float xPos = UnityEngine.Random.Range(-xRange, xRange);
                GenerateEnemies(xPos);
            }
            Timer = interval;
        }
    }

    private void GenerateEnemies(float xPos)
    {
        
            prefab.GetComponent<Enemy>().notMoving = false;
            Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);
            Instantiate(prefab, new Vector3(xPos, gameObject.transform.localPosition.y, transform.localPosition.z), rotation);
    }
}
