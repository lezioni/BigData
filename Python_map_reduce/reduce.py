#!/usr/bin/env python3

import sys

curr_word = None
curr_count = 0

# Process each key-value pair from the mapper
for line in sys.stdin:

  # Get the key and value from the current line
  word, count = line.split('\t')

  # Convert the count to an int
  count = int(count)

  # If the current word is the same as the previous word, 
  # increment its count, otherwise print the words count 
  # to stdout
  if word == curr_word:
     curr_count += count
  else:

     # Write word and its number of occurrences as a key-value 
     # pair to stdout
     if curr_word:
        print (curr_word + '\t' + str(curr_count))

     curr_word = word
     curr_count = count

# Output the count for the last word
if curr_word == word:
  print (curr_word + '\t' + str(curr_count))