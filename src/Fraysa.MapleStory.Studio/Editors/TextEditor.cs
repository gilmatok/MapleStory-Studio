using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fraysa.MapleStory.reWZ.WZProperties;

namespace Fraysa.MapleStory.Studio.Editors
{
    public partial class TextEditor : EditorBase
    {
        public TextEditor()
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

                _lbInformation.Text = value.ValueOrDie<string>();
            }
        }
    }
}
