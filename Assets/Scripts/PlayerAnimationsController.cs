using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
	[SerializeField] Movement movementController;
	[SerializeField] Animator attachedAnimator;

	private void Update()
	{
		attachedAnimator.SetFloat("movementValue", Mathf.Abs(movementController.InputVector.x));
	}
}
