using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour // abstract - ������ �� �������������
{
    // ��������� ��� ������� ��������� InteractionEvent � ����� �������� �������.
    public bool useEvents;
    [SerializeField]
    public string promptMessage; // ����� �� ������� �� �����. ������

    public virtual string onLook()
    {
        return promptMessage;
    }

    public void BaseInteract() { // ����� ������� �������
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact() { 
        // ��������� �������, ������� ����� ���������������� ������ �����������
    }
}
