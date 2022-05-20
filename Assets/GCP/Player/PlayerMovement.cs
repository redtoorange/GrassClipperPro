using UnityEngine;

namespace GCP.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float accelerationPower = 5.0f;
        [SerializeField] private float steeringPower = 5.0f;

        [field: SerializeField]
        public float Speed { get; private set; }

        private float steeringAmount;
        private float speed;
        private float direction;

        private Rigidbody2D rigidbody;
        private Animator animator;

        private GameInput gameInput;
        private Vector2 movementInput;
        private bool hasControl = true;

        private void Start()
        {
            gameInput = new GameInput();
            gameInput.Enable();
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void EnableControl(bool pHasControl = false) => hasControl = pHasControl;

        private void Update()
        {
            if (hasControl)
            {
                movementInput = gameInput.Default.Movement.ReadValue<Vector2>();
            }
            else
            {
                movementInput = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            steeringAmount = -movementInput.x;
            speed = movementInput.y * accelerationPower;

            UpdateAnimation();

            direction = Mathf.Sign(Vector2.Dot(rigidbody.velocity, rigidbody.GetRelativeVector(Vector2.up)));

            rigidbody.rotation += steeringAmount * steeringPower * rigidbody.velocity.magnitude * direction;
            rigidbody.AddRelativeForce(Vector2.up * speed);
            rigidbody.AddRelativeForce(-Vector2.right * rigidbody.velocity.magnitude * steeringAmount / 2.0f);
        }

        private void UpdateAnimation()
        {
            // TODO Move this code to an animation controller script
            animator.SetFloat("Speed", movementInput.y);

            if (Mathf.Abs(speed) > 0)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }

        public float GetSpeed() => speed;
    }
}