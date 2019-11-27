using System.Drawing;

namespace HtmlRenderer.NetStandard2.XamarinForms.Z
{
    public class ZBrush
    {
    }

    public class ZSolidBrush : ZBrush
    {
        public ZSolidBrush(Color color) { this.color = color; }

        public Color color { get; set; }
    }
}
