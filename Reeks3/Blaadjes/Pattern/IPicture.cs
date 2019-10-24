using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Blaadjes.Pattern
{
    public interface IPicture
    {
        Image Image { get; }
        Point Move(Point p);
    }
}