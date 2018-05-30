# git-tools
**git-tools is a .NET application that acts as a wrapper around many popular git functions, designed to make using Git easier**

## git-summary
**Cleanly lists the current status of any Git repositories it finds within any directory (and sub-directories) on your system**

**If you ever experienced one of the following situations, `git-summary` is for you.**
- I don't remember where some of my repositories are...
- Did I forgot to push that commit...?
- Do I have a repo in my system that is outdated...?
- Did someone push new commits to `origin/master` in one of my repos...?
- Did I commit that quick change I made before the delivery guy rang my door...?

#### Options
- **Folder Selection** - The folder to run git-summary against; Selected on Button_Click
- **Run `Fetch`** (default = off) - Checks local and remote changes (i.e. first run `git fetch`); Runs slower
- **Run `Unpulled`** (default = off) - Checks local and remote changes (i.e. first run `git log --pretty=format:'%h' ..@{u}`); Runs slower
- **Run `Unpushed`** (default = off) - Checks local and remote changes (i.e. first run `git log --pretty=format:'%h' @{u}..`); Runs slower
- **Run `Stashed`** (default = off) - Checks local and remote changes (i.e. first run `git stash list`); Runs slower
- **Run `Unmerged`** (default = off) - Checks local and remote changes (i.e. first run `git branch --no-merged master`); Runs slower
- **Recursive** (default = off) - Will look for Git repos recursively within the directory tree (does not search sub folders under a Git repo); Can be slow for large directory trees
- **Show All Repos** (default = on) - Show all Repositories in List, even those without changes

#### ToDo
- 

## git-branch-status
**Coming next in development**
- Currently, `git-summary` does not list multiple branches per repo. However, for single repos [`git-branch-status`](https://github.com/bill-auger/git-branch-status) does this beautifully.

## Credits
A big thanks to the folks that wrote the (Linux) versions that this project borrowed from:
- [MirkoLedda](https://github.com/MirkoLedda/git-summary) - Primary reference for `git-summary`
- [pzimmermann](https://github.com/pzimmermann/git-summary) - Remote origin url for `git-summary`
- [mestremuten](https://github.com/mestremuten/git-summary) - Check for stashed changes & unmerged branches for `git-summary`
- [bill-auger](https://github.com/bill-auger/git-branch-status) - Primary reference for `git-branch-status`
