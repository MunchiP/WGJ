using UnityEngine;

public class LightDetection : MonoBehaviour
{
 public float range = 5f;
    public float angle = 45f; // Ángulo total del cono
    public LayerMask playerMask;
    public LayerMask occluderMask;
    public bool isActive = true; // Si la luz está encendida

    private void Update()
    {
        if (!isActive) return;

        Collider2D player = Physics2D.OverlapCircle(transform.position, range, playerMask);

        if (player != null && IsTargetExposed(player))
        {
            Debug.Log("Jugador detectado - Pierdes");
            // Aquí puedes cargar otra escena, restar vidas, etc.
        }

        
    }

    private bool IsTargetExposed(Collider2D target)
    {
        Vector2 dirToTarget = (target.bounds.center - transform.position).normalized;
        float distToTarget = Vector2.Distance(transform.position, target.bounds.center);

        float halfAngle = angle / 2f;
        float angleToTarget = Vector2.Angle(transform.right, dirToTarget);

        if (angleToTarget > halfAngle) return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToTarget, distToTarget, occluderMask | playerMask);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            return true; // Jugador visible
        }

        return false; // Algo bloquea la luz
    }

    // Esto dibuja el rango y ángulo en el editor
    private void OnDrawGizmos()
    {
        Gizmos.color = isActive ? Color.yellow : Color.gray;
        Gizmos.DrawWireSphere(transform.position, range);

        Vector3 leftBoundary = Quaternion.Euler(0, 0, angle / 2) * transform.right * range;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -angle / 2) * transform.right * range;

        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
