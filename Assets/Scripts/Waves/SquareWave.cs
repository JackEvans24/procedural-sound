using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class SquareWave : IWave
    {
        public float AmplitudeModifier => 0.25f;

        public float WaveEndHeight => -1f;

        public float GetSample(float time, float sampleRate, float frequency)
            => Mathf.Sign(Mathf.Sin(2 * Mathf.PI * (time / sampleRate * frequency)));

        public Vector3[] GetVisualiserPoints() => new[]
        {
            new Vector3(0f, -1f),
            new Vector3(0f, 1f),
            new Vector3(0.5f, 1f),
            new Vector3(0.5f, -1f)
        };
    }
}