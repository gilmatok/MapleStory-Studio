using Fraysa.MapleStory.reWZ.WZProperties;
using NAudio.Wave;
using System;
using System.IO;

namespace Fraysa.MapleStory.Studio.Editors
{
    public partial class AudioEditor : EditorBase
    {
        private Stream byteStream;
        private Mp3FileReader mpegStream;
        private WaveOut wavePlayer;
        private bool repeat;

        public AudioEditor()
        {
            InitializeComponent();
        }

        internal override WZObject WzObject
        {
            get
            {
                return base.WzObject;
            }

            set
            {
                base.WzObject = value;

                var soundData = ((WZAudioProperty)this.WzObject).Value;
                byteStream = new MemoryStream(soundData);
                mpegStream = new Mp3FileReader(byteStream);
                wavePlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());
                wavePlayer.Init(mpegStream);
                wavePlayer.PlaybackStopped += new System.EventHandler<StoppedEventArgs>(this.PlaybackStopped);
            }
        }

        private void _btPlay_Click(object sender, System.EventArgs e)
        {
            if (_btPlay.Text == "Play")
            {
                this.Play();

                _btPlay.Text = "Pause";
            }
            else
            {
                this.Pause();

                _btPlay.Text = "Play";
            }
        }

        private void PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (repeat && !disposed)
            {
                mpegStream.Seek(0, SeekOrigin.Begin);
                wavePlayer.Pause();
                wavePlayer.Play();
            }
        }

        public void Play()
        {
            wavePlayer.Play();
        }

        public void Pause()
        {
            wavePlayer.Pause();
        }

        public bool Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

        public int Length
        {
            get { return 0; }
        }

        public int Position
        {
            get
            {
                return (int)(mpegStream.Position / mpegStream.WaveFormat.AverageBytesPerSecond);
            }
            set
            {
                mpegStream.Seek(value * mpegStream.WaveFormat.AverageBytesPerSecond, SeekOrigin.Begin);
            }
        }

        private bool disposed = false;
        public bool Disposed
        {
            get { return disposed; }
        }
        public override void CustomDispose()
        {
            disposed = true;
            wavePlayer.Dispose();
            mpegStream.Dispose();
            byteStream.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void AudioEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
