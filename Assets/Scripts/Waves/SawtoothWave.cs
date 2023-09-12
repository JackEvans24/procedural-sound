using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class SawtoothWave : IWave
    {
        public float AmplitudeModifier => 0.35f;

        public float WaveEndHeight => -1f;

        public float GetSample(float time, float sampleRate, float frequency)
            => Mathf.Lerp(-1f, 1f, Mathf.InverseLerp(0f, sampleRate, time * frequency % sampleRate));

        public Vector3[] GetVisualiserPoints() => new[]
        {
            new Vector3(0f, -1f),
            new Vector3(1f, 1f)
        };
    }
}