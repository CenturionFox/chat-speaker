using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using Attribute.ChatSpeaker.Annotations;

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
            this.Errored += this.this_Errored;
            this.PropertyChanged += this.this_PropertyChanged;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Speaker"/> class.
        /// </summary>
        /// <param name="synthesizer">The <see cref="SpeechSynthesizer"/> for the Speaker to use.</param>
        public Speaker(SpeechSynthesizer synthesizer) : this()
        {
            this.Synthesizer = synthesizer;
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
        public void Speak(string line, SpeechSynthesizer synthesizer = null)
        {
            if (!this.IsErrored)
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
                    this.Errored?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
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
            if (!this.IsErrored)
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
                    this.Errored?.Invoke(this, new UnhandledExceptionEventArgs(exception, false));
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
                    if (this._synthesizer != null)
                    {
                        this._synthesizer.SpeakStarted -= this.Synthesizer_SpeakStarted;
                        this._synthesizer.SpeakCompleted -= this.Synthesizer_SpeakCompleted;
                        this._synthesizer.VoiceChange -= this.Synthesizer_VoiceChange;
                    }

                    this._synthesizer = value;

                    if (value != null)
                    {
                        this._synthesizer.SpeakStarted += this.Synthesizer_SpeakStarted;
                        this._synthesizer.SpeakCompleted += this.Synthesizer_SpeakCompleted;
                        this._synthesizer.VoiceChange += this.Synthesizer_VoiceChange;
                    }

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
                        try
                        {
                            this.Synthesizer.SelectVoice(value);
                        }
                        catch (Exception ex)
                        {
                            this.Errored?.Invoke(this, new UnhandledExceptionEventArgs(ex, false));
                        }
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
            return $"{this.SpeakerName}";
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

        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            this.SynthesizerSpeakCompleted?.Invoke(this, e);
        }

        private void Synthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            this.SynthesizerSpeakStarted?.Invoke(this, e);
        }

        private void Synthesizer_VoiceChange(object sender, VoiceChangeEventArgs e)
        {
            this.SynthesizerVoiceChanged?.Invoke(this, e);
        }

        private void this_Errored(object sender, UnhandledExceptionEventArgs e)
        {
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (sender == this)
            {
                this.IsErrored = true;
            }
        }

        private void this_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (sender == this)
            {
                this.IsErrored = false;
            }
        }

        public event UnhandledExceptionEventHandler Errored;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<VoiceChangeEventArgs> SynthesizerVoiceChanged;

        public event EventHandler<SpeakStartedEventArgs> SynthesizerSpeakStarted;

        public event EventHandler<SpeakCompletedEventArgs> SynthesizerSpeakCompleted;

        #endregion


        #region [-- PROPERTIES --]

        public bool IsErrored
        {
            get { return this._isErrored; }
            set { this._isErrored = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private bool _isErrored;
        private string _speakerName;
        private SpeechSynthesizer _synthesizer;
        private string _voiceName;

        #endregion
    }
}
