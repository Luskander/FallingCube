using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float ScrollSpeed; // скорость прокрутки
    public float TileSize; // высота фона
    private Transform currentObject;

    void Start()
    {
        currentObject = GetComponent<Transform>();
    }

    void Update()
    {
        currentObject.position = new Vector3(
            currentObject.position.x,
            Mathf.Repeat(Time.time * ScrollSpeed, TileSize), // зацикливаем координату по Y между значениями 0 и 10
            currentObject.position.z
            );
    }
}
