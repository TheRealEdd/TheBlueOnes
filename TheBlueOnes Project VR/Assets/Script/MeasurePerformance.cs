using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MeasurePerformance : MonoBehaviour
{
    [SerializeField]
    RandomLineRenderer track = null;
    Vector3[] points = new Vector3[0];
    int PointIndex = 0;

    [SerializeField]
    Text current;
    [SerializeField]
    Text average;

    float SampleRate = 0.1f;
    float Samples = 0;
    float TotalDistanceDistance;

    /// <summary>
    /// Initialize
    /// Start coroutine
    /// </summary>
    void Start()
    {
        points = new Vector3[track.lineRenderer.positionCount];
        track.lineRenderer.GetPositions(points);

        StartCoroutine(MeasureDistance());
    }

    /// <summary>
    /// Measure the distance to the ideal line
    /// </summary>
    /// <returns></returns>
    IEnumerator MeasureDistance()
    {
        while (true)
        {
            Samples++;

            float distance = MinDistance(points[PointIndex], points[PointIndex + 1], transform.position);

            TotalDistanceDistance += distance;

            current.text = distance.ToString("F2");
            average.text = (TotalDistanceDistance / Samples).ToString("F2");

            yield return new WaitForSeconds(SampleRate);
        }
    }
// Update is called once per frame
    void Update()
    {
        /*
         * Past a point when:
         * dot product of velocity with vector from first to second point is negative
         * 
         */
        Vector3 trackSegment = points[PointIndex + 1] - points[PointIndex];
        Vector3 trackStartToPlayer = transform.position - points[PointIndex + 1];

        float dot = Vector3.Dot(trackSegment, trackStartToPlayer);

        Debug.DrawLine(points[PointIndex], points[PointIndex + 1], Color.red);

        if (dot > 0 && PointIndex < points.Length - 2)
        {
            PointIndex++;
        }
    }

    /// <summary>
    /// https://stackoverflow.com/questions/849211/shortest-distance-between-a-point-and-a-line-segment
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    float MinDistance(Vector3 v, Vector3 w, Vector3 p)
    {
        // Return minimum distance between line segment vw and point p
        float l2 = Vector3.SqrMagnitude(w - v);  // i.e. |w-v|^2 -  avoid a sqrt
        if (l2 == 0.0) return Vector3.Distance(p, v);   // v == w case
                                                        // Consider the line extending the segment, parameterized as v + t (w - v).
                                                        // We find projection of point p onto the line. 
                                                        // It falls where t = [(p-v) . (w-v)] / |w-v|^2
                                                        // We clamp t from [0,1] to handle points outside the segment vw.
        float t = Mathf.Max(0, Mathf.Min(1, Vector3.Dot(p - v, w - v) / l2));
        Vector3 projection = v + t * (w - v);  // Projection falls on the segment
        return Vector3.Distance(p, projection);
    }
}