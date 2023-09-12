using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class TriangleWave : IWave
    {
        public float AmplitudeModifier => 1f;

        public float GetSample(float time, float sampleRate, float frequency)
        {
            var wavePos = Mathf.InverseLerp(0f, sampleRate, time * frequency % sampleRate);
            wavePos = Mathf.Abs(0.5f - wavePos) * 2;
            return Mathf.Lerp(-1f, 1f, wavePos);
        }
    }
}