using UnityEngine;

public class MagnitStateTrack : MonoBehaviour
{
    private bool IsDragAllow;

    private void Update()
    {
        if (DoubleClickManager.DoubleClick)
        {
            IsDragAllow = true;
        }
    }

    public void OnMouseDrag()
    {
        if (IsDragAllow)
        {
            Debug.Log("Drag");
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            transform.position = new Vector3(pos_move.x, pos_move.y, transform.position.z);
        }
    }

    public void OnMouseUp()
    {
        if (IsDragAllow)
            IsDragAllow = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("fridge"))
        {
            //FridgeController.DELTA = 1.5f;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
    //On Fridge
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("fridge"))
        {
            //FridgeController.DELTA = 3f;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
