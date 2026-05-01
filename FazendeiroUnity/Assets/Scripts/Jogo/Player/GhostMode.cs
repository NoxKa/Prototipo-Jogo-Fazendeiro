using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GhostMode : MonoBehaviour
{
    public bool isGhost = false;
    private bool isTimeEnd = true;
    public InputActionAsset InputActions;
    private InputAction ghostAction;
    private Renderer render;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = GetComponent<Renderer>();
    }
    void Awake()
    {
        ghostAction = InputSystem.actions.FindAction("Ghost");
    }
        void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (ghostAction.WasPressedThisFrame())
        {
            Ghost(true);
        }
        if (ghostAction.WasReleasedThisFrame())
        {
            Ghost(false);
        }
    }
    private void Ghost(bool ativar)
    {
        if (ativar)
        {
            if (!isGhost & isTimeEnd)
            {
                render.enabled = false;
                isGhost = true;
                StartCoroutine(GhostStopTime());
            }
        }
        else if (!ativar)
        {
            if (isGhost)
            {
                render.enabled = true;
                isGhost = false;
                StartCoroutine(GhostStartTime());
            }
        }
    }
    private IEnumerator GhostStopTime()
    {
        yield return new WaitForSeconds(2);
        if (isGhost)
        {
            Ghost(false);
        }
    }
    private IEnumerator GhostStartTime()
    {
        isTimeEnd = false;
        yield return new WaitForSeconds(2);
        isTimeEnd = true;
    }
}
