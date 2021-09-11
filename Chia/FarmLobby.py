import psutil
print(psutil.disk_usage("C:\\").free / (1024 ** 3)) # this works
# output = ""
# for disk in psutil.disk_partitions():
#     output += str(disk)
# print(output)
# print(output.replace("\',", "'\n")) 

# sdiskpart(device='C:\\'
#  mountpoint='C:\\'
#  fstype='NTFS'
#  opts='rw,fixed'