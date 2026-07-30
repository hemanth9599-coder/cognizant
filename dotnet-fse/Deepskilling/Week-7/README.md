# Week 7 — Git Hands-on Labs

This submission completes the five Git hands-on labs. The commands are written
for Git Bash, PowerShell, macOS Terminal, or Linux shells. Replace the example
GitHub URL with your own repository URL where noted.

## Prerequisites

```bash
git --version
git config --global user.name "Your Name"
git config --global user.email "your-email@example.com"
git config --global core.editor "notepad++.exe -multiInst -notabbar -nosession -noPlugin"
git config --global --list
```

> The editor configuration is optional on macOS/Linux; use `code --wait`,
> `nano`, or another installed editor instead.

## Lab 1 — Repository setup, tracking, and remote push

Create a local repository and its first tracked file:

```bash
mkdir GitDemo
cd GitDemo
git init -b main
printf "Welcome to Git\n" > welcome.txt
git status
git add welcome.txt
git commit -m "Add welcome message"
git status
```

Create an empty GitHub repository, then connect and publish the local commit:

```bash
git remote add origin https://github.com/<username>/GitDemo.git
git remote -v
git push -u origin main
```

If the remote was created with a README, `.gitignore`, or license, it already
has a commit. Fetch and merge that history before the first push:

```bash
git pull origin main --allow-unrelated-histories
git push -u origin main
```

The sample first file is included at [lab-1/welcome.txt](lab-1/welcome.txt).

## Lab 2 — Ignoring unwanted files

The [lab-2/.gitignore](lab-2/.gitignore) file ignores every `.log` file and
any `logs/` directory at any depth:

```gitignore
*.log
logs/
**/logs/
```

Verify the rules without adding ignored files:

```bash
git check-ignore -v application.log logs/app.log
git status --ignored
git add .gitignore
git commit -m "Ignore logs and log files"
```

If a log was already committed, remove it from the Git index (but keep the
local copy) before committing the ignore rule:

```bash
git rm --cached path/to/file.log
```

## Lab 3 — Branching and merging

```bash
git switch -c GitNewBranch
printf "Feature work\n" > feature.txt
git add feature.txt
git commit -m "Add feature work"
git status
git branch -a

git switch main
git diff main...GitNewBranch
git log --oneline --graph --decorate --all
git merge --no-ff GitNewBranch -m "Merge GitNewBranch"
git branch -d GitNewBranch
git status
```

`git difftool main...GitNewBranch` opens the configured visual diff tool when
one is available (for example, P4Merge).

## Lab 4 — Resolve a merge conflict

Use different edits to the same file on two branches to produce a conflict:

```bash
git switch -c GitWork
printf '<message>Hello from GitWork</message>\n' > hello.xml
git add hello.xml
git commit -m "Add branch greeting"

git switch main
printf '<message>Hello from main</message>\n' > hello.xml
git add hello.xml
git commit -m "Add main greeting"

git merge GitWork
```

Git marks the conflict in `hello.xml`. Resolve it by keeping the required
content, then complete the merge:

```bash
printf '<message>Hello from main and GitWork</message>\n' > hello.xml
git add hello.xml
git commit -m "Resolve hello.xml merge conflict"
git status
git log --oneline --graph --decorate --all
```

Add `*.bak` to `.gitignore`, commit it, and remove the merged branch:

```bash
printf '\n*.bak\n' >> .gitignore
git add .gitignore
git commit -m "Ignore backup files"
git branch -d GitWork
```

The resolved content is represented in
[lab-4/hello.xml](lab-4/hello.xml).

## Lab 5 — Clean up and push

Before ending the session, make sure the working tree is clean and the branch
is synchronized with its upstream:

```bash
git status
git branch -vv
git pull --ff-only origin main
git push origin main
git status
```

`git pull --ff-only` prevents an accidental merge commit. If it fails because
the local and remote histories diverged, inspect the changes with
`git log --oneline --graph --decorate --all`, then merge or rebase deliberately
before pushing.

## Verification checklist

- [x] Git identity and default editor commands documented.
- [x] Initial file staging, commit, remote connection, pull, and push covered.
- [x] Log files and log directories ignored.
- [x] Feature branch created, compared, merged, and deleted.
- [x] Same-file merge conflict created and resolved.
- [x] Final clean-up, fast-forward pull, and push procedure documented.
