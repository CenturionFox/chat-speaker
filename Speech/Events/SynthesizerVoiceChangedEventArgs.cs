namespace Attribute.ChatSpeaker.Speech.Events
{
    /// <summary>
    ///     Event Arguments for synthesizer voice change events.
    /// </summary>
    public class SynthesizerVoiceChangedEventArgs
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        /// Initializes a new instance of the <see cref="SynthesizerVoiceChangedEventArgs"/> event arguments.
        /// </summary>
        /// <param name="voice">The voice that the synthesizer selected.</param>
        public SynthesizerVoiceChangedEventArgs(string voice)
        {
            this._voice = voice;
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        /// Gets the voice that the synthesizer selected.
        /// </summary>
        /// <value>
        /// The voice that the synthesizer selected.
        /// </value>
        public string Voice => this._voice;

        #endregion


        #region [-- FIELDS --]

        private readonly string _voice;

        #endregion
    }
}
