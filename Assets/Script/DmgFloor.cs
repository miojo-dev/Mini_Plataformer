using UnityEngine;

public class DmgFloor : MonoBehaviour
{
    public PlayerControl player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.tag is "Player" or "PlayerDmg")
        {
            player.Kill();
            Debug.Log("Player Dmg");
        }
    }
}