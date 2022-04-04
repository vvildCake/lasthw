using UnityEngine;
public class EnemyInteraction : Interaction
{
    public override void OnInteraction(Player player)
    {
        player.Kill();
    }
}
