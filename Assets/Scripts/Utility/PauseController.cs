using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    public UIManager uiManager = null;
    public InputAction inputAction;
    // Start is called before the first frame update
    void Start()
    {
        uiManager.TogglePause2();
        inputAction.performed += unpause =>
        {
            StartCoroutine(unpauseRoutine());
        };
        inputAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator unpauseRoutine()
    {
        uiManager.TogglePause2();
        yield return new WaitForSeconds(0.1f);
        uiManager.TogglePause2();
    }
}
