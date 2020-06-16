#!/usr/bin/env python3
# About: Cheat Sheet - A simple plain text cheat sheet reader
# Author: Blix

import os
import pathlib
import sys

DIRECTORY = pathlib.Path(pathlib.Path.home() / '.config/cheatsheets/')
EXTENTION = "*.ch"
FILES = []

def checkDirectory(directory, extention):
	status = False
	if directory.is_dir():
		status = True
		if any(directory.iterdir()):
			for file in directory.glob(extention):
				FILES.append(str(file))
		else:
			print('Directory is empty!')
	else:
		status = False
		print("Directory doesn't exist!")
	return status

def listAllFiles(files):
	if checkDirectory(DIRECTORY, EXTENTION):
		for file in files:
			print(os.path.basename(str(file)[:-3]))

def processFiles(arg, key):
	if checkDirectory(DIRECTORY, EXTENTION):
		cheatsheet = f'{DIRECTORY}/{arg}{EXTENTION[1:]}'
		if cheatsheet in FILES:
			displayFile(cheatsheet, key)
		else:
			print(f'No cheatsheet for {arg}')

def displayFile(file, key):
	with open(file) as f:
		for line in f:
			if key:
				if key in line:
					line = f'\033[0m\033[34m{line}\033[0m'
					line = line.replace(key, f'\033[0m\033[35m{key}\033[0m\033[34m')
					print(line, end='')
			else:
				if line.startswith('#'):
					print(f'\033[0m\033[32m{line}\033[0m', end='')
				else:
					print(f'\033[0m\033[34m{line}\033[0m', end='')

if __name__ == "__main__":
	if len(sys.argv) == 1:
		listAllFiles(FILES)
	elif len(sys.argv) == 2:
		processFiles(sys.argv[1], None)
	elif len(sys.argv) == 3:
		processFiles(sys.argv[1], sys.argv[2])
	else:
		print('Too many arguments!')
