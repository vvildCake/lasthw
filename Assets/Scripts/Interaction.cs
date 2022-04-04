using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public Player player;
    public void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    abstract public void OnInteraction(Player player);
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == player.gameObject.layer)
            OnInteraction(player);
    }
}
