using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.DataProcessor.Dto
{
    public class ImportPicturesDto
    {
        public string Path { get; set; }

        public decimal Size { get; set; }

        //"Path" : "src/folders/resources/images/profile/blocked/bmp/kjOJjKpKh4.bmp",
        //"Size" : 32495.57
    }
}
