using ProceduralAudio.Waves;
using UnityEngine;

namespace ProceduralAudio
{
    [RequireComponent(typeof(LineRenderer))]
    public class WaveVisualiser : MonoBehaviour
    {
        private IWave _wave;

        [Header("References")]
        [SerializeField] private LineRenderer baseLineRenderer;
        
        [SerializeField] private Vector2 size = new(10, 5);
        [SerializeField] private Vector2 position = new(-5, 0);
        [SerializeField][Min(1)] private int repetitions = 2;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            UpdateLineRenderers();
        }

        public void SetWave(IWave wave)
        {
            _wave = wave;
            UpdateLineRenderers();
        }

        private void UpdateLineRenderers()
        {
            if (!Application.isPlaying || _lineRenderer == null)
                return;
            
            SetBaselinePoints();
            SetWavePoints();
        }

        private void SetBaselinePoints()
        {
            var points = new Vector3[2];

            points[0] = new Vector3(position.x, 0f);
            points[1] = new Vector3(position.x + size.x, 0f);

            baseLineRenderer.positionCount = 2;
            baseLineRenderer.SetPositions(points);
        }

        private void SetWavePoints()
        {
            var wavePoints = _wave.GetVisualiserPoints();
            var visualiserPoints = new Vector3[wavePoints.Length * repetitions + 1];

            for (var iRepetition = 0; iRepetition < repetitions; iRepetition++)
            {
                var xOffset = Mathf.Lerp(position.x, position.x + size.x, iRepetition / (float)repetitions);
                for (var iPosition = 0; iPosition < wavePoints.Length; iPosition++)
                {
                    var currentPoint = wavePoints[iPosition];
                    var currentPointPosition = GetPointPosition(currentPoint, xOffset);

                    var index = wavePoints.Length * iRepetition + iPosition;
                    visualiserPoints[index] = currentPointPosition;
                }
            }
            
            visualiserPoints[^1] = new Vector3(position.x + size.x, position.y + _wave.WaveEndHeight * size.y / 2);

            _lineRenderer.positionCount = visualiserPoints.Length;
            _lineRenderer.SetPositions(visualiserPoints);
        }

        private Vector2 GetPointPosition(Vector2 currentPoint, float xOffset)
        {
            var x = xOffset + currentPoint.x * size.x * (1 / (float)repetitions);
            var y = position.y + currentPoint.y * size.y / 2;

            return new Vector2(x, y);
        }

        private void OnValidate()
        {
            UpdateLineRenderers();
        }
    }
}