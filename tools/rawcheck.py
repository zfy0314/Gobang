#------------------------------
# checking corrupt raw data file
# written by zfy 12-03-2018
#------------------------------

#--imports---------------------
from os import listdir
from os import system
from setting import *
from raw2dataset import zfy_readtxt
from raw2dataset import zfy_findboard
from raw2dataset import zfy_expand

#--check items-----------------
def zfy_isboard(board):
    for i in range(len(board)):
        if not len(board[i]) == len(board[0]):
            print('corrupt!, error code 0: not a board! wrong row {}'.format(i + 1))
            return False
    return True

def zfy_issequence(board):
    board_ = zfy_expand(board)[0]
    total_step = max([max(x) for x in board_])
    for i in range(total_step):
        if -1 == zfy_findboard(board_, i + 1):
            print('corrupt!, error code 1: missing number {}'.format(i + 1))
            return False
    return True
    
#--main------------------------
def check():
    dirs = listdir(PATH_TO_RAW_DATA)
    passed = []
    for x in dirs:
        print('start checking {}'.format(x))
        board = zfy_readtxt(PATH_TO_RAW_DATA + x)
        if zfy_isboard(board):
            if zfy_issequence(board):
                print('{} check pass'.format(x))
                passed.append(x)
    print('{} passed'.format(passed))
    return passed

def main(argv = None):
    check()

if __name__ == '__main__':
    main()