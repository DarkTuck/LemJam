using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextEventUse : MonoBehaviour
{	[SerializeField] private TextEvent attachedTextEvent;
    [SerializeField] private TextMeshProUGUI attachedEventText;
    [SerializeField] private int activeTime;

    private void OnEnable()
    {
        attachedTextEvent.RegisterDelegate(AttachedTextEventChanged);
    }

    private void OnDisable()
    {
        attachedTextEvent.UnregisterDelegate(AttachedTextEventChanged);
    }

    private void AttachedTextEventChanged(bool isDebug)
    {
        //Debug.Log("IntEvent new value = " + attachedIntEvent.IntValue.ToString());
        attachedEventText.gameObject.SetActive(true);
        attachedEventText.text = attachedTextEvent.TextValue;
        StartCoroutine(HideText());
        //do stuff
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(activeTime);
        attachedEventText.gameObject.SetActive(false);
    }
    
}
