using System.Speech.Synthesis;

namespace Attribute.ChatSpeaker.Speech
{
    /// <summary>
    ///     An interface for the speaker class.
    /// </summary>
    public interface ISpeaker
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Speaks the specified sentence.
        /// </summary>
        /// <param name="line">The line to speak.</param>
        /// <param name="synthesizer">The synthesizer to use when speaking.</param>
        void Speak(string line, SpeechSynthesizer synthesizer);

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     Gets or sets the name of the <see cref="ISpeaker" />.
        /// </summary>
        /// <value>
        ///     The name of the <see cref="ISpeaker" />.
        /// </value>
        string SpeakerName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the voice to use when this <see cref="ISpeaker" /> speaks.
        /// </summary>
        /// <value>
        ///     The <see cref="ISpeaker" /> voice name.
        /// </value>
        string VoiceName { get; set; }

        #endregion
    }
}
