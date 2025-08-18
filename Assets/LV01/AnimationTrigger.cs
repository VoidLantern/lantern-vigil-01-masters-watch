using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    Player player;
    void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void CallAnimTrigger()
    {
        player.AnimTrig();
    }
}
