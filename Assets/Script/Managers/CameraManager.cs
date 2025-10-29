using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public float smooth;
    public float rightThreshold; // distância à direita do centro antes da câmera mover

    private float _startX;

    private void Start()
    {
        _startX = transform.position.x;
    }

    private void LateUpdate()
    {
        float targetX = this.transform.position.x;

        // Se o jogador ultrapassar o limite à direita (posicaoX do jogador > posicaoX da camera + threshold)
        if (player.position.x > targetX + rightThreshold)
        {
            targetX = player.position.x - rightThreshold;
        }

        // Evita mover para trás igual no Mário
        if (targetX < _startX)
        {
            targetX = _startX;
        }

        // Suaviza movimento
        var pos = transform.position;
        pos.x = Mathf.Lerp(
            transform.position.x,
            targetX,
            Time.deltaTime * smooth
        );
        transform.position = pos;
    }
}