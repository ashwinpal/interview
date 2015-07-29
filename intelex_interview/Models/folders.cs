using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intelex_interview.Models
{
    public class folders
    {

        foldersLINQClassesDataContext objstructure = new foldersLINQClassesDataContext();

        public IQueryable<structure> getAllFolders()
        {
            var allfolders = objstructure.structures.Select(x => x);

            var a = allfolders.FirstOrDefault();

            if (a == null)
                return null;
            else
            return allfolders;
        }


    }
}