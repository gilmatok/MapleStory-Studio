using System.Drawing;
using ImageMagick;

namespace Fraysa.MapleStory.Studio.Editors
{
    public partial class ImageEditor : EditorBase
    {
        public ImageEditor()
        {
            InitializeComponent();
        }

        internal override string NodePath
        {
            get
            {
                return base.NodePath;
            }
            set
            {
                base.NodePath = value;

                // Display the image.
                MagickImage magickImage = new MagickImage(base.NodePath);
                Bitmap bitmap = magickImage.ToBitmap();
                _pbImage.Size = bitmap.Size;
                _pbImage.Image = bitmap;
            }
        }
    }
}
