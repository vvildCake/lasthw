using UnityEngine;

public class KeyInteraction : Interaction
{
    public override void OnInteraction(Player player)
    {
        player.PickUpKey();
        Destroy(gameObject);
    }
}
