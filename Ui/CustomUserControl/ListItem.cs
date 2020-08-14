using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENothi_Desktop.Ui.CustomUserControl
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        private string _sourceName;
        private string _senderName;
        private string _receiverName;
        private string _subject;
        private string _decesion;

        private string _onulipiOrPrapok;
        private string _security;
        private string _priority;
        private string _nothiOrigin;
        private string _dakType;
        private Image _dakTypeIcon;
        private string _dakViewStatus;

        private string _tooltipText;

        [Category("Custom Props")]
        public string DakViewStatus
        {
            get { return _dakViewStatus; }
            set
            {
                _dakViewStatus = value;
              
               if (_dakViewStatus == "New")
               {
                   newLabel.Visible = true;
               }       
            }
        }



        [Category("Custom Props")]
        public string TooltipText
        {
            get { return _tooltipText; }
            set
            {
                _tooltipText = value;              
            }
        }


        [Category("Custom Props")]
        public string OnulipiOrPrapok
        {
            get { return _onulipiOrPrapok; }
            set
            {
                _onulipiOrPrapok = value;
                praporkOrOnulipiLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                priorityLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public string NothiOrigin
        {
            get { return _nothiOrigin; }
            set
            {
                _nothiOrigin = value;
                nothiLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Security
        {
            get { return _security; }
            set
            {
                _security = value;
                securityLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public string DakType
        {
            get { return _dakType; }
            set
            {
                _dakType = value;
                nagorikOrdaptorikLabel.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image DakTypeIcon
        {
            get { return _dakTypeIcon; }
            set
            {
                _dakTypeIcon = value;
                dakTypeIcon.Image = _dakTypeIcon;
            }
        }


        [Category("Custom Props")]
        public string SourceName
        {
            get { return _sourceName; }
            set { _sourceName = value;
                utshoName.Text = value;
                
            }
        }

        [Category("Custom Props")]
        public string SenderName
        {
            get { return _senderName; }
            set
            {
                _senderName = value;
                prerokLabel.Text = value;
            }
        }
        [Category("Custom Props")]
        public string ReceiverName
        {
            get { return _receiverName; }
            set
            {
                _receiverName = value;
                PraprokLabel.Text = value;
            }
        }
        [Category("Custom Props")]
        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                if (_subject.Length>70)
                {
                    var firstPart = _subject.Substring(0, 70);
                    var secPart = _subject.Substring(70, _subject.Length-70);
                    var subject = firstPart + '\n' + secPart;
                    subjectLabel.Text = subject;
                }
                else
                {
                    subjectLabel.Text = value;
                }
               
            }
        }
        [Category("Custom Props")]
        public string Decision
        {
            get { return _decesion; }
            set
            {
                _decesion = value;
                decesionLabel.Text = value;
            }
        }

        private void ListItem_Load(object sender, EventArgs e)
        {
           
        }

        private void label4_Paint(object sender, PaintEventArgs e)
        {         
            ControlPaint.DrawBorder(e.Graphics, newLabel.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void utshoName_MouseEnter(object sender, EventArgs e)
        {
            var yourToolTip = new ToolTip();
          //  yourToolTip.ToolTipIcon = ToolTipIcon.Info;
            yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;

            yourToolTip.SetToolTip(utshoName, _tooltipText);
        }       
    }
}
