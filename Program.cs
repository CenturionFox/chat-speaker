using System;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Attribute.ChatSpeaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var synth = new SpeechSynthesizer();

            var val = synth.GetInstalledVoices();

            foreach (var k in val)
            {
                try
                {
                    synth.SelectVoice(k.VoiceInfo.Name);
                    synth.Speak("Hello from " + k.VoiceInfo.Name);
                }
                catch (Exception)
                {
                    MessageBox.Show("Speak failed for voice " + k.VoiceInfo.Name);
                }
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
    }
}
