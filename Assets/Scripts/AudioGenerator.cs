using ProceduralAudio.Waves;
using UnityEngine;

namespace ProceduralAudio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioGenerator : MonoBehaviour
    {
        [Header("Audio Generation")]
        [SerializeField] private int sampleRate = 48000;
        
        private readonly AudioController _audioController = AudioController.Instance;

        private int _time;

        private IWave _wave;
        private float _frequency;
        private float _amplitude;

        private void Awake()
        {
            _audioController.WaveChanged += OnWaveChanged;
            _audioController.FrequencyChanged += OnFrequencyChanged;
            _audioController.AmplitudeChanged += OnAmplitudeChanged;
        }

        private void OnDestroy()
        {
            _audioController.WaveChanged -= OnWaveChanged;
            _audioController.FrequencyChanged -= OnFrequencyChanged;
            _audioController.AmplitudeChanged -= OnAmplitudeChanged;
        }

        private void OnAudioFilterRead(float[] data, int channels)
        {
            if (_wave == null)
                return;

            var activeAmplitude = _amplitude * _wave.AmplitudeModifier;

            for (var i = 0; i < data.Length; i += channels, _time++)
            {
                if (_time >= sampleRate)
                    _time %= sampleRate;
            
                var sample = _wave.GetSample(_time, sampleRate, _frequency) * activeAmplitude;
                for (var j = 0; j < channels; j++)
                    data[i + j] = sample;
            }
        }

        private void OnWaveChanged(IWave wave) => _wave = wave;

        private void OnFrequencyChanged(float frequency) => _frequency = frequency;

        private void OnAmplitudeChanged(float amplitude) => _amplitude = amplitude;
    }
}
