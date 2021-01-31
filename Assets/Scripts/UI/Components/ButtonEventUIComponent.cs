using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventUIComponent : MonoBehaviour, IUIComponent
{
    [SerializeField] private Button button;
    [SerializeField] private string eventName;

    private GameObject reference;

    public void Enter(Flow flow)
    {
        reference = flow.stack.gameObject;

        button.onClick.AddListener(OnButtonClicked);
    }

    public void Exit(Flow flow)
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        CustomEvent.Trigger(reference, eventName);
    }
}