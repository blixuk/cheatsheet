# cheatsheet
cheatsheet - A simple plain text cheat sheet reader

## How it works
```
cs <arg> <key>
```
Giving cheatsheet no arguments will return a list of all cheat sheets.
```
> cs
ls
```
Giving cheatsheet just the argument; if there is a cheat sheet for it, it will return all the information in the cheat sheet.
```
> cs ls
# To display everything in <dir>, excluding hidden files:
ls <dir>

# To display everything in <dir>, including hidden files:
ls -a <dir>

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
Cheat sheets are plain text files with a '.ch' extension. They are written line by line and use a '#' for comments.

The file extension and the comment symbol can be changed in the code.

```
# To display everything in <dir>, excluding hidden files:
ls <dir>

# To display everything in <dir>, including hidden files:
ls -a <dir>

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