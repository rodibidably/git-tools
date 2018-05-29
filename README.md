# git-tools
**git-tools is a .NET application that acts as a wrapper around many popular git functions to make development easier**

## git-summary
**Will cleanly list the current status of any Git repos it finds within any directory (and sub-directories) on your system**

**If you ever experienced one of the following situations, git-summary is for you.**
- I don't remember where some of my repositories are...
- Did I forgot to push that commit...?
- Do I have a repo in my system that is outdated...?
- Did someone push new commits to `origin/master` in one of my repos...?
- Did I commit that quick change I made before the delivery guy rang my door...?

#### Options
- **Folder Selection** - The folder to run git-summary against
- **Local Summary** (default = on) - Checks only local changes (does not first run `git fetch`), which runs faster
- **Deep Lookup** (default = off) - Will look for Git repos recursively within the directory tree (does not search sub folders under a Git repo). Can be slow for large directory trees

#### ToDo:
- Make git-summary run as a background process and give a progress bar / status
- Cleanup Status, to be easier to read
  - Split Status into individual values for Counts?

#### Credits
A big thanks to the folks that wrote the (Linux) version of `git-summary` that this borrowed from:
- [MirkoLedda](https://github.com/MirkoLedda/git-summary) 
  - This is the project (a fork of a series of repositories, worked on by many people) used as a reference

## Branch status
**Coming next in development**

Currently, `git-summary` does not list multiple branches per repo. However, for single repos [`git-branch-status`](https://github.com/bill-auger/git-branch-status) does this beautifully.
