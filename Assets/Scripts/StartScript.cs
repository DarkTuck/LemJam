using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartScript : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Animator playerAnimator;
    [SerializeField] string animationName;
    [SerializeField] private int[] delays;
    private GameObject camera;
    void OnEnable()
    {
        InputSystem.onActionChange += StartingSequence;
        camera = Camera.main.gameObject;
        camera.SetActive(false);
        playerMovement.enabled = false;
    }

    void OnDisable()
    {
        InputSystem.onActionChange -= StartingSequence;
    }
    
    void StartingSequence(object o, InputActionChange inputActionChange)
    {
        camera.SetActive(true);
        StartCoroutine("StartCoroutine");
    }

    IEnumerator StartCoroutine()
    {
        playerAnimator.Play(animationName);
        yield return new WaitForSeconds(delays[0]);
        //spawnEnemies
        yield return new WaitForSeconds(delays[1]);
        playerMovement.enabled = true;
        gameObject.SetActive(false);
    }
}

