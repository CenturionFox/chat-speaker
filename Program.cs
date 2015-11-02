using System;
using System.Speech.Synthesis;
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
            var synth = new SpeechSynthesizer();
            var voices = synth.GetInstalledVoices();

            var sp = new Speaker[voices.Count];
            for (var i = 0; i < sp.Length; i++)
            {
                sp[i] = new Speaker()
                {
                    SpeakerName = "TEST",
                    VoiceName = voices[i].VoiceInfo.Name
                };

                sp[i].OnErrored += OnError;
            }

            foreach (var s in sp)
            {
                s.Speak("Hello from " + s.SpeakerName + ": " + s.VoiceName, synth);

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void OnError(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Speaker " + sender + " failed to speak: " + e.ExceptionObject);

            if (e.IsTerminating)
            {
                Exception ex = new Exception("Speaker failure.", e.ExceptionObject as Exception);
            }
        }

        #endregion
    }
}
