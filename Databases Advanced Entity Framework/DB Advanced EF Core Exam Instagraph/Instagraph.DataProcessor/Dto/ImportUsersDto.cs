using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Instagraph.DataProcessor.Dto
{
    public class ImportUsersDto
    {
        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        //"Username" : "UnderSinduxrein",
        //"Password" : "4l8nYGTKMW",
        //"ProfilePicture" : "src/folders/resources/images/post/formed/digi/6YLvj97k03.digi"
    }
}
