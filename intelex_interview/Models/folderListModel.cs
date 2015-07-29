using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intelex_interview.Models
{
    public class folderListModel
    {
       
       public int Id { get; set; }

       public string Name { get; set; }

       public int Parent_Id { get; set; }
        
       public List<folderListModel> subfolders;
        
    }
}