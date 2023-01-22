using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WebApiDemoekz
{
    public partial class Tour
    {
        public SolidColorBrush TourColor
        {
            get
            {
                switch (IsActual)
                {
                    case true:
                        return Brushes.LightGreen;
                    case false:
                        return Brushes.LightPink;
                    default:
                        return Brushes.White;
                }
            }
        }
        public BitmapImage ImgProp
        {
            get
            {
                if (ImagePreview != null)
                {
                    return new BitmapImage(new Uri(Environment.CurrentDirectory + ImagePreview, UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("\\Resources\\picture.png", UriKind.RelativeOrAbsolute));
                }
            }
        }
    }

        public partial class Hotel
        {
            public int CountProp
            {
                get
                {
                    List<HotelOfTour> list = BaseClass.tBD.HotelOfTour.Where(x => x.id_hotel == Id).ToList();
                    return list.Count;
                }
            }

        }
}