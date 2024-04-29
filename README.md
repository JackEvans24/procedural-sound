# Procedural Sound Generation

## An exploration into audio generation

This project was created to learn more about how sound is generated electronically.
I started by using Unity's [OnAudioFilterRead](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnAudioFilterRead.html) function, and overwriting the output data with a simple sine wave.
From there I explored how to achieve different pitches, and how to use different wave shapes to produce different tones.

## Usage

After cloning and opening the **MainScene**, start the scene.
The bar on the right displays the currently selected pitch, and contains buttons to change up/down either a semitone, a tone, or a full octave.
Press the **Space Bar** to hear the currently selected note.

Locate the **UserTool** GameObject in the scene hierarchy. Using the inspector, you can change the amplitude here, as well as the wave form.
The currently implemented waves are Sine, Square, Triangle, and Sawtooth.
