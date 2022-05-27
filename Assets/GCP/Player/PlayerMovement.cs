using UnityEngine;

namespace GCP.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Linear")]
        [SerializeField] private float accelerationPower = 5.0f;
        [SerializeField] private float velocityDeadZone = 0.01f;

        [Header("Turning")]
        [SerializeField] private float movingTurningPower = 5.0f;
        [SerializeField] private float staticTurningPower = 10.0f;


        private float linearVelocity = 0.0f;
        private Rigidbody2D rigidbody;
        private Animator animator;
        private GameInput gameInput;
        private bool hasControl = true;
        private float turningInput;
        private float accelerationInput;

        private void Start()
        {
            gameInput = new GameInput();
            gameInput.Enable();
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();

            rigidbody.centerOfMass = new Vector2(0, 0);
        }

        public void EnableControl(bool pHasControl = false) => hasControl = pHasControl;

        private void Update()
        {
            Vector2 movementInput = Vector2.zero;

            if (hasControl)
            {
                movementInput = gameInput.Default.Movement.ReadValue<Vector2>();
            }

            accelerationInput = movementInput.y;
            turningInput = -movementInput.x;
        }

        private void FixedUpdate()
        {
            ApplyRotationInput();
            ApplyAccelerationInput();
            UpdateAnimation();
        }

        private void ApplyAccelerationInput()
        {
            if (Mathf.Abs(accelerationInput) > 0)
            {
                float accelerationAmount = accelerationInput * accelerationPower;
                rigidbody.AddRelativeForce(new Vector2(0, accelerationAmount * Time.fixedDeltaTime),
                    ForceMode2D.Impulse);
            }

            if (rigidbody.velocity.sqrMagnitude < velocityDeadZone)
            {
                rigidbody.velocity = Vector2.zero;
            }
        }

        private void ApplyRotationInput()
        {
            if (Mathf.Abs(turningInput) > 0)
            {
                float steeringAmount = 0;
                if (rigidbody.velocity.sqrMagnitude > 0)
                {
                    steeringAmount = turningInput * movingTurningPower;
                }
                else
                {
                    steeringAmount = turningInput * staticTurningPower;
                }

                rigidbody.AddTorque(steeringAmount * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }

        private void UpdateAnimation()
        {
            // TODO Move this code to an animation controller script
            animator.SetFloat("Speed", GetSpeed());

            if (Mathf.Abs(GetSpeed()) > 0)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }

        public float GetSpeed() => rigidbody.velocity.magnitude;
    }
}