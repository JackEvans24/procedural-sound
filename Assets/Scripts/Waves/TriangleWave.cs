using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class TriangleWave : IWave
    {
        public float AmplitudeModifier => 1f;

        public float WaveEndHeight => -1f;

        public float GetSample(float time, float sampleRate, float frequency)
        {
            var wavePos = Mathf.InverseLerp(0f, sampleRate, time * frequency % sampleRate);
            wavePos = Mathf.Abs(0.5f - wavePos) * 2;
            return Mathf.Lerp(-1f, 1f, wavePos);
        }

        public Vector3[] GetVisualiserPoints() => new[]
        {
            new Vector3(0f, -1f),
            new Vector3(0.5f, 1f)
        };
    }
}