using UnityEngine;

public class CAR : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
