using UnityEngine;

[CreateAssetMenu(fileName = "TextEvent", menuName = "EventVariables/TextEvent")]
public class TextEvent : ScriptableObject
{
    private string text;

    public delegate void ValueChangeDelegate(bool isDebug);
    ValueChangeDelegate valueChangeDelegate;

    [SerializeField] private bool debugChange;

    public string textValue
    {
        set
        {
            textValue = value;

            ValueChanged();
        }
        get
        {
            return textValue;
        }
    }

    private void ValueChanged()
    {
        if (valueChangeDelegate != null)
        {
            valueChangeDelegate(debugChange);
        }
    }

    //delegate part
    public void RegisterDelegate(ValueChangeDelegate givenDelegate)
    {
        valueChangeDelegate += givenDelegate;
    }

    public void UnregisterDelegate(ValueChangeDelegate givenDelegate)
    {
        valueChangeDelegate -= givenDelegate;
    }
}
