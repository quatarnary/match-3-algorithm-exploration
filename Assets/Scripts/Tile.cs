using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color[] colors;

    private Vector3 startPos;
    private Tile otherTile;
    private bool isSwapping = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AssignRandomColor();
    }

    void AssignRandomColor()
    {
        if (colors.Length > 0)
        {
            spriteRenderer.color = colors[Random.Range(0, colors.Length)];
        }
    }

    void OnMouseDown()
    {
        startPos = transform.position; // initial pos
    }

    void OnMouseUp()
    {
        // multiple swap prevention.. Royal Kingdom allows multiple swap...
        if (isSwapping) return; 

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null && hit.collider.gameObject != gameObject)
        {
            otherTile = hit.collider.GetComponent<Tile>();
            if (otherTile != null)
            {
                StartCoroutine(SwapTiles());
            }
        }
    }

    private System.Collections.IEnumerator SwapTiles()
    {
        isSwapping = true;

        Vector3 targetPos = otherTile.transform.position;
        otherTile.transform.position = startPos;
        transform.position = targetPos;

        // swap animation.. may go with DOTween
        yield return new WaitForSeconds(0.2f); 

        isSwapping = false;
    }
}
