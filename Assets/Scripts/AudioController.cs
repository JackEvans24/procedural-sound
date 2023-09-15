using System;
using ProceduralAudio.Waves;

namespace ProceduralAudio
{
    public class AudioController
    {
        private static AudioController _instance;
        public static AudioController Instance => _instance ??= new AudioController();

        public int Pitch => _pitch;

        public Action<IWave> WaveChanged;
        public Action<int> PitchChanged;
        public Action<float> AmplitudeChanged;

        private IWave _wave;
        private float _amplitude;
        private int _pitch;
        
        private AudioController() { }

        public void SetWave(IWave wave)
        {
            if (_wave == wave)
                return;

            _wave = wave;
            WaveChanged?.Invoke(_wave);
        }

        public void SetAmplitude(float amplitude)
        {
            if (Math.Abs(_amplitude - amplitude) < float.Epsilon)
                return;

            _amplitude = amplitude;
            AmplitudeChanged?.Invoke(_amplitude);
        }

        public void SetPitch(int note)
        {
            if (_pitch == note)
                return;

            _pitch = Math.Clamp(note, 1, 88);
            PitchChanged?.Invoke(_pitch);
        }
    }
}