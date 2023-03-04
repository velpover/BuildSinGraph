
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform _pointPrefab;
    [SerializeField, Range(10, 100)] private int _resolution;

    Transform[] points;
    private void Awake()
    {
        Vector3 position = Vector3.zero ;

        float step = 2f / _resolution;

        var scale = Vector3.one * step;

        points = new Transform[_resolution];

        for (int i = 0; i <points.Length; i++) 
        {

            points[i] = Instantiate(_pointPrefab);

            points[i].SetParent(transform);

            position.x = (i + 0.5f) * step - 1f;

            points[i].localPosition = position;
            points[i].localScale = scale;
        }
    }

    private void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];

            Vector3 position = point.localPosition;

            position.y = Mathf.Sin((position.x+Time.time)*Mathf.PI);

            point.localPosition = position; 
        }
    }
}
