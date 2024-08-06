using UnityEngine;

public class Direction : MonoBehaviour
{
    private bool _facingRight = true;
    private bool _facingLeft = false;

    public void FlipCharacter(float move)
    {
        if (move < 0 && _facingRight)
        {
            Flip();
        }
        else if (move > 0 && _facingRight == false)
        {
            Flip();
        }
    }

    private void Flip()
    {
        int direction = -1;

        _facingRight = !_facingRight;

        Vector2 directionOfView = transform.localScale;
        directionOfView.x *= direction;
        transform.localScale = directionOfView;
    }
}