using UnityEngine;
public class BearEnemy : MonoBehaviour
{
    private PositionController _controller;

    [Header("A quien perseguir")]
    public Transform igluTarget; 

    [Header("Movimiento")]
    public float speed = 3f;
    public float acceleration = 5f;

    private void Awake()
    {
        _controller = GetComponent<PositionController>();
    }

    void Update()
    {
        if (igluTarget == null) return;
        Vector2 dir = igluTarget.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        _controller.MoveForward(speed, acceleration);
    }
}