using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    // в этой функции мы будем проектировать наше взаимодействие с помощью кода. Анимация, уничтожение и тд
    protected override void Interact(){
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen",doorOpen);
    }
}
