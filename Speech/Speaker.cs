using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using Attribute.ChatSpeaker.Annotations;

namespace Attribute.ChatSpeaker.Speech
{
    public sealed class Speaker : ISpeaker, INotifyPropertyChanged
    {
        #region [-- CONSTRUCTORS --]

        public Speaker()
        {
            this.OnErrored += (pSender, pEventArgs) => this.Errored = true;
        }

        #endregion


        #region [-- IMPLEMENTED INTERFACES --]

        /// <summary>
        ///     Speaks the specified sentence.
        /// </summary>
        /// <param name="line">The line to speak.</param>
        /// <param name="synthesizer">The synthesizer to use when speaking.</param>
        public void Speak(string line, SpeechSynthesizer synthesizer)
        {
            try
            {
                synthesizer.SelectVoice(this._voiceName);
                synthesizer.Speak(line);
            }
            catch (Exception exception)
            {
                this.OnErrored?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
            }
        }

        public string SpeakerName
        {
            get { return this._speakerName; }
            set
            {
                if (!value.Equals(this._speakerName))
                {
                    this._speakerName = value;
                    this.onPropertyChanged(nameof(this.SpeakerName));
                }
            }
        }

        public string VoiceName
        {
            get { return this._voiceName; }
            set
            {
                if (!value.Equals(this._voiceName))
                {
                    this._voiceName = value;
                    this.onPropertyChanged(nameof(this.VoiceName));
                }
            }
        }

        #endregion


        #region [-- PUBLIC & PROTECTED METHODS --]

        [NotifyPropertyChangedInvocator]
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region [-- EVENT HANDLERS --]

        public event UnhandledExceptionEventHandler OnErrored;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region [-- PROPERTIES --]

        public bool Errored
        {
            get { return this._errored; }
            set { this._errored = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private bool _errored;
        private string _speakerName;
        private string _voiceName;

        #endregion
    }
}
