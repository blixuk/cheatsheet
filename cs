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

def listAllFiles(list):
	if checkDirectory(DIRECTORY, EXTENTION):
		for file in list:
			print(os.path.basename(str(file)[:-3]))

def listAllTags(arg):
	if checkDirectory(DIRECTORY, EXTENTION):
		for file in FILES:
			lineNumber = 0
			with open(file) as f:
				for line in f:
					lineNumber += 1
					if arg in line.split():
						print(f'{os.path.basename(str(file)[:-3])} | Line: {lineNumber}')

def processFile(arg, key = False, tag = False):
	if checkDirectory(DIRECTORY, EXTENTION):
		cheatsheet = f'{DIRECTORY}/{arg}{EXTENTION[1:]}'
		if cheatsheet in FILES:
			displayFile(cheatsheet, key, tag)
		else:
			print(f'No cheatsheet for {arg}')

def displayFile(file, key, tag):
	with open(file) as f:
		for line in f:
			if key:
				if key in line:
					line = f'\033[0m\033[34m{line}\033[0m'
					line = line.replace(key, f'\033[0m\033[35m{key}\033[0m\033[34m')
					print(line, end='')
			elif tag:
				if line.startswith('@') and tag in line.split():
					displayFile(file, None, None)
					break
				elif tag in line.split():
					line = f'\033[0m\033[35m{line}\033[0m'
					line = line.replace(tag, '')
					print(line, end='')
			else:
				if line.startswith('#'):
					print(f'\033[0m\033[32m{line}\033[0m', end='')
				elif line.startswith('@'):
					#print()
					pass
				elif '@' in line:
					line = f'\033[0m\033[34m{line}\033[0m'
					line = line.split('@')
					print(line[0], end='\n')
				else:
					print(f'\033[0m\033[34m{line}\033[0m', end='')

if __name__ == "__main__":
	if len(sys.argv) == 1:
		listAllFiles(FILES)
	elif len(sys.argv) == 2:
		if sys.argv[1].startswith('@'):
			listAllTags(sys.argv[1])
		else:
			processFile(sys.argv[1], False, False)
	elif len(sys.argv) == 3:
		if sys.argv[2].startswith('@'):
			processFile(sys.argv[1], False, sys.argv[2])
		else:
			processFile(sys.argv[1], sys.argv[2], False)
	else:
		print('Too many arguments!')
