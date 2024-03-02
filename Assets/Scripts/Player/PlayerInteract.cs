// ������ ��� ����������� ������������� �������� � ��������� ������� ������ ������ 
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
        mask = LayerMask.GetMask("Default", "Interactable"); // ��� ���

        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); // ���
        Debug.DrawRay(ray.origin, ray.direction * distance); // ������ debug ?
        RaycastHit hitInfo; // ���������� ��� �������� ���� � ������������
        if(Physics.Raycast(ray, out hitInfo, distance, mask)){ // ���� �� ��� �� ���������. � �� ��� �������� � ����� �����
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                // Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage); // ����� ���� ����� debug ?
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered) {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
