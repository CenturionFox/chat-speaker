using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Speech.Synthesis;
using System.Xml.Serialization;
using Attribute.ChatSpeaker.Annotations;

namespace Attribute.ChatSpeaker.Speech
{
    /// <summary>
    ///     An implementation of <see cref="ISpeaker" />.
    /// </summary>
    [DataContract,
     DebuggerDisplay("Speaker[Name:{SpeakerName},Voice:{VoiceName},Custom Synthesizer:{HasCustomSynthesizer}]"),
     Serializable,
     XmlRoot(ElementName = "speaker")]
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
        ///     Initializes a new instance of the <see cref="Speaker" /> class.
        /// </summary>
        /// <param name="synthesizer">The <see cref="SpeechSynthesizer" /> for the Speaker to use.</param>
        public Speaker(SpeechSynthesizer synthesizer) : this()
        {
            this.Synthesizer = synthesizer;
        }

        #endregion


        #region [-- IMPLEMENTED INTERFACES --]

        /// <summary>
        ///     Speaks the specified <paramref name="line" />.
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
                var ioex = new InvalidOperationException(
                    $"Unable to speak the specified line: The speaker \"{this}\" is currently in an errored state.");

                ioex.Data.Add("Voice", this.VoiceName);

                throw ioex;
            }
        }

        /// <summary>
        ///     Speaks the specifiec <paramref name="line" /> asynchronously.
        /// </summary>
        /// <param name="line">The line to speak.</param>
        /// <param name="synthesizer">
        ///     The synthesizer to use when speaking.  If no value is given, or if null, the speaker's own
        ///     synthesizer is used.
        /// </param>
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
                var ioex = new InvalidOperationException(
                    $"Unable to speak the specified line: The speaker \"{this}\" is currently in an errored state.");

                ioex.Data.Add("Voice", this.VoiceName);

                throw ioex;
            }
        }

        /// <summary>
        ///     Gets or sets the name of the speaker.
        /// </summary>
        /// <value>
        ///     The name of the speaker.
        /// </value>
        [XmlAttribute(AttributeName = "speakerName", DataType = "xs:token")]
        public string SpeakerName
        {
            get { return this._speakerName; }
            set
            {
                if (!value.Equals(this._speakerName))
                {
                    this._speakerName = value.Trim();
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
        [XmlIgnore]
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
                    this.onPropertyChanged(nameof(this.Synthesizer));

                    if (value != null)
                    {
                        this._synthesizer.SpeakStarted += this.Synthesizer_SpeakStarted;
                        this._synthesizer.SpeakCompleted += this.Synthesizer_SpeakCompleted;
                        this._synthesizer.VoiceChange += this.Synthesizer_VoiceChange;

                        if (!string.IsNullOrEmpty(this.VoiceName))
                        {
                            try
                            {
                                this._synthesizer.SelectVoice(this.VoiceName);
                            }
                            catch (Exception ex)
                            {
                                ex.Data.Add("Voice", this.VoiceName);
                                this.Errored?.Invoke(this, new UnhandledExceptionEventArgs(ex, false));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets or sets the name of the voice.
        /// </summary>
        /// <value>
        ///     The name of the voice.
        /// </value>
        [XmlAttribute(AttributeName = "voiceName", DataType = "xs:normalizedString")]
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
                            ex.Data.Add("Voice", this.VoiceName);
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

        /// <summary>
        ///     Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property being raised.</param>
        [NotifyPropertyChangedInvocator]
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region [-- EVENT HANDLERS --]

        /// <summary>
        ///     Handles the <see cref="SpeechSynthesizer.SpeakCompleted" /> event of the <see cref="Synthesizer" />.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Synthesis.SpeakCompletedEventArgs" /> instance containing the event data.</param>
        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            this.SynthesizerSpeakCompleted?.Invoke(this, e);
        }

        /// <summary>
        ///     Handles the <see cref="SpeechSynthesizer.SpeakStarted" /> event of the <see cref="Synthesizer" />.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Synthesis.SpeakStartedEventArgs" /> instance containing the event data.</param>
        private void Synthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            this.SynthesizerSpeakStarted?.Invoke(this, e);
        }

        /// <summary>
        ///     Handles the <see cref="SpeechSynthesizer.VoiceChange" /> event of the <see cref="Synthesizer" />.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Synthesis.VoiceChangeEventArgs" /> instance containing the event data.</param>
        private void Synthesizer_VoiceChange(object sender, VoiceChangeEventArgs e)
        {
            this.SynthesizerVoiceChange?.Invoke(this, e);
        }

        /// <summary>
        ///     Handles the <see cref="Errored" /> event of this instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        private void this_Errored(object sender, UnhandledExceptionEventArgs e)
        {
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (sender == this)
            {
                this.IsErrored = true;
            }
        }

        /// <summary>
        ///     Handles the <see cref="PropertyChanged" /> event of this instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void this_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // ReSharper disable once PossibleUnintendedReferenceComparison
            if (sender == this)
            {
                this.IsErrored = false;
            }
        }

        /// <summary>
        ///     Occurs when an exception is thrown in a critical area of the speaker.
        /// </summary>
        public event UnhandledExceptionEventHandler Errored;

        /// <summary>
        ///     Occurs when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Occurs when the <see cref="Synthesizer" /> raises its <see cref="SpeechSynthesizer.VoiceChange" /> event.
        /// </summary>
        public event EventHandler<VoiceChangeEventArgs> SynthesizerVoiceChange;

        /// <summary>
        ///     Occurs when the <see cref="Synthesizer" /> raises its <see cref="SpeechSynthesizer.SpeakStarted" /> event.
        /// </summary>
        public event EventHandler<SpeakStartedEventArgs> SynthesizerSpeakStarted;

        /// <summary>
        ///     Occurs when the <see cref="Synthesizer" /> raises its <see cref="SpeechSynthesizer.SpeakCompleted" /> event.
        /// </summary>
        public event EventHandler<SpeakCompletedEventArgs> SynthesizerSpeakCompleted;

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has custom <see cref="SpeechSynthesizer" />, or if one should
        ///     be supplied.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has custom synthesizer; otherwise, <c>false</c>.
        /// </value>
        [XmlIgnore]
        public bool HasCustomSynthesizer => this.Synthesizer != null;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is in an errored state.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is in an errored state; otherwise, <c>false</c>.
        /// </value>
        [XmlIgnore]
        public bool IsErrored
        {
            get { return this._isErrored; }
            set { this._isErrored = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [IgnoreDataMember]
        private bool _isErrored;
        [DataMember(Name = "speakerName", IsRequired = true)]
        private string _speakerName;
        [IgnoreDataMember]
        private SpeechSynthesizer _synthesizer;
        [DataMember(Name = "voiceName", IsRequired = false)]
        private string _voiceName;

        #endregion
    }
}
