using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class SquareWave : IWave
    {
        public float AmplitudeModifier => 0.25f;

        public float GetSample(float time, float sampleRate, float frequency)
            => Mathf.Sign(Mathf.Sin(2 * Mathf.PI * (time / sampleRate * frequency)));
    }
}