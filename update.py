import sys

def Hash(str):
    FNV_prime = 16777619
    offset_basis = 2166136261

    hash = offset_basis
    for c in str:
        c = ord(c)
        c |= 0x20

        # ensure 32 bit int
        c &= 0xffffffff

        hash ^= c
        hash &= 0xffffffff
        hash *= FNV_prime
        hash &= 0xffffffff

    return hash

names = set()

for i, line in enumerate(open("FilenameHashesBF2.csv")):
    hash, name = line.split(',')
    # we could also store the already hashed names, but I'm too 
    # lazy to implement a proper pair sorting, so just sort the
    # names and simply rehash everything. It's not like
    # performance is important here...
    names.add(name)

# newnames.txt just contains names split by \n, no hashes
for i, line in enumerate(open("newnames.txt")):
    names.add(line)

names = sorted(names, key=lambda s: s.lower())

file = open("FilenameHashesBF2.csv", "w")
for name in names:
    file.write(hex(Hash(name)) + "," + name)