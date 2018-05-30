namespace git_tools
{
    class Repository
    {
        // Properties
        private string _Folder;
        private string _Branch;
        private string _Status;
        private string _Remote;
        public string Folder { get => _Folder; set => _Folder = value; }
        public string Branch { get => _Branch; set => _Branch = value; }
        public string Status { get => _Status; set => _Status = value; }
        public string Remote { get => _Remote; set => _Remote = value; }
        private bool _Untracked;
        private bool _NewFiles;
        private bool _Modified;
        private bool _Deleted;
        private bool _Unpulled;
        private bool _Unpushed;
        public bool Untracked { get => _Untracked; set => _Untracked = value; }
        public bool NewFiles { get => _NewFiles; set => _NewFiles = value; }
        public bool Modified { get => _Modified; set => _Modified = value; }
        public bool Deleted { get => _Deleted; set => _Deleted = value; }
        public bool Unpulled { get => _Unpulled; set => _Unpulled = value; }
        public bool Unpushed { get => _Unpushed; set => _Unpushed = value; }
        // Constructors
        public Repository(string folder, string branch, string status)
        {
            _Folder = folder;
            _Branch = branch;
            _Status = status;
        }
        public Repository(string folder, string branch, string status, string remote, bool untracked, bool newFiles, bool modified, bool deleted, bool unpulled, bool unpushed)
        {
            _Folder = folder;
            _Branch = branch;
            _Status = status;
            _Remote = remote;
            _Untracked = untracked;
            _NewFiles = newFiles;
            _Modified = modified;
            _Deleted = deleted;
            _Unpulled = unpulled;
            _Unpushed = unpushed;
        }
        // Methods
    }
}
