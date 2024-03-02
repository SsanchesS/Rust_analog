using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour // abstract - теперь он общедоступный
{
    // Добавляем или удаляем компонент InteractionEvent к этому игровому объекту.
    public bool useEvents;
    [SerializeField]
    public string promptMessage; // когда он смотрит на интер. обьект

    public virtual string onLook()
    {
        return promptMessage;
    }

    public void BaseInteract() { // Будет вызвана Игроком
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact() { 
        // шаблонная функция, которая будет переопределенная нашими подКлассами
    }
}
