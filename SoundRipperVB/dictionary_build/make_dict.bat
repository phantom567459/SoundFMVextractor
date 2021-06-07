@echo off
:: sort, remove redundant stuff and combine into 1 file
type input\*.txt | sort /unique > ..\dictionary.txt

