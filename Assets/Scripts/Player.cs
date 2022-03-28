using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    public bool IsAlive { get; private set; } = true;
    public bool HasKey { get; private set; } = false;
    
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        Enable();
    }

    public void Enable()
    {
        _movement.enabled = true;
    }

    public void Disable()
    {
        _movement.enabled = false;
    }

    public void Kill()
    {
        IsAlive = false;
    }

    public void PickUpKey()
    {
        HasKey = true;
    }
}
