using UnityEngine;

[CreateAssetMenu(fileName = "TextEvent", menuName = "EventVariables/TextEvent")]
public class TextEvent : ScriptableObject
{
    private string textValue;

    public delegate void ValueChangeDelegate(bool isDebug);
    ValueChangeDelegate valueChangeDelegate;

    [SerializeField] private bool debugChange;

    public string TextValue
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
        if (debugChange)
        {
            Debug.Log("TextEvent SO ValueChanged() - object name = " + name + ", textValue = " + textValue);
		}


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
