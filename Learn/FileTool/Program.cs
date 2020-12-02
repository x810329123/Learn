using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileTool
{
    class Program
    {
        private static Encoding Encoding950 = Encoding.GetEncoding(950);
        private static Encoding EncodingUTF8withoutBOM = new UTF8Encoding(false);
        private static byte[] UTF8Preamble = Encoding.UTF8.GetPreamble();

        private static StringBuilder stringBuilderUTF8 = new StringBuilder();
        private static StringBuilder stringBuilderUTF8withoutBOM = new StringBuilder();
        private static StringBuilder stringBuilderBig5 = new StringBuilder();
        private static StringBuilder stringElse = new StringBuilder();
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string path = @"C:\Users\jake_li\source\repos\STAYFUN-Mall43\src\Libraries\Nop.Core\Domain\Payments";
            path = @"C:\Users\jake_li\source\repos\STAYFUN-Mall43\src";
            List<string> fileExtensions = new List<string>() { "cs" };//"cshtml",,"config"
            var fileInfos = new List<FileInfo>();
            
            foreach (var fileExtension in fileExtensions)
            {
                var allDirectories = new DirectoryInfo(path).GetFiles(@$"*.{fileExtension}", SearchOption.AllDirectories);
                fileInfos.AddRange(allDirectories.ToList());
            }

            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            foreach (var fileInfo in fileInfos)
            {
                //SaveEncoding(fileInfo,  Encoding.UTF8, EncodingUTF8withoutBOM);
                var encoding = GetEncoding(fileInfo.FullName);
                if (Encoding950 == encoding)
                {
                    SaveEncoding(fileInfo, Encoding950, EncodingUTF8withoutBOM);
                }
                //if()
                //string allText = File.ReadAllText(fileInfo.FullName);
                //try
                //{

                //    File.WriteAllText(fileInfo.FullName, allText, utf8WithoutBom);
                //}
                //catch (Exception ex)
                //{
                //    stringBuilder.AppendLine(ex.Message);
                //}
                i++;
            }
            string log = stringBuilder.ToString();
            string logstringBuilderUTF8 = stringBuilderUTF8.ToString();
            string logstringBuilderUTF8withoutBOM = stringBuilderUTF8withoutBOM.ToString();
            string logstringBuilderBig5 = stringBuilderBig5.ToString();
            string logstringElse = stringElse.ToString();

        }

        private static void SaveEncoding(FileInfo fileInfo,Encoding originalEncoding, Encoding targetEncoding)
        {
            byte[] originalBytes = null;

            using (FileStream fs = new FileStream(fileInfo.FullName, FileMode.Open))
            {
                originalBytes = new byte[fs.Length];
                fs.Read(originalBytes, 0, (int)fs.Length);
            }

            byte[] bytes = Encoding.Convert(originalEncoding, targetEncoding, originalBytes);

            if (originalEncoding.CodePage == 65001
                && targetEncoding.CodePage == 65001
                && originalEncoding.GetPreamble().Count() == 0
                && targetEncoding.GetPreamble().Count() == 3)
            {
                bytes = UTF8Preamble.Concat(bytes).ToArray();
            }
            else if (originalEncoding.CodePage == 65001
                && targetEncoding.CodePage == 65001
                && originalEncoding.GetPreamble().Count() == 3
                && targetEncoding.GetPreamble().Count() == 0)
            {
                bytes = RemoveBom(bytes);
            }

            string result = targetEncoding.GetString(bytes);
            File.WriteAllText(fileInfo.FullName, result, targetEncoding);
        }

        private static bool IsUtf8Bom(byte[] buffer)
        {
            var isUtf8Bom = false;
            if (buffer != null && buffer.Length > 2)
            {
                if (buffer[0] == UTF8Preamble[0]
                        && buffer[1] == UTF8Preamble[1]
                        && buffer[2] == UTF8Preamble[2])
                {
                    isUtf8Bom = true;
                }
            }
            return isUtf8Bom;
        }

        private static byte[] RemoveBom(byte[] buffer)
        {
            if (buffer != null && buffer.Length > 2)
            {
                byte[] bomBuffer = Encoding.UTF8.GetPreamble();
                while (IsUtf8Bom(buffer))
                {
                    buffer = buffer.Skip(3).ToArray();
                }
            }
            return buffer;
        }

        public static Encoding GetEncoding(string filename)
        {
            var bytes = File.ReadAllBytes(filename);
            if (IsTragetEncoding(bytes, EncodingUTF8withoutBOM))
            {
                if (IsUtf8Bom(bytes))
                {
                    stringBuilderUTF8.AppendLine(filename);
                    return Encoding.UTF8;
                }
                else
                {
                    stringBuilderUTF8withoutBOM.AppendLine(filename);
                    return EncodingUTF8withoutBOM;
                }
            }
            else if (IsTragetEncoding(bytes, Encoding950))
            {
                stringBuilderBig5.AppendLine(filename);
                return Encoding950;
            }
            else if (IsTragetEncoding(bytes, Encoding.UTF8))
            {
                return Encoding.UTF8;
            }
            else
            {
                stringElse.AppendLine(filename);
                return Encoding.ASCII;
            }
        }



        public static bool IsTragetEncoding(byte[] bytes,Encoding targetEncoding)
        {
            //將byte[]轉為string再轉回byte[]看位元數是否有變
            var stringWithTragetEncoding = targetEncoding.GetString(bytes);
            var bytesWithTragetEncodingCount  = targetEncoding.GetByteCount(stringWithTragetEncoding);
            return bytes.Length == bytesWithTragetEncodingCount;
        }
    }
}
