#------------------------------
# initializations
# check raw dataset, convert dataset, slice trainsets
# written by zfy 12-15-2018
#------------------------------

from helpers.helpers import *

def main(argv = None):
    if FILE_HUMAN_DATASET in listdir(PATH_TO_DATASET):
        print('found exsisting human dataset')
        system('rm ' + PATH_TO_DATASET + FILE_HUMAN_DATASET)
        print('removed.')

    print('start checking raw data')
    rawdata_files = listdir(PATH_TO_RAW_DATA)
    print('read files {}'.format(rawdata_files))
    passed = []
    for rawdata_file in rawdata_files:
        board = zfy_readtxt(PATH_TO_RAW_DATA + rawdata_file)
        if zfy_isboard(board) and zfy_issequence(board): passed.append(rawdata_file)
    print('passed files: {}'.format(passed))

    print('start converting raw data')
    for rawdata_file in passed:
        board = zfy_readtxt

    
    
    return None