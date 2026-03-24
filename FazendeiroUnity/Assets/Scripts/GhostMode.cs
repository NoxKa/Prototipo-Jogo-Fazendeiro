using UnityEngine;
using UnityEngine.InputSystem;

public class GhostMode : MonoBehaviour
{
    private bool isGhost = false;
    public InputActionAsset InputActions;
    private InputAction ghostAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            GetComponent<Renderer>().enabled = false;
        }
    }
}
