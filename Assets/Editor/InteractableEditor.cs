using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promtMessage = EditorGUILayout.TextField("Promt Message", interactable.promtMessage);
            EditorGUILayout.HelpBox("Promt Message", MessageType.Info);
            if(interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        } 
        else
        {
            base.OnInspectorGUI();
            if(interactable.useEvents)
            {
                if(interactable.GetComponent<InteractionEvent>() == null)
                {
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            } else
            {
                if(interactable.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}