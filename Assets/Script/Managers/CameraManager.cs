using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public float smooth;
    public float rightThreshold;
    public float topThreshold;

    private float _startX;
    private float _startY;

    private void Start()
    {
        _startX = this.transform.position.x;
        _startY = this.transform.position.y;
    }

    private void LateUpdate()
    {
        float targetX = this.transform.position.x;
        float targetY = player.position.y - topThreshold;

        if (player.position.x > targetX + rightThreshold)
        {
            targetX = player.position.x - rightThreshold;
        }

        if (targetX < _startX)
        {
            targetX = _startX;
        }

        if (targetY < _startY)
        {
            targetY = _startY;
        }

        var pos = transform.position;

        pos.x = Mathf.Lerp(
            transform.position.x,
            targetX,
            Time.deltaTime * smooth
        );
        pos.y = Mathf.Lerp(
            transform.position.y,
            targetY,
            Time.deltaTime * smooth
        );

        transform.position = pos;
    }
}