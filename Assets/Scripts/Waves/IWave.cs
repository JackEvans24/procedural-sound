namespace ProceduralAudio.Waves
{
    public interface IWave
    {
        public float AmplitudeModifier { get; }

        public float GetSample(float time, float sampleRate, float frequency);
    }
}