using UnityEngine;

namespace NinjaFrog
{
    public class NinjaFrogMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private bool isGrounded = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
        
        public void Jump()
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        public bool IsGrounded()
        {
            return isGrounded;
        }
    }
}