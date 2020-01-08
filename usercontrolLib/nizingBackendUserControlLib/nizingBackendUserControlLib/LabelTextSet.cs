using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nizingBackendUserControlLib
{
    public partial class LabelTextSet: UserControl
    {
        public LabelTextSet()
        {
            InitializeComponent();
            lblTitle.Text = this.Name;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title 
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text 
        { 
            get => txtContent.Text; 
            set => txtContent.Text = value; 
        }

        private void LblTitle_SizeChanged(object sender, EventArgs e)
        {
            this.Width = lblTitle.Width + txtContent.Width;
        }
    }
}
