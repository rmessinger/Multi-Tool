
import os 
import subprocess, sys
import glob
import time

# dir_path = os.path.dirname(os.path.realpath(__file__))

dir_name = 'C:/Users/reidm/.chia/mainnet/plotter/'
# Get list of all files only in the given directory
list_of_files = filter( os.path.isfile,
                        glob.glob(dir_name + '*') )
# Sort list of files based on creation time in ascending order
list_of_files = sorted( list_of_files,
                        key = os.path.getctime)
# Iterate over sorted list of files and print file path 
# along with creation time of file 
for file_path in list_of_files:
    timestamp_str = time.strftime(  '%m/%d/%Y :: %H:%M:%S',
                                time.gmtime(os.path.getctime(file_path))) 
    print(timestamp_str, ' -->', file_path) 

#p = subprocess.Popen(["powershell.exe", 
#              ".\\CreatePlot.ps1 plots show"], 
#              stdout=sys.stdout)
#p.communicate()