# SoundRipperVB
For extracting sounds and FMV from SWBF1 PC

Put your sound file in the same folder as the .exe and run from the command line.  Sound files are in .lvl or .bnk format, and are located in Gamedata\Data\_LVL_PC\Sound\.
This also works on FMVs for PC.  All FMVs are located in Gamedata\Data\_LVL_PC\Movies.

Format for usage:
SoundRipperVB.exe -i *filename* -p *pc/ps2*
replace filename with your file, e.g. common.bnk

All sounds are in .wav format.  Sounds in .bnk files are in native PCM16, and all others that I have found are IMA ADPCM format (4:1 compression of .wav).  All movies are in BIK format.
The program tries its hardest to name them correctly using FilenameHashes.csv which needs to be in the folder with the .exe. (included in the main folder here)
To play these files, the current option is to use VLC Media Player, which can support these files.
If you wish to munge these files back into the game, you must convert them back to PCM16 through ffmpeg (here: https://www.ffmpeg.org/download.html).  I'm researching cleanup commands, but for now, use:
ffmpeg -i *inputfile* *outputfile*
If you need more options, the format you want to output to is pcm_s16le.  All the other relevant information should be in the header and caught by ffmpeg.


There is some "experimental" (meaning not done) functionality for PS2 .pss movie files - change platform from PC to PS2 in cmd.  Default is pc.  Future goals are to include complete support for PS2 movie and sound files, but this is not a priority.
If you wish to extract and use .pss movie files, you will need to research PSS demuxing and converting.  This is beyond the scope of this program.

Update 10/11/2019 - added janky PS2 VAG functionality and -p (for platform) command line option.  Please use ffmpeg as above to convert VAG to PCM16

This is a WIP and does not extract some sounds correctly.