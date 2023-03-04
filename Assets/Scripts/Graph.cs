
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform _pointPrefab;
    [SerializeField, Range(10, 100)] private int _resolution = 50;
    [SerializeField] FunctionLibrary.FunctionName _function = 0;
    Transform[] points;
    void Awake()
    {
        float step = 2f /_resolution;

        var scale = Vector3.one * step;
       
        points = new Transform[_resolution * _resolution];
        for (int i = 0; i < points.Length; i++)
        {
            
            Transform point = points[i] = Instantiate(_pointPrefab);
            
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(_function);

        float time = Time.time;

        float step = 2f / _resolution;

        float v = 0.5f * step - 1f;

        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == _resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;

            points[i].localPosition = f(u, v, time);
        }
    }
}
