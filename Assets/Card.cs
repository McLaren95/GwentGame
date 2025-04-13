using UnityEngine;
using System;


public class Card : MonoBehaviour
{

    public string name;
    public int strenght;
    public Sprite sprite;
    TypeMillitarty type;


    void Start()
    {
        Console.Write("123");  
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }

    void OnMouseDrag() // Перетаскивание объекта
    {
        // Движение объекта за курсором
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Для 2D
        transform.position = mousePos;
    }
}
