namespace git_tools
{
    class Repository
    {
        Common blC = new Common();
        // Properties
        private string _Folder;
        private string _Branch;
        private string _Status;
        public string Folder { get => _Folder; set => _Folder = value; }
        public string Branch { get => _Branch; set => _Branch = value; }
        public string Status { get => _Status; set => _Status = value; }
        private bool _Diff;
        private bool _Untracked;
        private bool _NewFiles;
        private int? _Modified;
        private int? _Deleted;
        private bool _Unpulled;
        private bool _Unpushed;
        private bool _Stashed;
        private bool _Unmerged;
        private string _Remote;
        public bool Diff { get => _Diff; set => _Diff = value; }
        public bool Untracked { get => _Untracked; set => _Untracked = value; }
        public bool NewFiles { get => _NewFiles; set => _NewFiles = value; }
        public int? Modified { get => _Modified; set => _Modified = value; }
        public int? Deleted { get => _Deleted; set => _Deleted = value; }
        public bool Unpulled { get => _Unpulled; set => _Unpulled = value; }
        public bool Unpushed { get => _Unpushed; set => _Unpushed = value; }
        public bool Stashed { get => _Stashed; set => _Stashed = value; }
        public bool Unmerged { get => _Unmerged; set => _Unmerged = value; }
        public string Remote { get => _Remote; set => _Remote = value; }
        private bool _Display;
        public bool Display { get => _Display; set => _Display = value; }
        // Constructors
        public Repository(string folder, string branch, string status, bool diff, bool untracked, bool newFiles, int? modified, int? deleted, bool unpulled, bool unpushed, bool stashed, bool unmerged, string remote, bool display)
        {
            blC.Trace("folder: " + folder + " | branch: " + branch + " | status.Length: " + status.Length + " | diff: " + diff + " | untracked: " + untracked + " | newFiles: " + newFiles + " | modified: " + modified + " | deleted: " + deleted + " | unpulled: " + unpulled + " | unpushed: " + unpushed + " | stashed: " + stashed + " | unmerged: " + unmerged + " | remote: " + remote + " | display: " + display);

            _Folder = folder;
            _Branch = branch;
            _Status = status;
            _Diff = diff;
            _Untracked = untracked;
            _NewFiles = newFiles;
            _Modified = modified;
            _Deleted = deleted;
            _Unpulled = unpulled;
            _Unpushed = unpushed;
            _Stashed = stashed;
            _Unmerged = unmerged;
            _Remote = remote;
            _Display = display;
        }
        // Methods
    }
}
