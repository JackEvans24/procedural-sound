using ProceduralAudio.Waves;
using UnityEngine;

namespace ProceduralAudio
{
    public class WaveVisualiser : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private LineRenderer waveLineRenderer;
        [SerializeField] private LineRenderer baseLineRenderer;
        
        [Header("Visualisation")]
        [SerializeField] private Vector2 size = new(10, 5);
        [SerializeField] private Vector2 position = new(-5, 0);
        [SerializeField][Min(1)] private int repetitions = 2;

        private AudioController _audioController = AudioController.Instance;

        private Vector3[] _defaultPositions; 
        
        private IWave _wave;
        
        private void Awake()
        {
            _defaultPositions = new Vector3[] { new Vector2(position.x, 0f), new Vector2(position.x + size.x, 0f) };

            _audioController.WaveChanged += OnWaveChanged;
        }

        private void Start()
        {
            UpdateLineRenderers();
        }

        private void OnDestroy()
        {
            _audioController.WaveChanged -= OnWaveChanged;
        }

        private void OnWaveChanged(IWave wave)
        {
            _wave = wave;
            UpdateLineRenderers();
        }

        private void UpdateLineRenderers()
        {
            if (!Application.isPlaying || waveLineRenderer == null)
                return;
            
            SetBaselinePoints();
            SetWavePoints();
        }

        private void SetBaselinePoints()
        {
            SetDefaultLinePositions(baseLineRenderer);
        }

        private void SetWavePoints()
        {
            if (_wave == null)
            {
                SetDefaultLinePositions(waveLineRenderer);
                return;
            }

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

            waveLineRenderer.positionCount = visualiserPoints.Length;
            waveLineRenderer.SetPositions(visualiserPoints);
        }

        private void SetDefaultLinePositions(LineRenderer lineRenderer)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(_defaultPositions);
        }

        private Vector2 GetPointPosition(Vector2 currentPoint, float xOffset)
        {
            var x = xOffset + currentPoint.x * size.x * (1 / (float)repetitions);
            var y = position.y + currentPoint.y * size.y / 2;

            return new Vector2(x, y);
        }

        private void OnValidate()
        {
            if (_defaultPositions == null)
                return;
            UpdateLineRenderers();
        }
    }
}