using System;
using System.Windows.Forms;

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

        #endregion
    }
}
