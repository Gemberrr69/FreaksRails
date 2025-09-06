    using System.Collections.Generic;
    using UnityEngine;

    public class Planes : MonoBehaviour
    {
        [SerializeField]
        List <GameObject> _planes;

        [SerializeField]
        private float platformLength = 50f;

        void Start()
        {
            foreach (var plane in _planes) 
            {
                plane.GetComponentInChildren<Triger>().Triggered += P_move;
            }
        }
        void P_move()
        {
            Debug.Log("WORRRRK");

            GameObject lastPlane = _planes[0];
            _planes.RemoveAt(0);

 
            GameObject frontPlane = _planes[_planes.Count - 1];

            lastPlane.transform.position = frontPlane.transform.position + new Vector3(platformLength, 0f, 0f);

            _planes.Add(lastPlane);
        }
    }
