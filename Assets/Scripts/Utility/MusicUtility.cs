using UnityEngine;

namespace ProceduralAudio.Utility
{
    public static class MusicUtility
    {
        private static readonly float TWELFTH_ROOT_TWO = Mathf.Pow(2f, 1f / 12f);
        private const int MIDDLE_A_FREQUENCY = 440;

        public static float GetFrequencyFromPitch(int pitch)
        {
            var frequency = Mathf.Pow(TWELFTH_ROOT_TWO, pitch - 49) * MIDDLE_A_FREQUENCY;
            return Mathf.Round(frequency * 100f) / 100f;
        }
    }
}