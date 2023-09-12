using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class SawtoothWave : IWave
    {
        public float AmplitudeModifier => 0.35f;

        public float GetSample(float time, float sampleRate, float frequency)
            => Mathf.Lerp(-1f, 1f, Mathf.InverseLerp(0f, sampleRate, time * frequency % sampleRate));
    }
}