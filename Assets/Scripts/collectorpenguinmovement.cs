using UnityEngine;
using UnityEngine.SceneManagement;
public class CollectorPenguinMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool startLeft = true;
    [SerializeField] private MovementStateController movementState;
    

    private void Awake()
    {
        if (movementState == null)
            movementState = GetComponent<MovementStateController>();
    }

    private void Start()
    {
        movementState.Active = true;
        movementState.CanMove = true;
        movementState.Movement.Left = startLeft;
        movementState.Movement.Right = !startLeft;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            SceneManager.LoadScene("1");
            Debug.Log("Apretaste L");
            
        }
        
        if (!movementState.Active || !movementState.CanMove) return;

        if (movementState.Movement.Left)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        else if (movementState.Movement.Right)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}