// Функции перемещения игрока
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity; // скорость
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    bool sprinting = false;

    void Start(){
        controller = GetComponent<CharacterController>();
    }

    void Update(){
        isGrounded = controller.isGrounded;
        if (lerpCrouch){
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);  // хз что это
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1){
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    } 
    // Будет получать данные из скрипта InputManager и применять их к нашему котроллеру символов
    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero; // направлене перемещения
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch(){
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint(){
        sprinting = !sprinting;
        if(sprinting)
            speed = 8;
        else
            speed = 5;
    }
}
