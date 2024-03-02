using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;
        // Рассчитываем поворот камеры 
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        // значение поворота x от 80 до 80 градусов
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // значение которое зажимаем / мин. значение / макс. значение
        // Применяем это к камере
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // Вразаем Игрока
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
