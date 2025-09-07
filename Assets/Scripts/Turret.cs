using UnityEngine;
using UnityEngine.AI;
public class Turret : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeed = 5f;

    private Quaternion targetRotation;
    private bool hasTarget = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Debug.Log("Попал");
                SetTargetRotation(hit.point);
            }
            else
            {
                Debug.Log("Не попал");
            }
        }

        if (hasTarget)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    void SetTargetRotation(Vector3 targetPosition)
    {
        Vector3 lookAtPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);
        hasTarget = true;
    }
}
