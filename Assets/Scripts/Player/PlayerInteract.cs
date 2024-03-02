// логика для обнаружения интерактивных обьектов и обработки входных данных игрока 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    private float distance = 3f;
    private LayerMask mask;

    private PlayerUI playerUI;
    private InputManager inputManager;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        mask = LayerMask.GetMask("Default", "Interactable"); // что это

        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); // луч
        Debug.DrawRay(ray.origin, ray.direction * distance); // Почему debug ?
        RaycastHit hitInfo; // переменная для хранения инфы о столковениях
        if(Physics.Raycast(ray, out hitInfo, distance, mask)){ // Если на что то наткнется. я хз как работает и зачем маска
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                // Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage); // Опять таки зачем debug ?
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered) {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
