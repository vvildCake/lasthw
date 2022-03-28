using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Exit : MonoBehaviour
{
    [SerializeField] private Material _closedMaterial;
    [SerializeField] private Material _openMaterial;

    public bool IsOpen { get; private set; }

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Open()
    {
        IsOpen = true;
        _renderer.sharedMaterial = _openMaterial;
    }

    public void Close()
    {
        IsOpen = false;
        _renderer.sharedMaterial = _closedMaterial;
    }
}
