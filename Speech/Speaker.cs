using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using Attribute.ChatSpeaker.Annotations;
using Attribute.ChatSpeaker.Speech.Events;

namespace Attribute.ChatSpeaker.Speech
{
    /// <summary>
    ///     An implementation of <see cref="ISpeaker" />.
    /// </summary>
    [DebuggerDisplay("{SpeakerName}: {VoiceName}")]
    public sealed class Speaker : ISpeaker, INotifyPropertyChanged
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Initializes a new instance of the <see cref="Speaker" /> class.
        /// </summary>
        public Speaker()
        {
            this.OnErrored += (pSender, pEventArgs) => this.Errored = true;
            this.PropertyChanged += (pSender, pEventArgs) => this.Errored = false;
        }

        public Speaker(SpeechSynthesizer synthesizer)
        {
        }

        #endregion


        #region [-- IMPLEMENTED INTERFACES --]

        /// <summary>
        ///     Speaks the specified sentence.
        /// </summary>
        /// <param name="line">The line to speak.</param>
        /// <param name="synthesizer">
        ///     The synthesizer to use when speaking.  If no value is given, or if null, the speaker's own
        ///     synthesizer is used.
        /// </param>
        /// <exception cref="InvalidOperationException">Thrown if the speaker attempts to speak while in an errored state.</exception>
        public void Speak(string line, SpeechSynthesizer synthesizer)
        {
            if (!this.Errored)
            {
                try
                {
                    if (synthesizer == null)
                    {
                        synthesizer = this.Synthesizer;
                    }
                    else
                    {
                        synthesizer.SelectVoice(this._voiceName);
                    }

                    synthesizer.Speak(line);
                }
                catch (Exception exception)
                {
                    this.OnErrored?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
                }
            }
            else
            {
                throw new InvalidOperationException(
                    $"Unable to speak the specified line: The speaker \"{this}\" is currently in an errored state.");
            }
        }

        public void SpeakAsync(string line, SpeechSynthesizer synthesizer = null)
        {
            if (!this.Errored)
            {
                try
                {
                    if (synthesizer == null)
                    {
                        synthesizer = this.Synthesizer;
                    }
                    else
                    {
                        synthesizer.SelectVoice(this._voiceName);
                    }

                    synthesizer.SpeakAsync(line);
                }
                catch (Exception exception)
                {
                    this.OnErrored?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
                }
            }
            else
            {
                throw new InvalidOperationException(
                    $"Unable to speak the specified line: The speaker \"{this}\" is currently in an errored state.");
            }
        }

        /// <summary>
        ///     Gets or sets the name of the speaker.
        /// </summary>
        /// <value>
        ///     The name of the speaker.
        /// </value>
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

        /// <summary>
        ///     Gets or sets the voice synthesizer.
        /// </summary>
        /// <value>
        ///     The voice synthesizer.
        /// </value>
        public SpeechSynthesizer Synthesizer
        {
            get { return this._synthesizer; }
            set
            {
                if (value != this._synthesizer)
                {
                    this._synthesizer = value;
                    this.onPropertyChanged(nameof(this.Synthesizer));
                }
            }
        }

        /// <summary>
        ///     Gets or sets the name of the voice.
        /// </summary>
        /// <value>
        ///     The name of the voice.
        /// </value>
        public string VoiceName
        {
            get { return this._voiceName; }
            set
            {
                if (!value.Equals(this._voiceName))
                {
                    this._voiceName = value;
                    this.onPropertyChanged(nameof(this.VoiceName));

                    if (this.Synthesizer != null && !string.IsNullOrEmpty(value))
                    {
                        this.Synthesizer.SelectVoice(value);
                        this.OnSynthesizerVoiceChanged?.Invoke(this, new SynthesizerVoiceChangedEventArgs(value));
                    }
                }
            }
        }

        #endregion


        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is an instance of <see cref="Speaker" /> and both that
        ///     object and this instance have equivalent <see cref="SpeakerName" /> values; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var speaker = obj as Speaker;

            return speaker != null && speaker.SpeakerName.Equals(this._speakerName);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 27;
                hashCode = (13 * hashCode) + this.SpeakerName.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{this.SpeakerName}: {this.VoiceName}";
        }

        #endregion


        #region [-- PRIVATE METHODS --]

        [NotifyPropertyChangedInvocator]
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region [-- EVENT HANDLERS --]

        public event UnhandledExceptionEventHandler OnErrored;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<SynthesizerVoiceChangedEventArgs> OnSynthesizerVoiceChanged;

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
        private SpeechSynthesizer _synthesizer;
        private string _voiceName;

        #endregion
    }
}
