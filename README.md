# SoundRipperVB
For extracting sounds and FMV from Pandemic's SWBF and The Clone Wars games

Run from the command line.  Sound files are in .lvl or .bnk format, and are located in Gamedata\Data\_LVL_platform\Sound\. For TCW PS2, file names are .msh/msb.  Both are accepted, the program figures out what it needs.

This also works on FMVs for PC/PS2/XBOX.  All FMVs are located in Gamedata\Data\_LVL_platform\Movies.

Format for usage:

SoundRipperVB.exe -i *filename* -p *pc/ps2/xbox* -v *bf1/bf2/tcw*

replace filename with your file, e.g. common.bnk

All PC sounds are in .wav format.  Sounds in .bnk files are in native PCM16, and all others that I have found are IMA ADPCM format (4:1 compression of .wav).  Xbox is slightly different (all in Xbox ADPCM, which is almost exactly the same as IMA ADPCM).
All movies on PC are in BIK format, PS2 is PSS, and Xbox is XMV.

The program tries its hardest to name them correctly.
The names of the files are stored as 'hashed' strings in the .lvl files.
This program has a 'dictionary.txt' file containing the 'known' filenames which allow us to resolve the filenames from the hashed values in the lvl file. You can add strings to the dictionary to expand the program's ability to 'unhash' the filenames.

To play these files, the current option is to use VLC Media Player, which can support all of these files, except PS2 VAG format.
If you wish to munge these files back into the game, you must convert them (except for common.bnk) back to PCM16 through ffmpeg (here: https://www.ffmpeg.org/download.html).  For now, use:

ffmpeg -i *inputfile* *outputfile*

If you need more options, the format you want to output to is pcm_s16le.  All the other relevant information should be in the header and caught by ffmpeg.

For larger jobs, FFMpeg Batch is absolutely amazing, and includes a GUI.

Default is pc/bf1.  
If you wish to extract and use .pss movie files, you will need to research PSS demuxing and converting.  This is beyond the scope of this program.

Update 1/21/2020 - officially added BF2 support (it's been there in the source for a while).  Added support for PS2 The Clone Wars, with limited functionality.  BF2 and BF1 hash lists were split off.

Update 10/31/2019 - Happy Halloween! Public Release - fixed common.bnk for SWBF1, added xmv extraction (still wonky), added -v (version) with bf2 option but only works for common.bnk at the moment.

Update 10/22/2019 - fixed most PS2 VAG extraction, PSS extraction complete, Xbox sound support added, added xbox to platform argument, just a little code cleanup.

Update 10/11/2019 - added janky PS2 VAG functionality and -p (for platform) command line option.  Please use ffmpeg as above to convert VAG to PCM16

Updated 5/30/2021 - Fixed PS2 VAG extract bug, added all known BF1 & Bf2 sound file names & aliases.

This is a WIP and does not extract some sounds correctly. Please file an issue and be specific on what file is not working and platform.

Issues:
1.) Better support for planet sound lvls on console (and somewhat on PC) (.st4 currently broken)
2.) PS2 dual channel music (may not fix)
3.) Better xmv support

Credits:
Dark_Phantom - creator

psych0fred - help with file formats and file comparisons and FilenameHashes.csv and overall knowledge of the BF sound engine

Sleepkiller - programming help, file formats, code contributions

BAD_AL - HashHelper.vb & PS2 Vag extract bug fix.

SWBFgamers.com - for their amazing community and contributions toward SWBF1

My family - for putting up with me all the time and supporting me

This is not an extensive list, but I couldn't have done this without any of the contributors above.
