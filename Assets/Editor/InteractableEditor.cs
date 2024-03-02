// зачем это - типо десятки взаимодействий можно сделать быстро
using Unity.VisualScripting;
using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    // вызывается каждый раз, когда unity щбновляет интерфейс редактора
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if(target.GetType() == typeof(EventOnlyInteractable)) {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteractable может использовать ТОЛЬКО UnityEvents.", MessageType.Info); // какое то предупреждение
            if(interactable.GetComponent<InteractionEvent>() == null) {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else {
            base.OnInspectorGUI();
            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                    interactable.gameObject.AddComponent<InteractionEvent>();

            }
            else
            {
                // мы не используем события. удалить компонент.
                if (interactable.GetComponent<InteractionEvent>() != null)
                    Destroy(interactable.GetComponent<InteractionEvent>());
            }
        }
    }  
}
