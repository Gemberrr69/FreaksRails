    using System.Collections.Generic;
    using UnityEngine;

public class Planes : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _planes;

    [SerializeField]
    private float platformLength = 50f;
    int lastplane = 0;

    void Start()
    {
        foreach (var plane in _planes)
        {
            plane.GetComponentInChildren<Triger>().Triggered += P_move;
        }
    }
    void P_move()
    {
        _planes[lastplane].transform.Translate(Vector3.right * 150f);
        lastplane ++;
        if (lastplane == 3)
        {
            lastplane = 0;
        }
        
    }
}
