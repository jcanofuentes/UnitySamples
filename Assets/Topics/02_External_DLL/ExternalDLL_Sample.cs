using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NVorbis;
using System.IO;
using System.Diagnostics;

namespace Topics.External_DLLs
{
    public class ExternalDLL_Sample : MonoBehaviour
    {
        // Audio sine blab bla..
        public int position = 0;
        public int samplerate = 44100;
        public float frequency = 440;



        // Start is called before the first frame update
        void Start()
        {
            UnityEngine.Debug.Log(this.GetType());

            /*
                        AudioClip myClip = AudioClip.Create("MySinusoid", samplerate * 2, 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
                        AudioSource aud = GetComponent<AudioSource>();
                        aud.clip = myClip;
                        aud.Play();
            */
            //const string OGG_FILE = @"..\TestFiles\3test.ogg";
            const string OGG_FILE = @"Assets/Topics/02_External_DLL/3test.ogg";

            //SaveToWav(OGG_FILE);
            AudioClip myClip = LoadOGG(OGG_FILE);
            AudioSource aud = GetComponent<AudioSource>();
            aud.clip = myClip;
            aud.Play();
        }

        AudioClip LoadOGG(string filePath)
        {
            AudioClip clip;
            using (var vorbis = new VorbisReader(filePath))
            {
                PrintVorbisData(vorbis);

                // Create an array to store all the samples that cames with the OGG file
                float[] sampleBuf = new float[vorbis.Channels * vorbis.TotalSamples];

                UnityEngine.Debug.Log("sampleBuf.Length " + sampleBuf.Length);

                // Now, record the values inside the buffer
                int cnt;
                while ((cnt = vorbis.ReadSamples(sampleBuf, 0, sampleBuf.Length)) > 0)
                {
                }

                // Finally, create the AudioClip and load the samples
                int lengthSamples = (int)vorbis.TotalSamples;
                int channels = vorbis.Channels;
                int sampleRate = vorbis.SampleRate;
                bool is3D = false;
                clip = AudioClip.Create("Chato", lengthSamples, channels, sampleRate, is3D);
                clip.SetData(sampleBuf, 0);
                vorbis.Dispose();
                // TODO: add security checking!
                return clip;
            }
        }

        public void PrintVorbisData(VorbisReader vorbisRead)
        {
            UnityEngine.Debug.Log(
                "Printing VORBIS file info: \n" + 
                "Channels:" + vorbisRead.Channels + "\n" +
                "ClipSamples:" + vorbisRead.ClipSamples + "\n" +
                "NominalBitrate:" + vorbisRead.NominalBitrate + "\n" +
                "SamplePosition:" + vorbisRead.SamplePosition + "\n" +
                "SampleRate:" + vorbisRead.SampleRate + "\n" +
                "StreamIndex:" + vorbisRead.StreamIndex + "\n" +
                "Streams.Count:" + vorbisRead.Streams.Count + "\n" +
                "StreamStats:" + vorbisRead.StreamStats + "\n" +
                "Tags.All:" + vorbisRead.Tags.All + "\n" +
                "TimePosition:" + vorbisRead.TimePosition + "\n" +
                "TotalSamples:" + vorbisRead.TotalSamples + "\n" +
                "TotalTime:" + vorbisRead.TotalTime + "\n" +
                "UpperBitrate:" + vorbisRead.UpperBitrate + "\n" +
                "Vendor:" + vorbisRead.Tags.EncoderVendor
            );
        }


        void SaveToWav(string filePath)
        {
            var wavFileName = Path.Combine(Application.dataPath, Path.ChangeExtension(Path.GetFileName(filePath), "wav"));
            UnityEngine.Debug.Log("Saving .WAV file to" + wavFileName);

            //using (var fwdStream = new ForwardOnlyStream(fs))
            using (var vorbRead = new VorbisReader(filePath))
            using (var waveWriter = new WaveWriter(wavFileName, vorbRead.SampleRate, vorbRead.Channels))
            {
                var sampleBuf = new float[vorbRead.SampleRate * vorbRead.Channels * 4];
                int cnt;
                while ((cnt = vorbRead.ReadSamples(sampleBuf, 0, sampleBuf.Length)) > 0)
                {
                    waveWriter.WriteSamples(sampleBuf, 0, cnt);
                }
            }
            Process.Start(wavFileName);
        }


        void OnAudioRead(float[] data)
        {
            int count = 0;
            while (count < data.Length)
            {
                data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
                position++;
                count++;
            }
        }

        void OnAudioSetPosition(int newPosition)
        {
            position = newPosition;
        }


        // Update is called once per frame
        void Update()
        {

        }
    }


    /*
    Refs:
    https://www.youtube.com/watch?v=uFwhAdZHwuo   ¡Haz tus propias librerías para Unity!

    */
}