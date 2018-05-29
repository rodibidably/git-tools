using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace git_tools
{
    class Repository
    {
        // Properties
        private string _Folder;
        private string _Branch;
        private string _Status;
        public string Folder { get => _Folder; set => _Folder = value; }
        public string Branch { get => _Branch; set => _Branch = value; }
        public string Status { get => _Status; set => _Status = value; }
        // Constructors
        public Repository(string folder, string branch, string status)
        {
            _Folder = folder;
            _Branch = branch;
            _Status = status;
        }
        // Methods

    }
}
