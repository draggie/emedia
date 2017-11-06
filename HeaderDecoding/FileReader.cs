using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderDecoding
{
    public class FileReader
    {
        private readonly Image _image;
        private readonly string _fileName;
        public FileReader(string fileName)
        {
            _fileName = fileName;
            try
            {
                _image = Image.FromFile(_fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool HasFile()
        {
            return _image != null;
        }
        public Image GetImage()
        {
            return _image;
        }
        private string[] ConvertToHex()
        {
            var str = BitConverter.ToString(File.ReadAllBytes(_fileName));
            return str.Split('-').ToArray();
        }
        private string GetPrimitiveHeaders()
        {
            var hexArray = ConvertToHex();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hexArray.Length; i++)
            {
                // Recognize JPG
                if (hexArray[i] == "FF" && hexArray[i + 1] == "D8")
                {
                    sb.Append("Image type: jpg");
                    i = i + 1;
                }
                // JFIF marker (FFE0)
                else if (hexArray[i] == "FF" && hexArray[i + 1] == "E0")
                {
                    int lengthOfSection = int.Parse(hexArray[i + 2] + hexArray[i + 3], NumberStyles.HexNumber) + 2;
                    string units = int.Parse(hexArray[i + 11], NumberStyles.HexNumber) == 1 ? "dpi" : "dpc";
                    int horizontalResolution = int.Parse(hexArray[i + 12] + hexArray[i + 13], NumberStyles.HexNumber);
                    int verticalResolution = int.Parse(hexArray[i + 14] + hexArray[i + 15], NumberStyles.HexNumber);
                    sb.Append(Environment.NewLine);
                    sb.Append("Horizontal resolution: ");
                    sb.Append(horizontalResolution);
                    sb.Append(units);
                    sb.Append(Environment.NewLine);
                    sb.Append("Vertical resolution: ");
                    sb.Append(verticalResolution);
                    sb.Append(units);
                    i = i + lengthOfSection;
                }
                // JFIF marker (FFE0)
                else if (hexArray[i] == "FF" && hexArray[i + 1] == "C0")
                {
                    int lengthOfSection = int.Parse(hexArray[i + 2] + hexArray[i + 3], NumberStyles.HexNumber) + 2;
                    int dataPrecision = int.Parse(hexArray[i + 4], NumberStyles.HexNumber);
                    int imgHeight = int.Parse(hexArray[i + 5] + hexArray[i + 6], NumberStyles.HexNumber);
                    int imgWidth = int.Parse(hexArray[i + 7] + hexArray[i + 8], NumberStyles.HexNumber);

                    sb.Append(Environment.NewLine);
                    sb.Append("Image height: ");
                    sb.Append(imgHeight);
                    sb.Append("px");

                    sb.Append(Environment.NewLine);
                    sb.Append("Image width: ");
                    sb.Append(imgWidth);
                    sb.Append("px");

                    sb.Append(Environment.NewLine);
                    sb.Append("Precision: ");
                    sb.Append(dataPrecision);
                    sb.Append("bits/sample");
                    i = i + lengthOfSection;
                }
            }

            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
        private Dictionary<string, string> SpecialKeys = new Dictionary<string, string>()
        {
            {"0x10e","ImageDescription"}, {"0x10f","EquipMake" }, { "0x110","EquipModel"}, {"0x131","SoftwareUsed" },
            {"0x132","DateTime" }, { "0x13b","Artist"}, {"0x8298", "Copyright" }, {"0x9000","ExifVer" }, {"0x9003","ExifDTOrig"},
            {"0x9004","ExifDTDigitized" }
        };
        private string GetAdditionalHeaders()
        {
            PropertyItem[] propItems = _image.PropertyItems;
            int count = 0;
            string result = "";
            foreach (var prop in propItems)
            {
                var encoding = new UTF8Encoding();
                string value = encoding.GetString(propItems[count].Value);
                string code = "0x" + prop.Id.ToString("x");
                if (SpecialKeys.ContainsKey(code))
                {
                    string name = SpecialKeys[code];
                    value = value.Replace("\0", "");
                    result += $"{name}: {value}";
                    result += Environment.NewLine;
                }
                count++;
            }
            return result;
        }
        public string ListHeaders()
        {
            string primitiveHeaders = GetPrimitiveHeaders();
            string additionalHeaders = GetAdditionalHeaders();
            primitiveHeaders += additionalHeaders;
            return primitiveHeaders;
        }
    }
}
