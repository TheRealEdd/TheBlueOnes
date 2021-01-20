
using UnityEngine;

public class RandomLineRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    float Slope = 0.1f;

    [SerializeField]
    [Range(2, 40)]
    int TrackLength = 10;

    public LineRenderer lineRenderer { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        lineRenderer.positionCount = TrackLength;
        lineRenderer.SetPositions(GeneratePath(TrackLength));
    }



    Vector3[] GeneratePath(int length)
    {
        const float stepSize = 4f;

        Vector3[] result = new Vector3[length];

        result[0] = new Vector3(1, 3, 4);
        result[1] = new Vector3(2, 2, 5);
        result[2] = new Vector3(3, 1, 6);
        result[3] = new Vector3(1, 0, 7);
        result[4] = new Vector3(2, -1, 8);
        result[5] = new Vector3(-2, -2, 9);
        result[6] = new Vector3(1, -3, 10);


        //Vector3 previous = Vector3.zero;
        //result[0] = previous;

        //for (int i = 1; i < length; i++)
        //{
        //    result[i] = new Vector3(previous.x + Random.Range(-2f, 2f), previous.y - (stepSize * Slope), previous.z + stepSize);

        //    previous = result[i];
        //}

        return result;
    }
}