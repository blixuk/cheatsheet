# cheatsheet
cheatsheet - A simple plain text cheat sheet reader

## How it works
```
cs              - Return a list of all cheat sheets
cs <arg>        - Return the full cheat sheet for <arg>
cs <arg> <key>  - Return all instances of <key> in <arg>
cs <tag>        - Return a list of all mentions of <tag> in all cheat sheets
cs <arg> <tag>  - Return all instances of <tag> in <arg>
```
Giving cheatsheet no arguments will return a list of all cheat sheets.
```
> cs
ls
```
Giving cheatsheet just the argument; if there is a cheat sheet for it, it will return all the information in the cheat sheet.
```
> cs ls
@list
# To display everything in <dir>, excluding hidden files:
ls <dir>

# To display everything in <dir>, including hidden files:
ls -a <dir> @listall

# To display all files, along with the size (with unit suffixes) and timestamp
ls -lh <dir>

# To display files, sorted by size:
ls -S <dir>

# To display directories only:
ls -d */ <dir>

# To display directories only, include hidden:
ls -d .*/ */ <dir>

```
Giving cheatsheet an argument and a key; cheatsheet will return all instances of that key in the cheat sheet. (This does not include comments.)
```
> cs ls -d
ls -d */ <dir>
ls -d .*/ */ <dir>
```
Giving cheatsheet a tag will return a list with all instance of that tag in all cheat sheets.
```
> cs @list
ls | Line: 1
```

Giving cheatsheet a argument and a tag will return the line being tagged.
```
> cs ls @listall
ls -a <dir>
```
But if the tag is at the start of a line, it will be treated as a global tag and return the whole file.
```
> cs ls @list
# To display everything in <dir>, excluding hidden files:
ls <dir>

# To display everything in <dir>, including hidden files:
ls -a <dir> @listall

# To display all files, along with the size (with unit suffixes) and timestamp
ls -lh <dir>

# To display files, sorted by size:
ls -S <dir>

# To display directories only:
ls -d */ <dir>

# To display directories only, include hidden:
ls -d .*/ */ <dir>
```

Cheat sheets are plain text files with a '.ch' extension. They are written line by line and use a '#' for comments and '@' for tags
```
@list
# To display everything in <dir>, excluding hidden files:
ls <dir>

# To display everything in <dir>, including hidden files:
ls -a <dir> @listall

# To display all files, along with the size (with unit suffixes) and timestamp
ls -lh <dir>

# To display files, sorted by size:
ls -S <dir>

# To display directories only:
ls -d */ <dir>

# To display directories only, include hidden:
ls -d .*/ */ <dir>
```
Cheat sheets are stored in '.config'. This location can be changed in the code.
```
~/.config/cheatsheets/*.ch
```
