# SoundRipperVB
For extracting sounds and FMV from Pandemic's SWBF games

Put your sound file in the same folder as the .exe and run from the command line.  Sound files are in .lvl or .bnk format, and are located in Gamedata\Data\_LVL_platform\Sound\.
This also works on FMVs for PC/PS2.  All FMVs are located in Gamedata\Data\_LVL_platform\Movies.

Format for usage:
SoundRipperVB.exe -i *filename* -p *pc/ps2/xbox* -v *bf1/bf2*

replace filename with your file, e.g. common.bnk

All PC sounds are in .wav format.  Sounds in .bnk files are in native PCM16, and all others that I have found are IMA ADPCM format (4:1 compression of .wav).  Xbox is slightly different (all in Xbox ADPCM, which is almost exactly the same as IMA ADPCM).
All movies on PC are in BIK format, PS2 is PSS, and Xbox is XMV.

The program tries its hardest to name them correctly using FilenameHashes.csv which needs to be in the folder with the .exe. (included in the main folder here)
To play these files, the current option is to use VLC Media Player, which can support all of these files, except PS2 VAG format.
If you wish to munge these files back into the game, you must convert them (except for common.bnk) back to PCM16 through ffmpeg (here: https://www.ffmpeg.org/download.html).  I'm researching cleanup commands, but for now, use:
ffmpeg -i *inputfile* *outputfile*
If you need more options, the format you want to output to is pcm_s16le.  All the other relevant information should be in the header and caught by ffmpeg.
For larger jobs, FFMpeg Batch is absolutely amazing, and includes a GUI.

Default is pc/bf1.  Future goals are to include complete support for PS2 and Xbox files, but this is not a priority.
If you wish to extract and use .pss movie files, you will need to research PSS demuxing and converting.  This is beyond the scope of this program.

Update 10/31/2019 - Happy Halloween! Public Release - fixed common.bnk for SWBF1, added xmv extraction (still wonky), added -v (version) with bf2 option but only works for common.bnk at the moment.

Update 10/22/2019 - fixed most PS2 VAG extraction, PSS extraction complete, Xbox sound support added, added xbox to platform argument, just a little code cleanup.

Update 10/11/2019 - added janky PS2 VAG functionality and -p (for platform) command line option.  Please use ffmpeg as above to convert VAG to PCM16

This is a WIP and does not extract some sounds correctly. Please file an issue and be specific on what file is not working and platform.

Issues:
1.) BF2 support 
2.) Better support for planet sound lvls on console (and somewhat on PC)
3.) PS2 dual channel music (may not fix)
4.) Better xmv support

Credits:
Dark_Phantom - creator
psych0fred - help with file formats and file comparisons and FilenameHashes.csv
Sleepkiller - programming help, file formats, code contributions
SWBFgamers.com - for their amazing community and contributions toward SWBF1
My family - for putting up with me all the time and supporting me

This is not an extensive list, but I couldn't have done this without any of the contributors above.