using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class SineWave : IWave
    {
        public float AmplitudeModifier => 1f;

        public float WaveEndHeight => 0f;

        public float GetSample(float time, float sampleRate, float frequency)
            => Mathf.Sin(2 * Mathf.PI * time / sampleRate * frequency);

        public Vector3[] GetVisualiserPoints()
        {
            var sampleCount = 100;

            // Take 99 samples so that we don't have a duplicate end position
            var positions = new Vector3[sampleCount - 1];
            for (int i = 0; i < sampleCount - 1; i++)
            {
                var sample = GetSample(i, sampleCount, 1f);
                positions[i] = new Vector3(i / (float)sampleCount, sample);
            }

            return positions;
        }
    }
}