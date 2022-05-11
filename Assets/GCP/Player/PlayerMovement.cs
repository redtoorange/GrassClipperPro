using UnityEngine;

namespace GCP.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float accelerationPower = 5.0f;
        [SerializeField] private float steeringPower = 5.0f;

        private float steeringAmount;
        private float speed;
        private float direction;

        private Rigidbody2D rigidbody;
        private Animator animator;

        private bool hasControl = true;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void EnableControl(bool hasControl = false)
        {
            this.hasControl = hasControl;
        }

        private void FixedUpdate()
        {
            if (hasControl)
            {
                steeringAmount = -Input.GetAxis("Horizontal");
                speed = Input.GetAxis("Vertical") * accelerationPower;
            }
            else
            {
                steeringAmount = 0;
                speed = 0;
            }

            animator.SetFloat("Speed", Input.GetAxis("Vertical"));

            if (Mathf.Abs(speed) > 0)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }

            direction = Mathf.Sign(Vector2.Dot(rigidbody.velocity, rigidbody.GetRelativeVector(Vector2.up)));

            rigidbody.rotation += steeringAmount * steeringPower * rigidbody.velocity.magnitude * direction;
            rigidbody.AddRelativeForce(Vector2.up * speed);
            rigidbody.AddRelativeForce(-Vector2.right * rigidbody.velocity.magnitude * steeringAmount / 2.0f);
        }

        public float GetSpeed()
        {
            return speed;
        }
    }
}