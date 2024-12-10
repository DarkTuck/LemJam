using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.UI;

public class IntEventUseExample : MonoBehaviour
{
	[SerializeField] private IntEvent attachedIntEvent;
	[SerializeField] private TextMeshProUGUI attachedIntEventText;
	[SerializeField] bool useSprites=false;
	[SerializeField][ShowIf("useSprites")][Label("od najmiejszej do największej")] Sprite[] sprites;
	[SerializeField][ShowIf("useSprites")] Image spriteRenderer;

	private void OnEnable()
	{
		attachedIntEvent.RegisterDelegate(AttachedIntEventChanged);
	}

	private void OnDisable()
	{
		attachedIntEvent.UnregisterDelegate(AttachedIntEventChanged);
	}

	private void AttachedIntEventChanged(bool isDebug)
	{
		//Debug.Log("IntEvent new value = " + attachedIntEvent.IntValue.ToString());
		attachedIntEventText.text = attachedIntEvent.IntValue.ToString();
		if (useSprites)
		{
			spriteRenderer.sprite = sprites[attachedIntEvent.IntValue];
			Debug.Log(attachedIntEvent.IntValue);
		}
		//do stuff
	}
}
