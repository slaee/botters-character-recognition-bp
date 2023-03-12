using System.ComponentModel.Design;
using System.ComponentModel;

namespace CharacterRecognitionBP.Components
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class TransparentPictureBox : PictureBox
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
    }
}
