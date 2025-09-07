using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Debug.Log("Попал");
                LookAtTargetYOnly(hit.point);
            }
            else 
            {
                Debug.Log("Не попал");
            }
        }
    }
    void LookAtTargetYOnly(Vector3 targetPosition)
    {
        Vector3 lookAtPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        transform.LookAt(lookAtPosition);
    }
}
