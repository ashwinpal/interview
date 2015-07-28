using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace intelex_interview.Models
{
    /*
     * validation from foldersModel for the LINQ class - structure
     * 
    */
    [MetadataType(typeof(foldersModel))]
    public partial class structure
    { 
        
    }

    /*
     * Providing the validation required for the model
     * 
    */

    [Bind(Exclude= "Id,Parent_Id")]
    public class foldersModel
    {
        public int Id { get; set; }

        [DisplayName("Folder Title")]
        [Required(ErrorMessage = "Please enter the folder title")]
        public string Name { get; set; }

        public int Parent_Id { get; set; }

    }
}