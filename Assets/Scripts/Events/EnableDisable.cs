using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EnableDisable : MonoBehaviour
{
	[SerializeField] private UnityEvent onEnable;
	[SerializeField] private UnityEvent onDisable;

	[SerializeField] private float delayTime = -1f;

	private void OnEnable()
	{
		if (delayTime > 0f)
		{
			StartCoroutine(Wait());
		}
		else
		{
			onEnable.Invoke();
		}

		IEnumerator Wait()
		{
			yield return new WaitForSeconds(delayTime);

			onEnable.Invoke();
		}
	}

	private void OnDisable()
	{
		onDisable.Invoke();
	}
}
