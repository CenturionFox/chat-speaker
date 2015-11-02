using System;
using System.Diagnostics;
using System.Globalization;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using Attribute.ChatSpeaker.Speech;

namespace Attribute.ChatSpeaker
{
    internal static class Program
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var synth = new SpeechSynthesizer();
            //var voices = synth.GetInstalledVoices();

            //var sp = new Speaker[voices.Count];
            //for (var i = 0; i < sp.Length; i++)
            //{
            //    sp[i] = new Speaker(new SpeechSynthesizer())
            //    {
            //        SpeakerName = $"Speech Synthesizer Test {i + 1}",
            //    };

            //    sp[i].Errored += onErrored;
            //    sp[i].SynthesizerVoiceChange += onSynthesizerVoiceChange;
            //    sp[i].VoiceName = voices[i].VoiceInfo.Name;
            //}

            //foreach (var s in sp)
            //{
            //    try
            //    {
            //        s.Speak($"Hello from {s.SpeakerName}: {s.VoiceName}");
            //    }
            //    catch (InvalidOperationException ioex)
            //    {
            //        Debug.WriteLine(ioex.Message);
            //    }
            //}
            Application.Run(new MainForm());
        }

        //static void onErrored(object sender, UnhandledExceptionEventArgs e)
        //{
        //    MessageBox.Show($"Speaker {sender} with voice type {(sender as Speaker)?.VoiceName} threw an exception:\r\n {e.ExceptionObject}");

        //    if (e.IsTerminating)
        //    {
        //        var ex = new Exception("Speaker failure.", e.ExceptionObject as Exception);
        //        throw ex;
        //    }
        //}

        //static void onSynthesizerVoiceChange(object sender, VoiceChangeEventArgs e)
        //{
        //    MessageBox.Show($"{sender}'s synthesizer voice was changed to {e.Voice.Name}");
        //}

        #endregion
    }
}
