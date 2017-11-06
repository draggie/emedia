using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderDecoding
{
    public class FFT
    {
        private readonly ComplexImage _complexImage;
        public FFT(Bitmap map)
        {
            _complexImage = ComplexImage.FromBitmap(ScaleToGray(map));
        }
        public Bitmap GetForwardFourierTransform()
        {
            ComplexImage copy = _complexImage;
            copy.ForwardFourierTransform();
            Bitmap fourierImage = copy.ToBitmap();
            return fourierImage;
        }

        public Bitmap GetBackwardFourierTransform()
        {
            ComplexImage copy = _complexImage;
            copy.BackwardFourierTransform();
            Bitmap fourierImage = copy.ToBitmap();
            return fourierImage;
        }

        private Bitmap ScaleToGray(Bitmap tmp)
        {
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            tmp = filter.Apply(tmp);
            return tmp;
        }
    }
}
