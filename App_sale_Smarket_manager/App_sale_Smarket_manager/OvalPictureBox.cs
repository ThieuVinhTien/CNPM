using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[ToolboxItem(true)]
internal class OvalPictureBox : PictureBox
{
    private IContainer components;

    public OvalPictureBox()
    {
        this.BackColor = Color.DarkGray;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        using (var gp = new GraphicsPath())
        {
            gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 2));
            this.Region = new Region(gp);
        }
    }

    private void InitializeComponent()
    {
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        this.SuspendLayout();
        //
        // OvalPictureBox
        //
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        this.ResumeLayout(false);
    }
}